namespace Airedale;

public class AiredaleConfig {
    public static AiredaleConfig Instance { get; set; } = null!;

    /// <summary>
    /// Hashing salt
    /// </summary>
    public string Salt { get; set; } = null!;
}