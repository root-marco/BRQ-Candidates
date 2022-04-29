namespace Domain.Aggregates
{
    public class Skill
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Candidate? Candidate { get; set; }
    }
}
