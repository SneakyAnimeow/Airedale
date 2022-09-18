using Airedale.Database.Context;

namespace Airedale.Security;

public class SecurityMiddleware {
    private static readonly string[] Blacklist = {
        "/api/graphql",
    };

    private readonly RequestDelegate _next;
    
    public SecurityMiddleware(RequestDelegate next) {
        _next = next;
    }

    public Task InvokeAsync(HttpContext context) {
        return Blacklist.Any(s => (context.Request.Path.Value ?? "").StartsWith(s)) ? ChallengeRequest(context) : _next(context);
    }
    
    private Task ChallengeRequest(HttpContext context) {
        var dbContext = new AiredaleDbContext();
        
        var token = context.Request.Cookies["token"] ?? "";
        
        var user = dbContext.Users.FirstOrDefault(u => u.Token == token);
        
        if (user == null) {
            context.Response.Redirect("/login");
            return Task.CompletedTask;
        }
        
        return _next(context);
    }
}