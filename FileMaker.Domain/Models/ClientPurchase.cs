namespace FileMaker.Domain.Models
{
    public class ClientPurchase
    {
        public int ClientPurchaseId { get; set; }

        public string Balance { get; set; }

        public string Credit { get; set; }

        public string Discount { get; set; }

        public string PaymentTerms { get; set; }

        public string PaymentMethod { get; set; }

        public string Pricing { get; set; }

        public string Vat { get; set; }

        public int ClientCode { get; set; }

        public virtual Client Client { get; set; }
    }
}