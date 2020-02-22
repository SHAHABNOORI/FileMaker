using System.Collections.Generic;

namespace FileMaker.Domain.Models
{
    public class Degree
    {
        public int DegreeId { get; set; }

        public string DegreeName { get; set; }

        public virtual ICollection<EmployeeDegree> EmployeeDegrees { get; set; }
    }
}