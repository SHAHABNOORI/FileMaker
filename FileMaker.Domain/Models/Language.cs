using System.Collections.Generic;

namespace FileMaker.Domain.Models
{
    public sealed class Language
    {
        public Language()
        {
            Client = new HashSet<Client>();
        }

        public int Id { get; set; }

        public string LanguageName { get; set; }

        public ICollection<Client> Client { get; set; }
    }
}