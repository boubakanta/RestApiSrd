using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ClientEnt : IComparable
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
        public StatusClient Status { get; set; }

        #region Operator==

        #region Equals
        public override bool Equals(object obj)
        {
            if ((obj != null) && (this.GetType() == obj.GetType()))
            {
                ClientEnt objC = (ClientEnt)obj;
                return this.LastName.ToLower() == objC.LastName.ToLower()
                    && this.FirstName.ToLower().Equals(objC.FirstName.ToLower())
                    && this.TelephoneNumber == objC.TelephoneNumber;
            }
            else
                return false;
        }
        #endregion

        #region GetHashCode
        public override int GetHashCode()
        {
            return String.Concat(this.LastName + " "
                + this.FirstName + " "
                + this.TelephoneNumber).GetHashCode();
        }
        #endregion

        #region CompareTo
        public int CompareTo(object obj)
        {
            if ((obj != null) && (this.GetType() == obj.GetType()))
            {
                ClientEnt objClientModel = obj as ClientEnt;
                return (this.FirstName + this.LastName + this.TelephoneNumber).CompareTo(objClientModel.FirstName + objClientModel.LastName + objClientModel.TelephoneNumber);
            }
            else
                throw new ArgumentException("Pas le type Attendu(ClientEnt)");
        }
        #endregion

        #region operator ==
        public static bool operator ==(ClientEnt c1, ClientEnt c2)
        {
            return c1.Equals(c2);
        }
        #endregion

        #region operator !=
        public static bool operator !=(ClientEnt c1, ClientEnt c2)
        {
            return !c1.Equals(c2);
        } 
        #endregion

        #endregion
    }

    public enum StatusClient
    {
        Inactif = 0,
        Active = 1,
    }
}
