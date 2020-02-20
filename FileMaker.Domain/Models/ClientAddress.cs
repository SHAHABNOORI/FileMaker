using FileMaker.Infrastructure.Enums;

namespace FileMaker.Domain.Models
{
    public class ClientAddress
    {
        public int ClientAddressId { get; set; }

        public string Address { get; set; }

        public string BussinesAddress { get; set; }

        public Town Town { get; set; }

        public City City { get; set; }

        public string PostalCode { get; set; }

        public int ClientCode { get; set; }

        public virtual Client Client { get; set; }
    }
}