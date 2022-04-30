using System.Text.Json.Serialization;

namespace Domain.Aggregates
{
    public class Skill
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore] public Candidate? Candidate { get; set; }
    }
}
