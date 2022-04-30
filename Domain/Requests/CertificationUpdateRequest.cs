namespace Domain.Requests
{
    public class CertificationUpdateRequest
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public DateTime? AchievementDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
