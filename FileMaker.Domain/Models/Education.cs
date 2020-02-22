using System.Collections.Generic;

namespace FileMaker.Domain.Models
{
    public class Education
    {
        public int EduacationId { get; set; }

        public string EduacationName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}