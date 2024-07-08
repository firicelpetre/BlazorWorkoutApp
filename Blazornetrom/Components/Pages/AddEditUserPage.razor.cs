using Blazornetrom.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using Blazornetrom.Entites;
using System.Reflection;
using Blazornetrom.DTOs;
using System.Collections.Generic;


namespace Blazornetrom.Components.Pages
{
    public partial class AddEditUserPage : ComponentBase
    {
        [Parameter]
        public int? UserId { get; set; }

        [Inject]
        public IUserRepository UserRepository { get; set; }




        [SupplyParameterFromForm]
        public UsersDTO UsersDTO { get; set; } = new();



        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Title { get; set; } = string.Empty;

        private bool IsEdit = false;

        protected override void OnParametersSet()
        {
            if (UserId != null)
            {
                UsersDTO = UserRepository.GetUserById(UserId.Value);
                Title = "Edit user";
                IsEdit = true;
            }
            else
            {
                Title = "Add new user";
            }
        }

        private void SaveUser()
        {
            if (IsEdit)
            {
                UserRepository.UpdateUser(UsersDTO);
            }
            else
            {
                UserRepository.AddUser(UsersDTO);
            }

            NavigationManager.NavigateTo("/users");
        }
    }
}
