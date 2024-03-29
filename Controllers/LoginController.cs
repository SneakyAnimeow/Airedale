﻿using Airedale.Database.Context;
using Airedale.Security;
using Microsoft.AspNetCore.Mvc;

namespace Airedale.Controllers; 

[ApiController]
[Route("api/[controller]/[action]")]
public class LoginController : ControllerBase {
    /// <summary>
    /// Logs in by generating a new token and sending it to the client in a cookie.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Login([FromForm] string username, [FromForm] string password) {
        if(username == "anonymous" && password == "anonymous") {
            Response.Cookies.Append("token", "anonymous");
            return Ok();
        }
        
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
    
    /// <summary>
    /// Logs out the user by deleting the token
    /// [Requires at least anonymous authentication]
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Logout() {
        if(Request.Cookies["token"] == "anonymous") {
            Response.Cookies.Delete("token");
            return Ok();
        }
        
        var context = new AiredaleDbContext();
        
        var user = context.Users.FirstOrDefault(u => u.Token == Request.Cookies["token"]);
        
        if (user == null) {
            return Unauthorized();
        }

        user.Token = Guid.NewGuid().ToString();

        context.Users.Update(user);
        context.SaveChanges();

        Response.Cookies.Delete("token");
        
        return Ok();
    }
}