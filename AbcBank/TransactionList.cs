using System.Collections;
using System.Collections.Generic;

namespace AbcBank
{
    public class TransactionList : IEnumerable<Transaction>
    {
        Account account;
        List<Transaction> list;
       
        private TransactionList()
        {
            this.list = new List<Transaction>() ;
        }

        public TransactionList(Account _account): this() //call to base constructor
        {
            
            account = _account;
        }
        public  IEnumerator<Transaction> GetEnumerator()
        {
            for (int i = 0; i < list.Count;i++ )
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_t"></param>
        public void add(Transaction _t)
        {
            //TODO: Given extra time and requirements, I can add custom validators
            // or function calls to validate before adding a transaction to list.
            //For eg, account no matches, or checking to see if the transaction is from the same account number
            list.Add(_t);
        }

        
    }
}
