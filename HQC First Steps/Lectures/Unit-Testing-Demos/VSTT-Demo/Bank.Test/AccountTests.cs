namespace Bank.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTranferFunds_ToSameAccount_ShouldThrow()
        {
            var account = new Account();
            account.TransferFunds(account, 100);
        }

        [TestMethod]
        public void TestTransferFunds_ToOtherAccount_ShouldTransfer()
        {
            var account = new Account();
            var otherAccount = new Account();
            account.TransferFunds(otherAccount, 200);
        }

        [TestMethod]
        public void TestTransferFunds_ToEmptyAccount_ShouldChangeBalance()
        {
            var account = new Account();
            var otherAccount = new Account();
            account.TransferFunds(otherAccount, 200);
            Assert.AreEqual(200, otherAccount.Balance); 
        }
    }
}
