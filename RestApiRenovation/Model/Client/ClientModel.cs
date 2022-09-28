using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiRenovation.Model.Client
{
    public class ClientModel : IComparable
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        //public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public StatusClientModel Status { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        #region Operator==

        #region Equals
        public override bool Equals(object obj)
        {
            if ((obj != null) && (this.GetType() == obj.GetType()))
            {
                ClientModel objC = (ClientModel)obj;
                return this.LastName == objC.LastName
                    && this.FirstName.Equals(objC.FirstName)
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
            if (obj is ClientModel)
            {
                ClientModel objClientModel = obj as ClientModel;
                return (this.FirstName + this.LastName + this.TelephoneNumber).CompareTo(objClientModel.FirstName + objClientModel.LastName + objClientModel.TelephoneNumber);
            }
            else
                throw new ArgumentException("Pas le type Attendu(ClientModel)");
        }
        #endregion

        #region operator ==
        public static bool operator ==(ClientModel c1, ClientModel c2)
        {
            return c1.Equals(c2);
        }
        #endregion

        #region operator !=
        public static bool operator !=(ClientModel c1, ClientModel c2)
        {
            return !c1.Equals(c2);
        } 
        #endregion

        #endregion
    }

    public enum StatusClientModel
    {
        Inactif = 0,
        Active = 1,
    }
}
