namespace Blazornetrom.Entites
{
    public class Users
    {
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public ICollection<Workouts> Workouts { get; set; }

        public string Email { get; set; }

        public Boolean IsTrainer {  get; set; }

        public string Password { get; set; }
    }
}
