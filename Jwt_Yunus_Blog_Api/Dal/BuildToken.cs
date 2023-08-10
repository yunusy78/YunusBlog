using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Jwt_Yunus_Blog_Api.Dal;

public class BuildToken
{
    public string CreateToken()
    {
        var bytes = Encoding.UTF8.GetBytes("YunusBlog2023-2024.,");
        SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: "http://localhost",
            audience: "http://localhost",
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: credentials
        );
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(token);
    }
}