using AutoMapper;
using server.Dtos;
using server.Models;

namespace server.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddJobDto, Job>();
            CreateMap<Job, GetJobDto>();  
            CreateMap<AddCandidateDto, Candidate>();
            CreateMap<Candidate, GetCandidateDto>();    
        }        
    }

}