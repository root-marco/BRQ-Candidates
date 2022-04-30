using Domain.Aggregates;
using Domain.ValueObjects;

namespace Domain.Commands
{
    public class UpdateCandidateCommand
    {
        public string? Name { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<Skill>? Skills { get; set; }
        public List<Certification>? Certifications { get; set; }
    }
}
