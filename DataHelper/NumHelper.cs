using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper
{
    public static class NumHelper
    {
        public static long GetDevisNumber()
        {
            DateTime date = DateTime.Now;
            long numero = 0;

            string _sDate = date.Year.ToString() + (date.Month < 10 ? "0" + date.Month.ToString() : date.Month.ToString()) +
                (date.Day < 10 ? "0" + date.Day.ToString() : date.Day.ToString()) +
                (date.Hour < 10 ? "0" + date.Hour.ToString() : date.Hour.ToString()) +
                (date.Minute < 10 ? "0" + date.Minute.ToString() : date.Minute.ToString()) +
                (date.Second < 10 ? "0" + date.Second.ToString() : date.Second.ToString());

            Int64.TryParse(_sDate, out numero);
            return numero;
        }

        public static long GetFactureNumber()
        {
            DateTime date = DateTime.Now;
            long numero = 0;

            string _sDate = date.Year.ToString() + (date.Month < 10 ? "0" + date.Month.ToString() : date.Month.ToString()) +
                (date.Day < 10 ? "0" + date.Day.ToString() : date.Day.ToString()) +
                (date.Hour < 10 ? "0" + date.Hour.ToString() : date.Hour.ToString()) +
                (date.Minute < 10 ? "0" + date.Minute.ToString() : date.Minute.ToString()) +
                (date.Second < 10 ? "0" + date.Second.ToString() : date.Second.ToString());

            Int64.TryParse(_sDate, out numero);
            return numero;
        }
    }
}
