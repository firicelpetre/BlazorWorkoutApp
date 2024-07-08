using Blazornetrom.DTOs;
using Blazornetrom.Entites;

namespace Blazornetrom.Repositories.Interfaces
{
    public interface IUserRepository
    {
        
        IList<UsersDTO> GetAll();

        UsersDTO? GetUserById(int id);

        void UpdateUser(UsersDTO user);

        void AddUser(UsersDTO user);

        void DeleteUser(int id);








    }
}
