using System;

namespace server.Models
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double SalaryExpectation { get; set; }
        public Guid JobId { get; set; }
    }
}