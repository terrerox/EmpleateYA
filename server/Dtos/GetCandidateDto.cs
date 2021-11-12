using System;

namespace server.Dtos
{
    public class GetCandidateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double SalaryExpectation { get; set; }
        public Guid jobId { get; set; }
    }
}