using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Utilities.Net;
using System.Net;
using System.Threading.Tasks;
using IPAddress = System.Net.IPAddress;


namespace BlogWeb.Models;

public class IpSafeMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly IpList _ipList;

    public IpSafeMiddleWare(RequestDelegate next, IOptions<IpList> ipList)
    {
        this._next = next;
        this._ipList = ipList.Value;
        
    }
    
    public async Task Invoke(HttpContext context)
    {
        var remoteIp = context.Connection.RemoteIpAddress;
        var isAllowed = false;

        foreach (var ip in _ipList.AllowedIPs)
        {
            var testIp = IPAddress.Parse(ip);
            if (testIp.Equals(remoteIp))
            {
                isAllowed = true;
                break;
            }
        }

        if (!isAllowed)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return;
        }

        await _next.Invoke(context);
    }



    
    
}