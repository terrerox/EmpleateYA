using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public StatusClass Status { get; set; } = StatusClass.NotHiring;
        public List<Candidate> Candidates { get; set; }
    }
}