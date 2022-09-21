using BankTransaction.Entity;
using BankTransaction.Repository.Interfate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransaction.Repository.Class
{
    public sealed class AccountService : IAccountService
    {
        private List<Amount> _TransactionHistory;
        AccountService()
        {
            _TransactionHistory = new List<Amount>();
        }
        private static readonly object accountServiceLock = new object();
        private static AccountService instance = null;
        public static AccountService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (accountServiceLock)
                    {
                        if (instance == null)
                            instance = new AccountService();
                    }
                }
                return instance;
            }
        }

        public void Deposit(Amount amount)
        {
            _TransactionHistory.Add(amount);
            //Console.WriteLine("Your Deposit is success\n");
        }

        public void Withdraw(Amount amount)
        {
            if (amount.Balance < 0)
                throw new ArgumentOutOfRangeException(nameof(amount.TransactionalAmount), "Can't be greater than Balance");
            else
            {
                _TransactionHistory.Add(amount);
                Console.WriteLine("Your Withdraw is success\n");
            }
        }
        public int GetLastBalance()
        {
            if (_TransactionHistory.Count > 0)
                return _TransactionHistory[_TransactionHistory.Count - 1].Balance;
            else
                return 0;
        }

        public void PrintStatement()
        {
            if (_TransactionHistory.Count > 0)
            {
                Console.WriteLine("Date      || Amount || Balance");
                for (int i = _TransactionHistory.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine("{0} || {1} || {2}",
                        _TransactionHistory[i].TransactionalDate.ToString(),
                        _TransactionHistory[i].TransactionalAmount.ToString(),
                        _TransactionHistory[i].Balance.ToString());
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("Transaction List is Empty");
        }
    }
}
