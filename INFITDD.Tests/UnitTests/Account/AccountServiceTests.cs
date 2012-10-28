using System;
using Application.Services;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using INFITDD.Tests.Helpers;
using NUnit.Framework;

namespace INFITDD.Tests.UnitTests {

    [TestFixture]
    public class AccountServiceTests {

        [TestFixtureSetUp]
        public void Init() {
            DatabaseCleaner.Clean();
        }

        [TestFixtureTearDown]
        public void Clean() {
        }

        [Test]
        public void TransferMoneyTest() {
            var account1 = CreateAccount("1234");
            var account2 = CreateAccount("5678");

            var accountService = new AccountService(new AccountRepository(), new TddUnitOfWorkFactory());

            var success = accountService.TransferMoney(account1, account2, 170000);

            Assert.IsTrue(success);
            Assert.IsTrue(account1.Balance == -170000);
            Assert.IsTrue(account2.Balance == 170000);
        }

        private Account CreateAccount(string accountNumber) {
            var account = new Account();

            account.AccountNumber = accountNumber;
            account.Created = DateTime.Now;

            return account;
        }

    }

}
