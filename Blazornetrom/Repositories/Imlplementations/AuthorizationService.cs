using Blazornetrom.DTOs;
using Blazornetrom.Repositories.Interfaces;
using BlazorServerAuthenticationAndAuthorization.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Authentication;


namespace Blazornetrom.Repositories.Imlplementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository _userRepository;
        private readonly CustomAuthenticationStateProvider _customAuthenticationStateProvider;

        public AuthorizationService(IUserRepository userRepository, AuthenticationStateProvider authenticationStateProvider)
        {
            _userRepository = userRepository;
            _customAuthenticationStateProvider = (CustomAuthenticationStateProvider)authenticationStateProvider;
        }

        public void Login(LoginDTO loginDto)
        {
            var userToLogin = _userRepository.GetUserByEmail(loginDto.email);
            if (userToLogin == null || !BCrypt.Net.BCrypt.Verify(loginDto.password, userToLogin.Password))
            {
                throw new Exception("Nume de utilizator sau parolă incorectă");
            }

            _customAuthenticationStateProvider.UpdateAuthenticationState(userToLogin);
        }

        public bool IsEmailValid(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            return user != null;
        }

        public bool IsPasswordValid(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            return user != null && BCrypt.Net.BCrypt.Verify(password, user.Password);
        }
    }

}

