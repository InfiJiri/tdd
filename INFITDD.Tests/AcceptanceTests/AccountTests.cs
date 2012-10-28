using System;
using System.Web.Mvc;
using Application.Services;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using INFITDD.Controllers;
using INFITDD.Tests.Helpers;
using NUnit.Framework;

namespace INFITDD.Tests.AcceptanceTests {

    [TestFixture]
    public class AccountTests {

        protected TddEntities EntitiesContext;

        protected AccountRepository AccountRepository {
            get {
                return new AccountRepository();
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
        public void IndexActionLoadsCorrectAccount() {
            var account = CreateAccount("1234");

            var controller = new AccountController(new AccountService(new AccountRepository(), new TddUnitOfWorkFactory()));

            var result = controller.Index(account.Id) as ViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("1234", result.ViewBag.Account.AccountNumber);
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
