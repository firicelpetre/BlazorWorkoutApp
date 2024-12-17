using Blazornetrom.Context;
using Blazornetrom.DTOs;
using Blazornetrom.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using System;

namespace Blazornetrom.Components.Pages
{
    public partial class LoginPage
    {
        [Inject]
        public IAuthorizationService AuthorizationService { get; set; }

        [SupplyParameterFromForm]
        public LoginDTO loginDto { get; set; } = new LoginDTO();

        [Inject]
        private NavigationManager Navigation { get; set; }

        public bool FailedLogin { get; set; }
        public string ErrorMessage { get; set; }

        private void TryLogin()
        {
            FailedLogin = false;
            ErrorMessage = string.Empty;

            try
            {
                // Simulăm verificarea pentru exemple specifice
                if (!AuthorizationService.IsEmailValid(loginDto.email))
                {
                    ErrorMessage = "Email incorect. Verificați adresa introdusă.";
                    FailedLogin = true;
                    return;
                }

                if (!AuthorizationService.IsPasswordValid(loginDto.email, loginDto.password))
                {
                    ErrorMessage = "Parola incorectă. Încercați din nou.";
                    FailedLogin = true;
                    return;
                }

                AuthorizationService.Login(loginDto);
                Navigation.NavigateTo("/Home", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ErrorMessage = "A apărut o eroare neașteptată. Încercați din nou.";
                FailedLogin = true;
            }
        }

        private void NavigateToRegister()
        {
            Navigation.NavigateTo("/register");
        }
    }
}
