using System;
using System.Collections.Generic;
using System.Text;

//Refactored code - created a seperate class for getting setting AccountType for typesafety
namespace AbcBank
{
    public class AccountType
    {
        public static readonly AccountType CHECKING = new AccountType(0, "CHECKING"); //declaration like this one will give us
        public static readonly AccountType SAVINGS = new AccountType(1, "SAVINGS");
        public static readonly AccountType MAXI_SAVINGS = new AccountType(2, "MAXI_SAVINGS");
        private int acctTypeID;
        private String name;

        public static IEnumerable<AccountType> Values
        {
            get
            {
                yield return CHECKING;
                yield return SAVINGS;
                yield return MAXI_SAVINGS;
            } 
        }

        AccountType(int _value, String _name)
        {
            this.acctTypeID = _value;
            this.name = _name;
        }

        public int getacctTypeID()
        {
            return acctTypeID;
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
           sb.Append("AccountType: ");
           sb.Append(name).Append('(');
           sb.Append(')');
           return sb.ToString();
        }
    }
}
