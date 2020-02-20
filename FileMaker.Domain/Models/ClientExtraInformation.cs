namespace FileMaker.Domain.Models
{
    public class ClientExtraInformation
    {
        public int ClientExtraInformationId { get; set; }

        public string Ntk { get; set; }

        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public string RelationShip { get; set; }

        public int ClientCode { get; set; }

        public virtual Client Client { get; set; }
    }
}