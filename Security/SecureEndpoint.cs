namespace Airedale.Security; 

public class SecureEndpoint {
    public string Name { get; set; } = null!;
    
    public bool AllowAnonymous { get; set; }
}