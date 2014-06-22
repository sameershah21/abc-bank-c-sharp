using System;
using System.Collections.Generic;

namespace AbcBank
{
    public class Account
    {

        private readonly AccountType accountType;
        //public List<Transaction> transactions;
        private TransactionList transactions;

        
        /// <summary>
        /// make an object of Account
        /// </summary>
        /// <param name="_type"></param>
        public Account(AccountType _type)
        {
            this.accountType = _type;
            this.transactions = new TransactionList(this);
        }

        /// <summary>
        /// will deposit amount to current account
        /// </summary>
        /// <param name="amount"></param>
        public Transaction deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                // a new transaction should be created to withdraw
                Transaction t = new Deposit(amount);
                // Add the transaction to the transaction list
                this.addTransactionToList(t);

                return t;
            }
        }

        /// <summary>
        /// Withdraws funds from existing account
        /// </summary>
        /// <param name="amount"></param>
        public Transaction withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                // a new transaction should be created to withdraw
                Transaction t = new Withdraw(-amount);
                // Add the transaction to the transaction list
                this.addTransactionToList(t);

                return t;
            }
        }

        /// <summary>
        /// transfer amount from one account to another
        /// </summary>
        /// <param name="_account"></param>
        /// <param name="_amount"></param>
        /// <returns></returns>
        public Transaction transfer(Account _account, double _amount)
        {
            if (_amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            // Create a transaction to transfer from
            Transaction t = new TransferFrom(_account, _amount);
            // Add the transaction to the transaction list
            this.addTransactionToList(t);
            //call function to transfer amount into
            _account.transferInto(this, _amount);

            return t;
        }

        private void addTransactionToList(Transaction _t)
        {
            transactions.add(_t);
        }

        /// <summary>
        /// return a list of all transactions for the account being processed 
        /// </summary>
        /// <returns></returns>
        public TransactionList getTransactionList()
        {
            return transactions;
        }

        private void postTransaction(Transaction _t)
        {
            transactions.add(_t);
        }

        /// <summary>
        /// transfer amount into another account
        /// </summary>
        /// <param name="_fromAccount"></param>
        /// <param name="_amount"></param>
        /// <returns></returns>
        private Transaction transferInto(Account _fromAccount, double _amount)
        {
            if (_amount<=0)
            {
                throw new ArgumentException("amount must be greater than zero"); 
            }

            //Create a transaction to transfer amount into
            Transaction t = new TransferInto(_fromAccount, _amount);
            // Add the transaction to the transaction list
            this.addTransactionToList(t);

            return t;
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
