using System;
using System.Collections.Generic;
using server.Dtos;
using server.Models;

namespace server.Services.JobService
{
    public interface IJobService
    {
        ServiceResponse<GetJobDto> AddJob(AddJobDto newJob); 
        ServiceResponse<List<GetJobDto>> GetAllJobs();
        ServiceResponse<GetJobDto> GetJobById(Guid id);
        ServiceResponse<GetJobDto> UpdateJob(UpdateJobDto updatedJob);

    }
}