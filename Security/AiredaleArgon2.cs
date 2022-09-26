using Isopoh.Cryptography.Argon2;

namespace Airedale.Security;

public class AiredaleArgon2 {
    /// <summary>
    /// Hashes a password using Argon2
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public static string Hash(string password) {
        var output = Argon2.Hash(password, AiredaleConfig.Instance.Salt);
        GC.Collect();
        return output;
    }

    /// <summary>
    /// Verifies a password against a hash
    /// </summary>
    /// <param name="password"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public static bool Verify(string password, string hash) {
        var output = Argon2.Verify(hash, password, AiredaleConfig.Instance.Salt);
        GC.Collect();
        return output;
    }
}