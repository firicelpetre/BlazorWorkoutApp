using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Blazornetrom.Repositories.Imlplementations;
using Blazornetrom.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazornetrom.Components.Pages
{
    public partial class AddEditWorkoutsPage : ComponentBase
    {
        [Parameter]
        public int? UserId { get; set; }


        [Parameter]
        public int? WorkoutId { get; set; }


        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Inject]
        public IWorkoutsRepository WorkoutsRepository { get; set; }

        [SupplyParameterFromForm]
        public UsersDTO usersDTO { get; set; } = new UsersDTO();

        [SupplyParameterFromForm]
        public WorkoutsDTO workoutsDTO { get; set; } = new ();

        [Inject]
        public NavigationManager NavigationManager { get; set; } 

        public string Title { get; set; } = string.Empty;

        private bool IsEdit = false;

        protected override void OnParametersSet()
        {
            if (WorkoutId != null)
            {
                workoutsDTO = WorkoutsRepository.GetById(WorkoutId.Value);
            }

            if (UserId != null)
            {
                usersDTO = UserRepository.GetUserById(UserId.Value);
                workoutsDTO.UsersId = UserId.Value;
            }
        }

        private void SaveWorkout()
        {

            if (WorkoutId == null)
            {
                workoutsDTO.UsersId = usersDTO.Id;
                WorkoutsRepository.AddWorkout(workoutsDTO);
            }
            else
            {
                WorkoutsRepository.UpdateWorkouts(workoutsDTO);
            }

            NavigationManager.NavigateTo("/workouts");
        }
    }
}
