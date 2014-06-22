using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Refactored code - created a seperate class for getting setting TransactionType for typesafety.
//It shall contain all the possible types of transactions a bank shall have. Just like an account type. 
namespace AbcBank
{
    public class TransactionType
    {
        public static readonly TransactionType INITIAL = new TransactionType(-1, "INITIAL");
        public static readonly TransactionType DEPOSIT = new TransactionType(0, "DEPOSIT");
        public static readonly TransactionType ACCT_TRANSFER = new TransactionType(0, "ACCT_TRANSFER"); //declaration like this one will give us
        public static readonly TransactionType INTEREST_ACCURED = new TransactionType(1, "INTEREST_ACCRUED"); //INTEREST ACCRUED implemented as a part of coding enhancement
        public static readonly TransactionType WITHDRAW = new TransactionType(2, "WITHDRAW");
        //as a part of enhancement of intra-transfer between accounts of a customer.
        public static readonly TransactionType TRANSFER_FROM = new TransactionType(3, "TRANSFER_FROM");
        public static readonly TransactionType TRANSFER_INTO = new TransactionType(4, "TRANSFER_INTO");
     
        private int transTypeID;
        private String name;

        public static IEnumerable<TransactionType> Values
        {
            get
            {
                yield return DEPOSIT;
                yield return ACCT_TRANSFER;
                yield return INTEREST_ACCURED;
                yield return WITHDRAW;
                yield return TRANSFER_FROM;
                yield return TRANSFER_INTO;
            } 
        }

        TransactionType(int _value, String _name)
        {
            this.transTypeID = _value;
            this.name = _name;
        }

        /// <summary>
        /// get the corresponding ID of the transaction type
        /// </summary>
        /// <returns></returns>
        public int gettransTypeID()
        {
            return transTypeID;
        }


        /// <summary>
        /// Get Name of the account
        /// </summary>
        /// <returns></returns>
        public String getName()
        {
            return name;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TransactionType: ");
            sb.Append(name).Append('(');
            sb.Append(')');
            return sb.ToString();
        }


    }
}
