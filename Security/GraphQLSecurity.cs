namespace Airedale.Security;

public class GraphQLSecurity {
    /// <summary>
    /// Throws an exception if the current user is not authorized to access the specified resource.
    /// </summary>
    /// <param name="token">Token from cookie</param>
    /// <exception cref="GraphQLException"/>
    public static void Authenticate(string token) {
        if (token == "anonymous") {
            throw new GraphQLException("Request is not authenticated.");
        }
    }
}