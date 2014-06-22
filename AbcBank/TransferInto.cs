
namespace AbcBank
{
    public class TransferInto : Transaction
    {
        protected Account destinationAccount;

        /// <summary>
        /// Get destination account to transfer into
        /// </summary>
        /// <returns></returns>
        public Account getdestinationAccount()
        {
            return destinationAccount;
        }

        /// <summary>
        /// New Transaction for Transferring Into.  
        /// Inherits from Super class Transaction.
        /// </summary>
        /// <param name="_fromAccount"></param>
        /// <param name="_amount"></param>
        public TransferInto(Account _intoAccount, double _amount): base(_amount, TransactionType.TRANSFER_FROM) 
        {
            this.destinationAccount = _intoAccount;
        }
    }
}
