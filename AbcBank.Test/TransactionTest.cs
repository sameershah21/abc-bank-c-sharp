using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank.Test
{
    [TestFixture]
    public class TransactionTest
    {
        [Test]
        public void transaction()
        {
            Account acct = new Account(AccountType.CHECKING);
            Transaction t = new Deposit(5);
            Assert.AreEqual(true, t is Transaction);
        }
    }
}
