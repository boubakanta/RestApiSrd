using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ClientEnt
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        [StringLength(30, ErrorMessage = "Limit first name to 30 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nom")]
        [StringLength(30, ErrorMessage = "Limit last name to 30 characters.")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        //public DateTime DateOfBirth { get; set; }

        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
    }
}
