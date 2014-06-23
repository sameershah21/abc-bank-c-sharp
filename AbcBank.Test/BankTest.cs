using NUnit.Framework;

namespace AbcBank.Test
{
    [TestFixture]
    public class BankTest
    {
        private static readonly double DOUBLE_DELTA = 1e-15;

        [Test]
        public void customerSummary()
        {
            Bank bank = new Bank();
            Customer john = new Customer("John");
            john.openAccount(new Account(AccountType.CHECKING));
            bank.addCustomer(john);

            Assert.AreEqual("Customer Summary\n - John (1 account)", bank.customerSummary());
        }

        [Test]
        public void checkingAccount()
        {
            Bank bank = new Bank();
            Account checkingAccount = new Account(AccountType.CHECKING);
            Customer bill = new Customer("Bill").openAccount(checkingAccount);
            bank.addCustomer(bill);

            checkingAccount.deposit(100.0);

            Assert.AreEqual(0.1, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void savings_account()
        {
            Bank bank = new Bank();
            Account checkingAccount = new Account(AccountType.SAVINGS);
            bank.addCustomer(new Customer("Bill").openAccount(checkingAccount));

            checkingAccount.deposit(1500.0);

            Assert.AreEqual(2.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void maxi_savings_account()
        {
            Bank bank = new Bank();
            Account maxiSavingsAccount = new Account(AccountType.MAXI_SAVINGS);
            bank.addCustomer(new Customer("Bill").openAccount(maxiSavingsAccount));

            maxiSavingsAccount.deposit(3000.0);

            Assert.AreEqual(170.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void acctTransferTest()
        {
            Bank bank = new Bank();
            Account checkingAccount = new Account(AccountType.CHECKING);
            Account savingsAccount = new Account(AccountType.SAVINGS);
            Customer bill = new Customer("Bill");
            bill.openAccount(savingsAccount);
            bank.addCustomer(bill);

            savingsAccount.deposit(50000.32);
            savingsAccount.transfer(checkingAccount, 2000.99);
            Assert.AreEqual(47999.33, savingsAccount.getBalance(), DOUBLE_DELTA);
            Assert.AreEqual(2000.99, checkingAccount.getBalance(), DOUBLE_DELTA);

        }

    }
}







