using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiRenovation.Model.Client
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        //public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
