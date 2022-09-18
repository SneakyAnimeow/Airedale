using Isopoh.Cryptography.Argon2;

namespace Airedale.Security; 

public class AiredaleArgon2{
    public static string Hash(string password) => Argon2.Hash(password, AiredaleConfig.Instance.Salt);
    
    public static bool Verify(string password, string hash) => Argon2.Verify(hash, password, AiredaleConfig.Instance.Salt);
}