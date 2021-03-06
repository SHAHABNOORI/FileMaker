﻿using System;
using FileMaker.Infrastructure.Enums;

namespace FileMaker.Commands.Modules.Clients
{
    public class UpdateClientBaseInfoCommand
    {
        public int ClientCode { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Gender Gender { get; set; }

        public string NickName { get; set; }

        public ClientStatus Status { get; set; }

        public Titles Title { get; set; }
        
        public int OriginId { get; set; }
        
        public SexualOrientation SexualOrientation { get; set; }

        public DateTime? Dob { get; set; }
        
        public ClientRelation Relation { get; set; }

        public byte[] Photo { get; set; }

        public ClientSalesman Salesman { get; set; }

        public ClientCategory ClientCategory { get; set; }
    }
}