using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SigmaCandidate.Data;
using SigmaCandidate.DTOs;
using SigmaCandidate.Models;
using SigmaCandidate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaCandidate.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateService _candidateService;

        public CandidatesController(CandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateDto>>> GetCandidates()
        {
            var candidates = await _candidateService.GetAllCandidatesAsync();
            return Ok(candidates);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDto>> GetCandidate(int id)
        {
            var candidate = await _candidateService.GetCandidateByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(candidate);
        }

        [HttpPost]
        public async Task<ActionResult<CandidateDto>> AddCandidate(CandidateDto candidateDto)
        {
            var newCandidate = await _candidateService.AddCandidateAsync(candidateDto);
            return CreatedAtAction(nameof(GetCandidate), new { id = newCandidate.Id }, newCandidate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, CandidateDto candidateDto)
        {
            try
            {
                var updatedCandidate = await _candidateService.UpdateCandidateAsync(id, candidateDto);
                return Ok(updatedCandidate);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            try
            {
                var result = await _candidateService.DeleteCandidateAsync(id);
                if (result)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
