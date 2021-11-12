using System;
using System.Collections.Generic;
using server.Models;

namespace server.Dtos
{
    public class GetJobDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public StatusClass Status { get; set; }
        public List<Candidate> Candidates { get; set; }

    }
}