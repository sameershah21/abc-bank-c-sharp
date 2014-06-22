using System;

namespace AbcBank
{
    public abstract class Transaction
    {
        public readonly double amount=0.00;
        public readonly TransactionType transactionType;

        private DateTime transactionDate;

        // default constructor calling superclass constructor.
        // Private will prevent the ablity to create null transactions.
        // Removes the need to make readonly.
        private Transaction(): base()  
        {

        }

        //non-basic constructor calling base constructor
        protected Transaction(double amount, TransactionType _type): this() 
        {
            this.amount = amount;
            this.transactionType = _type;
            this.transactionDate = DateProvider.getInstance().now();
        }

    }
}
