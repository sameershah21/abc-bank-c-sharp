using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class Transaction
    {
        public readonly double amount;
        public readonly TransactionType transactionType;

        private DateTime transactionDate;

        public Transaction(double amount, TransactionType _type)
        {
            this.amount = amount;
            this.transactionType = _type;
            this.transactionDate = DateProvider.getInstance().now();
        }

    }
}
