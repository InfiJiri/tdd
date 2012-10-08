using System;
using Application.Services;
using DAL.Entities;
using DAL.Repositories;
using INFITDD.Tests.Helpers;
using NUnit.Framework;

namespace INFITDD.Tests.UnitTests {

    [TestFixture]
    public class AccountServiceTests {

        protected TddEntities EntitiesContext;

        protected AccountRepository AccountRepository {
            get {
                return new AccountRepository(EntitiesContext);
            }
        }

        protected TddEntities GetContext() {
            return new TddEntities();
        }

        [TestFixtureSetUp]
        public void Init() {
            DatabaseCleaner.Clean();
            EntitiesContext = GetContext();
        }

        [TestFixtureTearDown]
        public void Clean() {
            EntitiesContext.Dispose();
        }

        [Test]
        public void TransferMoneyTest() {
            var account1 = CreateAccount("1234");
            var account2 = CreateAccount("5678");

            var accountService = new AccountService(AccountRepository);

            var success = accountService.TransferMoney(account1, account2, 170000);

            Assert.IsTrue(success);
            Assert.IsTrue(account1.Balance == -170000);
            Assert.IsTrue(account2.Balance == 170000);
        }

        private Account CreateAccount(string accountNumber) {
            var account = new Account();

            account.AccountNumber = accountNumber;
            account.Created = DateTime.Now;

            EntitiesContext.Accounts.Add(account);
            EntitiesContext.SaveChanges();

            Assert.IsTrue(account.Id != 0, "Account kon niet worden aangemaakt");

            return account;
        }

    }

}
