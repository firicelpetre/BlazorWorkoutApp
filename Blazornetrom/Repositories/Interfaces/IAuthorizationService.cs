using Blazornetrom.DTOs;

namespace Blazornetrom.Repositories.Interfaces
{
    public interface IAuthorizationService
    {
        void Login(LoginDTO loginDTO);
        bool IsEmailValid(string email);
        bool IsPasswordValid(string email, string password);
    }
}
