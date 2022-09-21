using BankTransaction.Entity;
using BankTransaction.Manager;
using BankTransaction.Repository.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransaction
{
    public class LetStart
    {
        public void Do()
        {
            //AccountService accountService = new AccountService();
            AccountService accountService = AccountService.Instance;
            PrintOption();
            int givenOperation = Modifier.ConvertStrToInt(Console.ReadLine());
            switch (givenOperation)
            {
                case 1:
                    Amount depositAmount = FulfilTheAmount(1, accountService);
                    accountService.Deposit(depositAmount);
                    Do();
                    break;
                case 2:
                    Amount withdrawAmount = FulfilTheAmount(-1, accountService);
                    accountService.Withdraw(withdrawAmount);
                    Do();
                    break;
                case 3:
                    accountService.PrintStatement();
                    Do();
                    break;
                default:
                    Console.WriteLine("Thanks for your time");
                    break;
            }
        }
        private void PrintOption()
        {
            Console.WriteLine("Enter 1 for deposit");
            Console.WriteLine("Enter 2 for withdrawal");
            Console.WriteLine("Enter 3 for bank statement");
            Console.WriteLine("Enter else exiting the program\n");
        }
        private Amount FulfilTheAmount(int depositWithdrawSign, AccountService accountService)
        {
            Amount amount = new Amount();
            Console.WriteLine("Enter date by 'dd-mm-yyyy' format");
            amount.TransactionalDate = Modifier.ConvertStrToDate(Console.ReadLine());
            Console.WriteLine("Enter Amount");
            amount.TransactionalAmount = Modifier.ConvertStrToInt(Console.ReadLine());
            amount.TransactionalAmount *= depositWithdrawSign;
            amount.Balance = accountService.GetLastBalance() + amount.TransactionalAmount;
            return amount;
        }
    }
}
