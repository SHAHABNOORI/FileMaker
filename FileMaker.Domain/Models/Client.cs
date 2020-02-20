using System;
using FileMaker.Infrastructure.Enums;

namespace FileMaker.Domain.Models
{
    public class Client
    {

        public int ClientCode { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Gender Gender { get; set; }

        public string NickName { get; set; }

        public ClientStatus Status { get; set; }

        public Titles Title { get; set; }

        public SexualOrientation SexualOrientation { get; set; }

        public DateTime? Dob { get; set; }

        public ClientRelation Relation { get; set; }

        public byte[] Photo { get; set; }

        public ClientSalesman Salesman { get; set; }

        public ClientCategory ClientCategory { get; set; }

        public virtual Origin Origin { get; set; }

        public virtual Language Language { get; set; }

        public virtual ClientContact ClientContact { get; set; }

        public virtual ClientAddress ClientAddress { get; set; }

        public virtual ClientDeliveryAddress ClientDeliveryAddress { get; set; }

        public virtual ClientPurchase ClientPurchase { get; set; }

        public virtual ClientExtraInformation ClientExtraInformation { get; set; }

        public virtual ClientPayment ClientPayment { get; set; }
    }
}