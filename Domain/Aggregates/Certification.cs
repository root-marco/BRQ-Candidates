﻿using System.Text.Json.Serialization;

namespace Domain.Aggregates
{
    public class Certification
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public DateTime? AchievementDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        [JsonIgnore] public Candidate? Candidate { get; set; }
    }
}
