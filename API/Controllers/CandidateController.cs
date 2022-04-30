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

        [HttpGet, Route("name/{name}")]
        public async Task<IActionResult> GetCandidatesByName(string name)
        {
            var candidates = await _context.Candidates
                .Include(x => x.Skills)
                .Include(x => x.Certifications)
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();

            if (candidates is null)
            {
                return NotFound("Candidates not found");
            }

            return Ok(candidates);
        }

        [HttpGet, Route("cpf/{cpf}")]
        public async Task<IActionResult> GetCandidateByCPF(string cpf)
        {
            var candidate = await _context.Candidates
                .Include(x => x.Skills)
                .Include(x => x.Certifications)
                .Where(x => x.SocialSecurityNumber == cpf)
                .FirstOrDefaultAsync();

            if (candidate is null)
            {
                return NotFound("Candidate not found");
            }

            return Ok(candidate);
        }

        [HttpGet, Route("email/{email}")]
        public async Task<IActionResult> GetCandidatesByEmail(string email)
        {
            var candidates = await _context.Candidates
                .Include(x => x.Skills)
                .Include(x => x.Certifications)
                .Where(x => x.Email.ToLower().Contains(email.ToLower()))
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
    }
}
