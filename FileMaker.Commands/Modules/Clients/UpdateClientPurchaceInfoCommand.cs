namespace FileMaker.Commands.Modules.Clients
{
    public class CreateClientPurchaceInfoCommand
    {
        public int ClientCode { get; set; }

        public ClientPurchaceInfoCommand ClientPurchaceInformation { get; set; }

        public ClientExtraInformationCommand ClientExtraInformation { get; set; }

        public ClientPaymentCommand ClientPayment { get; set; }
    }
}