namespace Blazornetrom.Entites
{
    public class Workouts
    {
        public int Id {  get; set; }
        public int UserId {  get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Users Users { get; set; }
        public ICollection<ExercicesLogs> ExercicesLogs { get; set; }
    }
}
