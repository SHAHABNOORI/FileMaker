﻿using FileMaker.Infrastructure.Enums;

namespace FileMaker.Commands.Modules.Clients
{
    public class ClientContactCommand
    {
        public string HomeNumber { get; set; }

        public ClientContactType ContactType { get; set; }

        public string EmailAddress { get; set; }

        public string Website { get; set; }

        public string MobileNumber { get; set; }

        public string PhoneNumber { get; set; }

        public OkToContact OkToContact { get; set; }
    }
}