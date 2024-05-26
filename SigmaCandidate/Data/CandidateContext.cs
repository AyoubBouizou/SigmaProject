using Microsoft.EntityFrameworkCore;
using SigmaCandidate.Models;

namespace SigmaCandidate.Data
{
    public class CandidateContext : DbContext
    {
        public CandidateContext(DbContextOptions<CandidateContext> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
    }
}
