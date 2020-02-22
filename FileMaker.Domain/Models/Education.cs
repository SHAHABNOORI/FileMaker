using System.Collections.Generic;

namespace FileMaker.Domain.Models
{
    public class Education
    {
        public int EducationId { get; set; }

        public string EducationName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}