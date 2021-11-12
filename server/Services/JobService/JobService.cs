using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using server.Dtos;
using server.Models;
using server.Services.MailService;

namespace server.Services.JobService
{
    public class JobService : IJobService
    {

        private readonly IMapper _mapper;
        private static string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private string jobsTable = Path.Combine(userPath, "Downloads\\Jobs.json");
        private readonly IMailService _mailService;
        public JobService(IMapper mapper, IMailService mailService)
        {
            _mapper = mapper;
            _mailService = mailService;

        }
        public ServiceResponse<GetJobDto> AddJob(AddJobDto newJob)
        {
            ServiceResponse<GetJobDto> serviceResponse = new ServiceResponse<GetJobDto>();
            Job Job = _mapper.Map<Job>(newJob);
            try
            {
                Job.Id = GenerateID();
                CreateJob(Job);

                serviceResponse.Data = _mapper.Map<GetJobDto>(Job);
                serviceResponse.Message = "Candidato agregado con éxito"; 
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
        
        public ServiceResponse<List<GetJobDto>> GetAllJobs()
        {
            ServiceResponse<List<GetJobDto>> serviceResponse = new ServiceResponse<List<GetJobDto>>();
            try
            {
                List<Job> jobs = GetJobs();
                serviceResponse.Data = jobs.Select(c => _mapper.Map<GetJobDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Data = new List<GetJobDto>();
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
        public ServiceResponse<GetJobDto> GetJobById(Guid id)
        {
            ServiceResponse<GetJobDto> serviceResponse = new ServiceResponse<GetJobDto>();
            Job selectedJob = GetJobs().FirstOrDefault(c => c.Id == id);
            List<Candidate> jobCandidates = GetJobCandidates(id);
            selectedJob.Candidates = jobCandidates;
            try
            {
                serviceResponse.Data = _mapper.Map<GetJobDto>(selectedJob);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public ServiceResponse<GetJobDto> UpdateJob(UpdateJobDto updatedJob)
        {
            ServiceResponse<GetJobDto> serviceResponse = new ServiceResponse<GetJobDto>();
            try
            {
                Job selectedJob = GetJobs().FirstOrDefault(c => c.Id == updatedJob.Id);
                selectedJob.Name = updatedJob.Name;
                selectedJob.Salary = updatedJob.Salary;
                selectedJob.Status = updatedJob.Status;

                List<Job> jobs = GetJobs().Where(x => x.Id != updatedJob.Id).ToList();
                File.Delete(jobsTable);
                jobs.Add(selectedJob);
                foreach (Job job in jobs)
                {
                    CreateJob(job);
                }
                if(updatedJob.Status == StatusClass.Hiring)
                {
                    NotifyCandidates(updatedJob);
                }
                serviceResponse.Data = _mapper.Map<GetJobDto>(selectedJob);
                 
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }          
            return serviceResponse;
        }

        // helpers
        private void CreateJob(Job newJob)
        {
            string json = JsonConvert.SerializeObject(newJob);

            using(StreamWriter writer = new StreamWriter(jobsTable, true))
            {
                writer.WriteLine(json);
            }
        }
        private List<Job> GetJobs()
        {
            List<Job> jobs = new List<Job>();

            List<string> lines = new List<string>();
            lines = File.ReadAllLines(jobsTable).ToList();

            foreach (String line in lines)
            {
                Job job = JsonConvert.DeserializeObject<Job>(line);
                jobs.Add(job);
            }
            return jobs;
        }
        private List<Candidate> GetJobCandidates(Guid jobId)
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string candidatesTable = Path.Combine(userPath, "Downloads\\Candidates.json");
            List<Candidate> Candidates = new List<Candidate>();

            List<string> lines = new List<string>();
            lines = File.ReadAllLines(candidatesTable).ToList();

            foreach (String line in lines)
            {
                Candidate candidate = JsonConvert.DeserializeObject<Candidate>(line);
                if (candidate.JobId == jobId) 
                {
                    Candidates.Add(candidate);
                } else {
                    continue;
                }
            }
            return Candidates;
        }

        private void NotifyCandidates(UpdateJobDto updatedJob) 
        {
            List<Candidate> jobCandidates = GetJobCandidates(updatedJob.Id);
            foreach(Candidate candidate in jobCandidates)
            {
                if(updatedJob.Salary >= candidate.SalaryExpectation) {
                    MailRequest request = new MailRequest(
                        candidate.Email,
                        "Alerta de trabajo",
                        $"El salario del puesto <<{updatedJob.Salary}>> está dentro de tus aspiraciones salariales <<{candidate.SalaryExpectation}>>"
                    );
                    _mailService.SendEmailAsync(request);
                }
            }
        }
        private Guid GenerateID()
        {
            return Guid.NewGuid();
        }
    }
}