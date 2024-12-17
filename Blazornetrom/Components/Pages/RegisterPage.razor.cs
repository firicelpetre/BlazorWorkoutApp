using Blazornetrom.DTOs;
using Blazornetrom.Repositories.Implementations;
using Blazornetrom.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using System;

namespace Blazornetrom.Components.Pages
{
    public partial class RegisterPage
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        public UsersDTO userDto { get; set; } = new UsersDTO();
        public string ConfirmPassword { get; set; }


        [Inject]
        public IEmailService EmailService { get; set; }

        public bool RegistrationFailed { get; set; }
        public string ErrorMessage { get; set; }
        public string PasswordErrorMessage { get; set; } // Mesaj specific pentru validarea parolelor

        public async Task RegisterUser()
        {
            PasswordErrorMessage = string.Empty; // Resetează mesajul de eroare
            RegistrationFailed = false;

            if (string.IsNullOrEmpty(userDto.Gender))
            {
                RegistrationFailed = true;
                ErrorMessage = "Genul este obligatoriu.";
                return;
            }

            if (userDto.Password != ConfirmPassword)
            {
                PasswordErrorMessage = "Parola și confirmarea parolei nu se potrivesc.";
                RegistrationFailed = true;
                return;
            }

            try
            {
                // Adaugă utilizatorul în baza de date
                UserRepository.AddUser(userDto);

                // Trimite un email de confirmare
                string subject = "Înregistrare reușită";
                string body = $"Bun venit, {userDto.FirstName} {userDto.LastName}!\n" +
                              "Contul tău a fost creat cu succes. Îți mulțumim pentru înregistrare!";

                // Apelează metoda SendEmailAsync pe instanța injectată EmailService
                await EmailService.SendEmailAsync(userDto.Email, subject, body);

                // Navighează utilizatorul la pagina de login
                Navigation.NavigateTo("/");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ErrorMessage = "A apărut o eroare. Încercați din nou.";
                RegistrationFailed = true;
            }
        }


    }
}
