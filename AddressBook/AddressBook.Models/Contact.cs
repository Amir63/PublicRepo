using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Contact :IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public List<PhoneNumber> PhoneNumber { get; set; }
        public List<Address> Address { get; set; }
        public List<Email> Email { get; set; }
        public string WebSite { get; set; }
        public string Notes { get; set; }
        public int Id { get; set; }

        public Contact()
        {
            PhoneNumber = new List<PhoneNumber>();
            Address = new List<Address>();
            Email = new List<Email>();
        }

        public int CompareTo(object obj)
        {
            Contact otherContact = obj as Contact;
            if (otherContact == null) return 1;

            if (otherContact.LastName != null)
                return this.LastName.CompareTo(otherContact.LastName);
            else
                throw new ArgumentException("Object is not a Contact");
        }
    }
}
