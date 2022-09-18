using Airedale.Database.Context;
using Airedale.Security;
using Microsoft.AspNetCore.Mvc;

namespace Airedale.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase {
    [HttpGet]
    public string Login() {
        return "This endpoint is not accessible using GET method";
    }
    
    [HttpPost]
    public IActionResult Login([FromForm] string username, [FromForm] string password) {
        var context = new AiredaleDbContext();
        
        var user = context.Users.FirstOrDefault(u => u.Name == username);
        
        if (user == null || !AiredaleArgon2.Verify(password, user.PassHash)) {
            return Unauthorized();
        }

        user.Token = Guid.NewGuid().ToString();

        context.Users.Update(user);
        context.SaveChanges();

        Response.Cookies.Append("token", user.Token);
        
        return Ok();
    }
}