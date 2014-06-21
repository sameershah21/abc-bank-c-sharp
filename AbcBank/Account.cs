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
                transactions.Add(new Transaction(amount));
            }
        }

        public void withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                transactions.Add(new Transaction(-amount));
            }
        }

        public double interestEarned()
        {
            double amount = sumTransactions();
            if(this.accountType.getName()== "SAVINGS")
            //switch(this.accountType())
            {
              //  case SAVINGS  :
                    if (amount <= 1000)
                        return amount * 0.001;
                    else
                        return 1 + (amount - 1000) * 0.002;
                // case SUPER_SAVINGS:
                //     if (amount <= 4000)
            }    //         return 20;
            if(this.accountType.getName()== "MAXI_SAVINGS")
            {//case "MAXI_SAVINGS":
                    if (amount <= 1000)
                        return amount * 0.02;
                    if (amount <= 2000)
                        return 20 + (amount - 1000) * 0.05;
                 return 70 + (amount - 2000) * 0.1;
            }
            else
                //default:
                    return amount * 0.001;
         }
        

        public double sumTransactions()
        {
            double amount = 0.0;
            foreach (Transaction t in transactions)
                amount += t.amount;
            return amount;
        }

        public AccountType getType()
        {
            return accountType;
        }

        public string getTypeName()
        {
            return accountType.getName();
        }
    }
}
