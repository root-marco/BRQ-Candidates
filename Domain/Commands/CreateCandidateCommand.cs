using Domain.ValueObjects;

namespace Domain.Commands
{
    public class CreateCandidateCommand
    {
        public string? Name { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<CreateSkillCommand>? Skills { get; set; }
        public List<CreateCertificationCommand>? Certifications { get; set; }
    }

    public class CreateSkillCommand
    {
        public string? Name { get; set; }
    }

    public class CreateCertificationCommand
    {
        public Guid Code { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public DateTime? AchievementDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
