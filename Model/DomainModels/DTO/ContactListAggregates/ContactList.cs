using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DomainModels.DTO.ContactListAggregates
{
    public class ContactList
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactAddress { get; set; }
        public string Email { get; set; }
    }
}
