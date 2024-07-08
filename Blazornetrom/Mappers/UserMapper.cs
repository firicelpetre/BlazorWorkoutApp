using Blazornetrom.DTOs;
using Blazornetrom.Entites;

namespace Blazornetrom.Mappers
{
    public class UserMapper
    {
        public static Users ToUser(UsersDTO userDto)
        {
            return new Users
            {
                FirsName = userDto.FirstName,
                LastName = userDto.LastName,
                BirthDay = userDto.Birthday,
                Gender = userDto.Gender,
                Id = userDto.Id
            };
        }

        public static UsersDTO ToUserDto(Users user)
        {
            return new UsersDTO
            {
                FirstName = user.FirsName,
                LastName = user.LastName,
                Birthday = user.BirthDay,
                Gender = user.Gender,
                Id = user.Id
            };
        }
    }
}
