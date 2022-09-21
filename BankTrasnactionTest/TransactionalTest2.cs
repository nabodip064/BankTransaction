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
    public class TransactionalTest2
    {
        [Test]
        public void BalanceUpdateOnDepositTest1()
        {
            AccountService accountService = AccountService.Instance;
            Amount amount = TransactionalTest1.GetAmount("10-01-2012", 1000, accountService);
            accountService.Deposit(amount);
            Assert.AreEqual(1000, accountService.GetLastBalance());
        }
        [Test]
        public void BalanceUpdateOnWithdrawTest1()
        {
            AccountService accountService = AccountService.Instance;
            Amount amount = TransactionalTest1.GetAmount("14-01-2012", -2000, accountService);
            Assert.Throws<ArgumentOutOfRangeException>(() => accountService.Withdraw(amount));
        }
    }
}
