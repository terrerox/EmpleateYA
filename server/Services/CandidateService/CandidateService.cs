using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using server.Dtos;
using server.Models;

namespace server.Services.CandidateService
{
    public class CandidateService : ICandidateService
    {
        private readonly IMapper _mapper;
        private static string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private string candidatesTable = Path.Combine(userPath, "Downloads\\Candidates.json");

        public CandidateService(IMapper mapper) 
        {
            _mapper = mapper;
        }
        public ServiceResponse<GetCandidateDto> AddCandidate(AddCandidateDto newCandidate)
        {
            ServiceResponse<GetCandidateDto> serviceResponse = new ServiceResponse<GetCandidateDto>();
            Candidate candidate = _mapper.Map<Candidate>(newCandidate);
            try
            {
                candidate.Id = GenerateID();
                CreateCandidate(candidate);

                serviceResponse.Data = _mapper.Map<GetCandidateDto>(candidate);;
                serviceResponse.Message = "Candidato agregado con éxito";    
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
        public ServiceResponse<List<GetCandidateDto>> GetAllCandidates()
        {
            ServiceResponse<List<GetCandidateDto>> serviceResponse = new ServiceResponse<List<GetCandidateDto>>();
            try
            {
                List<Candidate> candidates = GetCandidates();
                serviceResponse.Data = candidates.Select(c => _mapper.Map<GetCandidateDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Data = new List<GetCandidateDto>();
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public ServiceResponse<GetCandidateDto> GetCandidateById(Guid id)
        {
            ServiceResponse<GetCandidateDto> serviceResponse = new ServiceResponse<GetCandidateDto>();
            Candidate selectedCandidate = GetCandidates().FirstOrDefault(c => c.Id == id);
            try
            {
                serviceResponse.Data = _mapper.Map<GetCandidateDto>(selectedCandidate);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public ServiceResponse<GetCandidateDto> UpdateCandidate(UpdateCandidateDto updatedCandidate)
        {
            ServiceResponse<GetCandidateDto> serviceResponse = new ServiceResponse<GetCandidateDto>();
            try
            {
                Candidate selectedCandidate = GetCandidates().FirstOrDefault(c => c.Id == updatedCandidate.Id);
                selectedCandidate.Name = updatedCandidate.Name;
                selectedCandidate.Email = updatedCandidate.Email;
                selectedCandidate.SalaryExpectation = updatedCandidate.SalaryExpectation;
                selectedCandidate.JobId = updatedCandidate.JobId;
                List<Candidate> candidates = GetCandidates().Where(x => x.Id != updatedCandidate.Id).ToList();
                File.Delete(candidatesTable);
                candidates.Add(selectedCandidate);
                foreach (Candidate candidate in candidates)
                {
                    CreateCandidate(candidate);
                }
                serviceResponse.Data = _mapper.Map<GetCandidateDto>(selectedCandidate);
                 
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }          
            return serviceResponse;
        }
        // helpers
        private void CreateCandidate(Candidate newCandidate)
        {
            string json = JsonConvert.SerializeObject(newCandidate);

            using(StreamWriter writer = new StreamWriter(candidatesTable, true))
            {
                writer.WriteLine(json);
            }
        }
        private List<Candidate> GetCandidates()
        {
            List<Candidate> Candidates = new List<Candidate>();

            List<string> lines = new List<string>();
            lines = File.ReadAllLines(candidatesTable).ToList();

            foreach (String line in lines)
            {
                Candidate candidate = JsonConvert.DeserializeObject<Candidate>(line);
                Candidates.Add(candidate);
            }
            return Candidates;
        }
        private Guid GenerateID()
        {
            return Guid.NewGuid();
        }
    }
}