using Api.DTOs.Auth;

namespace Api.Repos.Auth
{
    public interface IAuthRepo
    {
        bool registerUser(Register register);
        Token loginUser(Login login);
    }
}