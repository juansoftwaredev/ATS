using ATS.Domain.Entities;
using ATS.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ATS.Infraestructure.Repositories.Implementations
{
    public class CandidateRepository
    {
        private readonly AppDbContext _context;

        public CandidateRepository(AppDbContext context) 
            => _context = context;

        public async Task<List<Candidate>> GetAllAsync() 
            => await _context.Candidates.Include(c => c.Experiences).ToListAsync();

        public async Task<Candidate> GetByIdAsync(int id) 
            => await _context.Candidates.Include(c => c.Experiences).FirstOrDefaultAsync(c => c.IdCandidate == id);

        public async Task AddAsync(Candidate candidate) 
        { 
            _context.Candidates.Add(candidate); 
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(Candidate candidate)
        { 
            _context.Candidates.Update(candidate); 
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(Candidate candidate) 
        { 
            _context.Candidates.Remove(candidate); 
            await _context.SaveChangesAsync(); 
        }
    }
}
