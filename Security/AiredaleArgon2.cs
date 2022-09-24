using Isopoh.Cryptography.Argon2;

namespace Airedale.Security; 

public class AiredaleArgon2{
    public static string Hash(string password) {
        var output = Argon2.Hash(password, AiredaleConfig.Instance.Salt);
        GC.Collect();
        return output;
    }

    public static bool Verify(string password, string hash) {
        var output = Argon2.Verify(hash, password, AiredaleConfig.Instance.Salt);
        GC.Collect();
        return output;
    }
}