using BankTransaction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransaction.Repository.Interfate
{
    public interface IAccountService
    {
        void Deposit(Amount amount);
        void Withdraw(Amount amount);
        void PrintStatement();
    }

}
