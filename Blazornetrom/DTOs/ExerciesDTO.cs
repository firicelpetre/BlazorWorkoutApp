using Blazornetrom.Entites;
using System.ComponentModel.DataAnnotations;

namespace Blazornetrom.DTOs
{
    public class ExerciesDTO
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Description cannot be longer that 100 characters")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "Type cannot be longer that 100 characters")]
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
        public ICollection<ExercicesLogs> ExerciseLogs { get; set; }
    }
}
