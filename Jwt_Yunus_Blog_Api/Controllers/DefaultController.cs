using Jwt_Yunus_Blog_Api.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Yunus_Blog_Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DefaultController : Controller
{
   
    [HttpGet("[action]")]
    // GET
    public IActionResult Login()
    {
        return Created("", new BuildToken().CreateToken());
    }
    
    [Authorize]
    [HttpGet("[action]")]
    
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
    
    
    
}