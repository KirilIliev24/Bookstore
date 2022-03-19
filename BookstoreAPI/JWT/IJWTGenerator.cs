using BookstoreAPI.APIReqResModels.User;

namespace BookstoreAPI.JWT
{
    public interface IJWTGenerator
    {
        string GenerateJwt(UserResponceModel user);
    }
}
