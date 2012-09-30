using System.Web.Mvc;
using INFITDD.Controllers;
using NUnit.Framework;

namespace INFITDD.Tests.AcceptanceTests {

    [TestFixture]
    public class AccountTests {

        [Test]
        public void Index() {
            var controller = new AccountController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("1234", result.ViewBag.Account.AccountNumber);
        }

    }

}
