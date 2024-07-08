namespace Blazornetrom.Entites
{
    public class Exercises

    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public ICollection<ExercicesLogs> ExercicesLogs { get; set; }
    }
}
