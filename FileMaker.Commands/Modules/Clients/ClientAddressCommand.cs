using FileMaker.Infrastructure.Enums;

namespace FileMaker.Commands.Modules.Clients
{
    public class ClientAddressCommand
    {
        public string Address { get; set; }

        public string BussinesAddress { get; set; }

        public Town Town { get; set; }

        public City City { get; set; }

        public string PostalCode { get; set; }
    }
}