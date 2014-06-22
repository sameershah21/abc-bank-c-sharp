using System;
using System.Collections.Generic;

namespace AbcBank
{
    public class Customer
    {
        private String name;
        private List<Account> accounts;

        /// <summary>
        /// Create a customer with name and type of account(a) that he/she would like to open
        /// </summary>
        /// <param name="name"></param>
        public Customer(String name)
        {
            this.name = name;
            this.accounts = new List<Account>();
        }

        /// <summary>
        /// Return the name of the customer
        /// </summary>
        /// <returns></returns>
        public String getName()
        {
            return name;
        }

        /// <summary>
        /// Add one or more account per customer. Will be called multiple times to add multiple accounts.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Customer openAccount(Account account)
        {
            accounts.Add(account);
            return this;
        }

        /// <summary>
        /// Returns how many type accounts does a customer have open with the bank
        /// </summary>
        /// <returns></returns>
        public int getNumberOfAccounts()
        {
            return accounts.Count;
        }

        /// <summary>
        /// Return the Interest earned totally. Its inclusive of all the accounts
        /// </summary>
        /// <returns></returns>
        public double totalInterestEarned()
        {
            double total = 0;
            foreach (Account a in accounts)
                total += a.interestEarned();
            return total;
        }

        /// <summary>
        /// This method will generate statements for all
        /// accounts for a customer and total of all accounts all into one combined statement for a customer
        /// </summary>
        /// <returns></returns>
        public String getStatement()
        {
            //JIRA-123 Change by Joe Bloggs 29/7/1988 start
            String statement = null; //reset statement to null here
            //JIRA-123 Change by Joe Bloggs 29/7/1988 end
            statement = "Statement for " + name + "\n";
            double total = 0.0;
            foreach (Account a in accounts)
            {
                statement += "\n" + statementForAccount(a) + "\n";
                total += a.sumTransactions();
            }
            statement += "\nTotal In All Accounts " + CommonFunctions.toDollars(total);
            return statement;
        }

        /// <summary>
        /// This method will generate statement for a single account opened by a customer
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private String statementForAccount(Account a)
        {
            String s = "";
           
            //Translate to pretty account type
            
            switch (a.getTypeName())
            {
                case "CHECKING":
                    s += "Checking Account\n";
                    break;
                case "SAVINGS":
                    s += "Savings Account\n";
                    break;
                case "MAXI_SAVINGS":
                    s += "Maxi Savings Account\n";
                    break;
            }

            //Now total up all the transactions
            double total = 0.0;
            foreach (Transaction t in a.getTransactionList())
            {
                s += "  " + (t.amount < 0 ? "withdrawal" : "deposit") + " " + CommonFunctions.toDollars(t.amount) + "\n";
                total += t.amount;
            }
            s += "Total " + CommonFunctions.toDollars(total);
            return s;
        }


    }
}
