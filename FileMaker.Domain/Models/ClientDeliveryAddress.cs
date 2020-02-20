using FileMaker.Infrastructure.Enums;

namespace FileMaker.Domain.Models
{
    public class ClientDeliveryAddress
    {
        public int ClientDeliveryAddressId { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public string Town { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }
        
        public string PhoneNumber { get; set; }

        public int ClientCode { get; set; }

        public Client Client { get; set; }
    }
}