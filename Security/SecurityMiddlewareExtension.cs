namespace Airedale.Security; 

public static class SecurityMiddlewareExtension {
    public static IApplicationBuilder UseSecurity(this IApplicationBuilder builder) => 
        builder.UseMiddleware<SecurityMiddleware>();
}