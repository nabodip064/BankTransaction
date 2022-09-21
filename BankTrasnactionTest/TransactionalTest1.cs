using BankTransaction.Entity;
using BankTransaction.Manager;
using BankTransaction.Repository.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTrasnactionTest
{
    public class TransactionalTest1
    {
        [Test]
        public void BalanceUpdateOnDepositTest1()
        {
            AccountService accountService = AccountService.Instance;
            Amount amount = GetAmount("10-01-2012", 1000, accountService);
            accountService.Deposit(amount);
            Assert.AreEqual(1000, accountService.GetLastBalance());
        }
        [Test]
        public void BalanceUpdateOnDepositTest2()
        {
            AccountService accountService = AccountService.Instance;
            Amount amount = GetAmount("13-01-2012", 2000, accountService);
            accountService.Deposit(amount);
            Assert.AreEqual(3000, accountService.GetLastBalance());
        }
        [Test]
        public void BalanceUpdateOnWithdrawTest1()
        {
            AccountService accountService = AccountService.Instance;
            Amount amount = GetAmount("14-01-2012", -500, accountService);
            accountService.Withdraw(amount);
            Assert.AreEqual(2500, accountService.GetLastBalance());
        }
        public static Amount GetAmount(string date, int amt, AccountService accountService)
        {
            Amount amount = new Amount
            {
                TransactionalDate = Modifier.ConvertStrToDate(date),
                TransactionalAmount = amt,
                Balance = accountService.GetLastBalance() + amt
            };
            return amount;
        }
    }
}
