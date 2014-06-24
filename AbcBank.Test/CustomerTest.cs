using NUnit.Framework;
using System;

namespace AbcBank.Test
{
    [TestFixture]
    public class CustomerTest
    {
        private static readonly double DOUBLE_DELTA = 1e-15;

        [Test] //Test customer statement generation
        public void testApp()
        {

            Account checkingAccount = new Account(AccountType.CHECKING);
            Account savingsAccount = new Account(AccountType.SAVINGS);

            Customer henry = new Customer("Henry").openAccount(checkingAccount).openAccount(savingsAccount);

            checkingAccount.deposit(100.0);
            savingsAccount.deposit(4000.0);
            savingsAccount.withdraw(200.0);

            Assert.AreEqual("Statement for Henry\n" +
                    "\n" +
                    "Checking Account\n" +
                    "  deposit $100.00\n" +
                    "Total $100.00\n" +
                    "\n" +
                    "Savings Account\n" +
                    "  deposit $4,000.00\n" +
                    "  withdrawal $200.00\n" +
                    "Total $3,800.00\n" +
                    "\n" +
                    "Total In All Accounts $3,900.00", henry.getStatement());
        }

        [Test]
        public void testOneAccount()
        {
            Customer oscar = new Customer("Oscar").openAccount(new Account(AccountType.SAVINGS));
            oscar.openAccount(new Account(AccountType.CHECKING));
            Assert.AreEqual(1, oscar.getNumberOfAccounts());
        }

        [Test]
        public void testTwoAccount()
        {
            Customer oscar = new Customer("Oscar")
                    .openAccount(new Account(AccountType.SAVINGS));
            oscar.openAccount(new Account(AccountType.CHECKING));
            Assert.AreEqual(2, oscar.getNumberOfAccounts());
        }

        [Test]
        public void testThreeAcounts()
        {
            Customer oscar = new Customer("Oscar")
                    .openAccount(new Account(AccountType.SAVINGS));
            oscar.openAccount(new Account(AccountType.CHECKING));
            oscar.openAccount(new Account(AccountType.MAXI_SAVINGS));
            Assert.AreEqual(3, oscar.getNumberOfAccounts());
        }

        [Test]
        public void testTransfer()
        {
            Bank bank = new Bank();
            Account checkingAccount = new Account(AccountType.CHECKING);
            Account savingsAccount = new Account(AccountType.SAVINGS);
            Customer bill = new Customer("Bill").openAccount(checkingAccount);
			bill.openAccount(savingsAccount);
			bank.addCustomer(bill);
			savingsAccount.deposit(3000.0);
		    savingsAccount.transfer(checkingAccount, 1000);
            Assert.AreEqual(2000, savingsAccount.getBalance(), DOUBLE_DELTA);
			Assert.AreEqual(1000, checkingAccount.getBalance(), DOUBLE_DELTA);

        }

        [Test]
        public void testMaxiSavingsTestDepositWithdraw1()
        {
           
            Account maxisavingsAccount = new Account(AccountType.MAXI_SAVINGS);
            Customer bill = new Customer("Bill").openAccount(maxisavingsAccount);
            
            maxisavingsAccount.deposit(3000.0);
            maxisavingsAccount.withdraw(2000.0);
            Assert.AreEqual(1000, maxisavingsAccount.getBalance(), DOUBLE_DELTA);
            Assert.AreEqual(1.0, maxisavingsAccount.interestEarned(), DOUBLE_DELTA);
        }

        [Test]
        public void testMaxiSavingsTestDepositWithdraw2()
        {
           
            Account maxisavingsAccount = new Account(AccountType.MAXI_SAVINGS);
            Customer bill = new Customer("Bill").openAccount(maxisavingsAccount);
            
            maxisavingsAccount.deposit(400.0);
            maxisavingsAccount.deposit(300.0);
            maxisavingsAccount.deposit(300.0);
            Assert.AreEqual(1000, maxisavingsAccount.getBalance(), DOUBLE_DELTA);
            Assert.AreEqual(50.0, maxisavingsAccount.interestEarned(), DOUBLE_DELTA);

            maxisavingsAccount.withdraw(300.0);
            Assert.AreEqual(700, maxisavingsAccount.getBalance(), DOUBLE_DELTA);
            Assert.AreEqual(0.7, maxisavingsAccount.interestEarned(), DOUBLE_DELTA);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void testMaxiSavingsTestOverWithdraw()
        {

            Account maxisavingsAccount = new Account(AccountType.MAXI_SAVINGS);
            Customer bill = new Customer("Bill").openAccount(maxisavingsAccount);

            maxisavingsAccount.deposit(400.0);
            maxisavingsAccount.deposit(300.0);
            maxisavingsAccount.deposit(300.0);
            maxisavingsAccount.withdraw(2000.99);
        }
    }
}
