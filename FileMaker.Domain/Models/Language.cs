using System.Collections.Generic;

namespace FileMaker.Domain.Models
{
    public class Language
    {
        public int Id { get; set; }

        public string LanguageName { get; set; }

        public virtual ICollection<Client> Client { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}