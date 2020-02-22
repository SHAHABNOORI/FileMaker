namespace FileMaker.Domain.Models
{
    public class EmployeeSkill
    {
        public int EmployeeNumber { get; set; }

        public Employee Employee { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}