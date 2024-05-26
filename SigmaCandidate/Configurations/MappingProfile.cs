using AutoMapper;
using SigmaCandidate.DTOs;
using SigmaCandidate.Models;

namespace SigmaCandidate.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidateDto>(); // Example mapping from Candidate to CandidateDto
            CreateMap<CandidateDto, Candidate>(); // Example reverse mapping from CandidateDto to Candidate
        }
    }
}
