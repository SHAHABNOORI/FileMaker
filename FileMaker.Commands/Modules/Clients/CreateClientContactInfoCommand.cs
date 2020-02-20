namespace FileMaker.Commands.Modules.Clients
{
    public class CreateClientContactInfoCommand
    {
        public int ClientCode { get; set; }

        public ClientContactCommand ClientContact { get; set; }

        public ClientAddressCommand ClientAddress { get; set; }

        public ClientDeliveryAddressCommand ClientDeliveryAddress { get; set; }

    }
}