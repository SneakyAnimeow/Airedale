namespace Airedale.Security; 

public static class SecurityMiddlewareExtension {
    /// <summary>
    /// Use this method to add the security middleware to the pipeline.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseSecurity(this IApplicationBuilder builder) => 
        builder.UseMiddleware<SecurityMiddleware>();
}