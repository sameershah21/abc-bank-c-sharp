
namespace AbcBank
{
    public class TransferFrom : Transaction
    {
        protected Account sourceAccount;

        /// <summary>
        /// Get Source account to transfer from
        /// </summary>
        /// <returns></returns>
        public Account getSourceAccount()
        {
            return sourceAccount;
        }

        /// <summary>
        /// New Transaction for Transferring From.  
        /// Inherits from Super class Transaction.
        /// </summary>
        /// <param name="_fromAccount"></param>
        /// <param name="_amount"></param>
        public TransferFrom(Account _fromAccount, double _amount): base(_amount, TransactionType.TRANSFER_FROM) 
        {
            this.sourceAccount = _fromAccount;
        }
    }
}
