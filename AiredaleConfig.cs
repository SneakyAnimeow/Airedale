namespace Airedale; 

public class AiredaleConfig {
    public static AiredaleConfig Instance { get; set; } = null!;

    public string Salt { get; set; } = null!;
}