namespace Airedale.Security; 

public class GraphQLSecurity {
    public static void Authenticate(string token) {
        if(token == "anonymous") {
            throw new GraphQLException("Request is not authenticated.");
        }
    }
}