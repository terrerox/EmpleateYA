using System;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Models;
using server.Services.JobService;

namespace server.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService JobService)
        {
            _jobService = JobService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jobService.GetAllJobs());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(Guid id)
        {
            return Ok(_jobService.GetJobById(id));
        }

    
        [HttpPost]
        public IActionResult AddJob(AddJobDto newJob)
        {
            return Ok(_jobService.AddJob(newJob));
        } 

        [HttpPut]
        public IActionResult UpdateJob(UpdateJobDto updatedJob)
        {
            ServiceResponse<GetJobDto> response = _jobService.UpdateJob(updatedJob);
            if (response.Data == null)
            {
                response.Success = false;
                return NotFound(response);
            }        
            
            return Ok(response);
        }

    }
}