using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class Account
    {

        private readonly AccountType accountType;
        public List<Transaction> transactions;

        /// <summary>
        /// make an object of Account
        /// </summary>
        /// <param name="_type"></param>
        public Account(AccountType _type)
        {
            this.accountType = _type;
            this.transactions = new List<Transaction>();
        }

        /// <summary>
        /// will deposit amount to current account
        /// </summary>
        /// <param name="amount"></param>
        public void deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                //a new transaction should be created to deposit
                transactions.Add(new Transaction(amount, TransactionType.DEPOSIT));
            }
        }

        /// <summary>
        /// Withdraws funds from existing account
        /// </summary>
        /// <param name="amount"></param>
        public void withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                // a new transaction should be created to withdraw
                transactions.Add(new Transaction(-amount, TransactionType.WITHDRAW));
            }
        }

        /// <summary>
        /// Interest on balance based on type of account
        /// </summary>
        /// <returns></returns>
        public double interestEarned()
        {
            double amount = sumTransactions();
            if(this.accountType.getName()== "SAVINGS")
            { 
                    if (amount <= 1000)
                        return amount * 0.001;
                    else
                        return 1 + (amount - 1000) * 0.002;
            } 
            if(this.accountType.getName()== "MAXI_SAVINGS")
            {
                    if (amount <= 1000)
                        return amount * 0.02;
                    if (amount <= 2000)
                        return 20 + (amount - 1000) * 0.05;
                 return 70 + (amount - 2000) * 0.1;
            }
            else
                    return amount * 0.001;
         }
        
        /// <summary>
        /// Calculate total of all transactions
        /// </summary>
        /// <returns></returns>
        public double sumTransactions()
        {
            double amount = 0.0;
            foreach (Transaction t in transactions)
                amount += t.amount;
            return amount;
        }

        /// <summary>
        /// Returns the type of Account
        /// </summary>
        /// <returns></returns>
        public AccountType getType()
        {
            return accountType;
        }

        /// <summary>
        /// Returns the type name of the account
        /// </summary>
        /// <returns></returns>
        public string getTypeName()
        {
            return accountType.getName();
        }
    }
}
