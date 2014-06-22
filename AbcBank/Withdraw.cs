
namespace AbcBank
{
    public class Withdraw: Transaction
    {
         /// <summary>
        /// New Transaction for Withdraw. Inherits from Super class Transaction
        /// </summary>
        /// <param name="_amount"></param>
        public Withdraw(double _amount): base(_amount, TransactionType.DEPOSIT) 
        {
        
        }
    }
}
