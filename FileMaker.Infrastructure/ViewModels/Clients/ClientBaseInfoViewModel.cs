using System;
using FileMaker.Infrastructure.Enums;
using FileMaker.Infrastructure.ViewModels.Languages;
using FileMaker.Infrastructure.ViewModels.Origins;

namespace FileMaker.Infrastructure.ViewModels.Clients
{
    public class ClientBaseInfoViewModel
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

        public int OriginId { get; set; }

        public OriginViewModel Origin { get; set; }

        public int? LanguageId { get; set; }

        public LanguageViewModel Language { get; set; }

    }
}