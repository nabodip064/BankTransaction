using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransaction.Entity
{
    public class Amount
    {
        public DateOnly TransactionalDate { get; set; }
        public int TransactionalAmount { get; set; }
        public int Balance { get; set; }

    }
}
