namespace Airedale.Security;

public class SecureEndpoint {
    /// <summary>
    /// The name of the endpoint
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Whether the endpoint is accessible with anonymous authentication
    /// </summary>
    public bool AllowAnonymous { get; set; }
}