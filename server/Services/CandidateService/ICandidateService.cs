using System;
using System.Collections.Generic;
using server.Dtos;
using server.Models;

namespace server.Services.CandidateService
{
    public interface ICandidateService
    {
        ServiceResponse<GetCandidateDto> AddCandidate(AddCandidateDto newCandidate); 
        ServiceResponse<List<GetCandidateDto>> GetAllCandidates();
        ServiceResponse<GetCandidateDto> GetCandidateById(Guid id);
        ServiceResponse<GetCandidateDto> UpdateCandidate(UpdateCandidateDto updatedCandidate);
    }
}