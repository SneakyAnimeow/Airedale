using Airedale.Database.Context;

namespace Airedale.Security;

public class SecurityMiddleware {
    private static readonly List<SecureEndpoint> SecuredEndpoints = new(){
        new(){Name = "/api/Login/Logout", AllowAnonymous = true},
        new(){Name = "/api/graphql", AllowAnonymous = true},
    };

    private readonly RequestDelegate _next;
    
    public SecurityMiddleware(RequestDelegate next) {
        _next = next;
    }

    public Task InvokeAsync(HttpContext context) {
        var secureEndpoint = SecuredEndpoints.FirstOrDefault(endpoint => (context.Request.Path.Value ?? "").StartsWith(endpoint.Name));

        return secureEndpoint == null ? _next(context) : ChallengeRequest(context, secureEndpoint);
    }
    
    private Task ChallengeRequest(HttpContext context, SecureEndpoint endpoint) {
        var token = context.Request.Cookies["token"] ?? "";

        if(token == "anonymous" && endpoint.AllowAnonymous) {
            return _next(context);
        }
        
        var dbContext = new AiredaleDbContext();
        
        var user = dbContext.Users.FirstOrDefault(u => u.Token == token);

        if (user != null) {
            return _next(context);
        }
        
        context.Response.Redirect("/login");
        return Task.CompletedTask;
    }
}