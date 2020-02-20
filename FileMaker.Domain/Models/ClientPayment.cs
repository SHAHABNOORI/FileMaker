using System;
using FileMaker.Infrastructure.Enums;

namespace FileMaker.Domain.Models
{
    public class ClientPayment
    {
        public int ClientPaymentId { get; set; }

        public string Name { get; set; }

        public DateTime? DateOfReferral { get; set; }

        public ReferralBy ReferralBy { get; set; }

        public ReferralFor ReferralFor { get; set; }

        public string ReferralTel { get; set; }

        public string ReasonForRefrral { get; set; }

        public Therapist Therapist { get; set; }

        public GpsName GpsName { get; set; }

        public string GpsNumber { get; set; }

        public string GpsAddress { get; set; }

        public OtherReqirments OtherReqirments { get; set; }

        public int ClientCode { get; set; }

        public virtual Client Client { get; set; }
    }
}