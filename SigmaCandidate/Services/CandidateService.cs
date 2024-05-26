using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SigmaCandidate.DTOs;
using AutoMapper;
using SigmaCandidate.Data;
using SigmaCandidate.Models;
using Microsoft.EntityFrameworkCore;

namespace SigmaCandidate.Services
{
    public class CandidateService
    {
        private readonly CandidateContext _context;
        private readonly IMapper _mapper;

        public CandidateService(CandidateContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CandidateDto>> GetAllCandidatesAsync()
        {
            var candidates = await _context.Candidates.ToListAsync();
            return _mapper.Map<IEnumerable<CandidateDto>>(candidates);
        }

        public async Task<CandidateDto> GetCandidateByIdAsync(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            return _mapper.Map<CandidateDto>(candidate);
        }

        public async Task<CandidateDto> AddCandidateAsync(CandidateDto candidateDto)
        {
            var candidate = _mapper.Map<Candidate>(candidateDto);
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
            return _mapper.Map<CandidateDto>(candidate);
        }

        public async Task<CandidateDto> UpdateCandidateAsync(int id, CandidateDto candidateDto)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                throw new ArgumentException("Candidate not found.");
            }

            _mapper.Map(candidateDto, candidate);
            await _context.SaveChangesAsync();
            return _mapper.Map<CandidateDto>(candidate);
        }

        public async Task<bool> DeleteCandidateAsync(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                throw new ArgumentException("Candidate not found.");
            }

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
            return true;
        } 
    
    }
}
