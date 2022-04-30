using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class Candidate
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        [NotMapped] public IList<Skill>? Skills { get; set; }
        [NotMapped] public IList<Certification>? Certifications { get; set; }
    }
}
