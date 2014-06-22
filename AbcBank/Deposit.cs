using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class Deposit : Transaction
    {
        /// <summary>
        /// New Transaction for Deposit. Inherits from Super class Transaction
        /// </summary>
        /// <param name="_amount"></param>
        public Deposit(double _amount): base(_amount, TransactionType.DEPOSIT) 
        {
        
        }

    }
}
