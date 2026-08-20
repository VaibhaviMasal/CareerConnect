using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerConnect.Application.Features.Recruiters.DTOs
{
    public class UpdateRecruiterDto
    {
        public string? CompanyName { get; set; }
        public string? Position { get; set; }
        public string? City { get; set; }
    }
}
