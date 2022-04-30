using Domain.Aggregates;
using Domain.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace API.Controllers
{
    public class CandidateController : ControllerBase
    {
        public readonly RepositoryContext _context;

        public CandidateController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> ListCandidates([FromQuery] string order, [FromQuery] int limit = 100)
        {
            var candidates = await _context.Candidates
                .Include(x => x.Skills)
                .Include(x => x.Certifications)
                .Take(limit)
                .ToListAsync();

            if (candidates is null)
            {
                return NotFound("Candidates not found");
            }

            if (order == "ASC")
            {
                candidates = candidates.OrderBy(x => x.Name).ToList();
            }
            if (order == "DESC")
            {
                candidates = candidates.OrderByDescending(x => x.Name).ToList();
            }

            return Ok(candidates);
        }

        [HttpGet, Route("search")]
        public async Task<IActionResult> SearchCandidates([FromQuery(Name = "query")] string query)
        {
            var candidates = await _context.Candidates
                .Include(x => x.Skills)
                .Include(x => x.Certifications)
                .Where(x => x.Name.ToLower().Contains(query.ToLower()) 
                    || x.Email.ToLower().Contains(query.ToLower()) 
                    || x.SocialSecurityNumber.ToLower().Contains(query.ToLower()))
                .ToListAsync();

            if (candidates is null)
            {
                return NotFound("Candidates not found");
            }

            return Ok(candidates);
        }

        [HttpGet, Route("skillName/{skillName}")]
        public async Task<IActionResult> GetCandidatesBySkillName(string skillName)
        {
            var candidates = await _context.Candidates
                .Include(x => x.Skills)
                .Include(x => x.Certifications)
                .Where(x => x.Skills.Select(x => x.Name).Contains(skillName))
                .ToListAsync();


            if (candidates is null)
            {
                return NotFound("Candidates not found");
            }

            return Ok(candidates);
        }

        [HttpGet, Route("certificationName/{certificationName}")]
        public async Task<IActionResult> GetCandidatesByCertificationName(string certificationName)
        {
            var candidates = await _context.Candidates
                .Include(x => x.Skills)
                .Include(x => x.Certifications)
                .Where(x => x.Certifications.Select(x => x.Name).Contains(certificationName))
                .ToListAsync();

            if (candidates is null)
            {
                return NotFound("Candidates not found");
            }

            return Ok(candidates);
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> CreateCandidate([FromBody] CreateCandidateCommand command)
        {
            var skills = new List<Skill>();
            foreach (var skill in command.Skills)
            {
                skills.Add(new()
                {
                    Name = skill.Name,
                });
            }

            var certifications = new List<Certification>();
            foreach (var certification in command.Certifications)
            {
                certifications.Add(new()
                {
                    Code = certification.Code,
                    Name = certification.Name,
                    URL = certification.URL,
                    AchievementDate = certification.AchievementDate,
                    ExpirationDate = certification.ExpirationDate,
                });
            }

            var candidate = new Candidate()
            {
                Name = command.Name,
                SocialSecurityNumber = command.SocialSecurityNumber,
                Email = command.Email,
                Phone = command.Phone,
                Gender = command.Gender,
                BirthDate = command.BirthDate,
                Skills = skills,
                Certifications = certifications,
            };

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            return Ok(candidate);
        }

        [HttpPut, Route("update/{candidateId}")]
        public async Task<IActionResult> UpdateCandidate(int candidateId, [FromBody] UpdateCandidateCommand command)
        {
            var candidate = new Candidate()
            {
                Id = candidateId,
                Name = command.Name,
                SocialSecurityNumber = command.SocialSecurityNumber,
                Email = command.Email,
                Phone = command.Phone,
                Gender = command.Gender,
                BirthDate = command.BirthDate,
                Skills = command.Skills,
                Certifications = command.Certifications,
            };

            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();

            return Ok(candidate);
        }
    }
}
