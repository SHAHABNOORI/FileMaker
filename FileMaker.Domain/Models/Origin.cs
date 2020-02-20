using System.Collections.Generic;

namespace FileMaker.Domain.Models
{
    public class Origin
    {
        public int Id { get; set; }

        public string OriginName { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}