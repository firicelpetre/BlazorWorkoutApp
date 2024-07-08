using Blazornetrom.Entites;
using System.ComponentModel.DataAnnotations;

namespace Blazornetrom.DTOs
{
    public class WorkoutsDTO
    {
        public int Id { get; set; }

        public int UsersId { get; set; }

        [StringLength(100, ErrorMessage = "Name cannot be longer that 100 characters")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

       
        [Required(ErrorMessage = "date is required")]
        public DateTime Date { get; set; }

        public Users Users { get; set; }

        public ICollection<ExercicesLogs> ExerciseLogs { get; set; }


    }
}
