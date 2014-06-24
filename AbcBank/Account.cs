using System;
using System.Collections.Generic;
using System.Globalization;

namespace AbcBank
{
    public class Account
    {

        private readonly AccountType accountType;
        private TransactionList transactions;
        private double balance;

        // for maxi savings account enahncements, to check if 
        DateTime withdrawDate;



        
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
                // a new transaction should be created to deposit
                Transaction t = new Deposit(amount);
                // Add the transaction to the transaction list
                this.addIndividualTransaction(t);

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
                this.addIndividualTransaction(t);
                //note the withdraw date so that maxi savings can be checked on a previous withdraw, if present 
                withdrawDate = t.transactionDate;
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
            Transaction t = new TransferFrom(_account, -_amount);

            //Add individual transaction
            this.addIndividualTransaction(t);
            //call function to transfer amount into
            _account.transferInto(this, +_amount);

            return t;
        }

        /// <summary>
        /// return a list of all transactions for the account being processed 
        /// </summary>
        /// <returns></returns>
        public TransactionList getTransactionList()
        {
            return transactions;
        }

        /// <summary>
        /// Just adds a single transaction to the list and updates the account balance
        /// </summary>
        /// <param name="_t"></param>
        private void addIndividualTransaction(Transaction _t)
        {
            transactions.add(_t);
            //transaction will have the remaining balance AFTER the transaction took place
            this.balance = _t.amount;
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
            this.addIndividualTransaction(t);

            return t;
        }

        /// <summary>
        /// Interest on balance based on type of account
        /// </summary>
        /// <returns></returns>
        public double interestEarned()
        {
            //Store variables
            double interest = 0.00;
            double calcRate = 0.00;
            double balance = getBalance();
            double initalInterestRate = 0.001;
            double OverThousandInterestRate = 0.002;
            double conditionalMaxSaveInterestRate =0.05;
            double amount = sumTransactions();
            //increased a little code readablity over here.
            //Added enhancements code for maxisavings
            if(this.accountType.getName()== "SAVINGS")
            { 
                    if (amount <= 1000)
                        interest = amount * initalInterestRate;
                    else
                        interest =  1000 * initalInterestRate + (amount - 1000) * OverThousandInterestRate ;
            }
            if (this.accountType.getName() == "CHECKING")
            {
                    interest = amount * initalInterestRate;
            }
            if(this.accountType.getName()== "MAXI_SAVINGS")
            {
                //if withdrawdate is null
                if (withdrawDate == DateTime.MinValue)
                {
                    calcRate = conditionalMaxSaveInterestRate;
                }
                else
                {
                    TimeSpan duration = CommonFunctions.now()-withdrawDate;
                    if (duration.Days>=10)
                    {
                        calcRate = conditionalMaxSaveInterestRate;
                    }
                    else
                    {
                        calcRate = OverThousandInterestRate;
                    }
                }
                interest = balance * calcRate;
                  
            }
            return interest;
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

        public double getBalance()
        {
            return this.balance;
        }
    }
}
