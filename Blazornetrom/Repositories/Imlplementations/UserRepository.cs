using Blazornetrom.Context;
using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Blazornetrom.Mappers;
using Blazornetrom.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blazornetrom.Repositories.Imlplementations
{
    public class UserRepository : IUserRepository
    {
        public readonly SmartWorkoutContext _context;
        public UserRepository(SmartWorkoutContext context)
        {
            _context = context;
        }

        public IList<UsersDTO> GetAll()
        {
            return _context.Users.Select(u => UserMapper.ToUserDto(u)).ToList();
        }


        public UsersDTO? GetUserById(int id)
        {
            Users? user = _context.Users.Find(id);
            if (user != null)
            {
                return UserMapper.ToUserDto(user);
            }
            return null;
        }

        public void UpdateUser(UsersDTO user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.FirsName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Gender = user.Gender;
                existingUser.BirthDay = user.Birthday;
                existingUser.Email = user.Email;
                existingUser.IsTrainer = user.IsTrainer;

                _context.Users.Update(existingUser);
                _context.SaveChanges();
            }
        }

        public void AddUser(UsersDTO userDto)
        {
            var user = new Users
            {
                FirsName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Gender= userDto.Gender,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),  
                IsTrainer = userDto.IsTrainer // 
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public void DeleteUser(int id)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser != null)
            {
                _context.Users.Remove(existingUser);
                _context.SaveChanges();
            }
        }

        public Users GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x =>x.Email==email);
        }
    }
}