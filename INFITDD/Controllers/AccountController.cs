using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Application.Services;
using DAL.UnitOfWorks;
using INFITDD.ViewModels;

namespace INFITDD.Controllers {

    public class AccountController : Controller {
        
        public ActionResult Index() {

            var accountService = new AccountService(new EntityUnitOfWorkFactory());

            var account = accountService.GetById(1);

            ViewBag.Account = account;

            var viewModel = AccountModel.MapFrom(account);

            return View(viewModel);
        }

    }
}
