using System;
using server.Models;

namespace server.Dtos
{
    public class UpdateJobDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public StatusClass Status { get; set; } = StatusClass.NotHiring;
    }
}