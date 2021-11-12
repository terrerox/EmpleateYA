using System;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Models;
using server.Services.CandidateService;

namespace server.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_candidateService.GetAllCandidates());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(Guid id)
        {
            return Ok(_candidateService.GetCandidateById(id));
        }

        [HttpPost]
        public IActionResult AddCandidate(AddCandidateDto newCandidate)
        {
            return Ok(_candidateService.AddCandidate(newCandidate));
        } 
        
        [HttpPut]
        public IActionResult UpdateCandidate(UpdateCandidateDto updatedCandidate)
        {
            ServiceResponse<GetCandidateDto> response = _candidateService.UpdateCandidate(updatedCandidate);
            if (response.Data == null)
            {
                response.Success = false;
                return NotFound(response);
            }        
            
            return Ok(response);
        }
    }
}