using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransaction.Manager
{
    public class Modifier
    {
        public static int ConvertStrToInt(string? str)
        {
            int result = 0;
            Int32.TryParse(str, out result);
            return result;
        }
        public static DateOnly ConvertStrToDate(string? str)
        {
            DateOnly result = DateOnly.MinValue;
            DateOnly.TryParse(str, out result);
            return result;
        }
    }
}
