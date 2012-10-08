using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Application.Exceptions;
using Application.Services;
using DAL.Entities;
using DAL.Repositories;
using INFITDD.ViewModels;

namespace INFITDD.Controllers {

    public class AccountController : Controller {
        
        public ActionResult Index(int? id) {
            if (!id.HasValue) {
                throw new InvalidParametersException("Geen account id opgegeven");
            }

            var accountService = new AccountService(new AccountRepository(new TddEntities()));

            var account = accountService.GetById(id.Value);

            if (account == null) {
                throw new AccountNotFoundException("Account met id (1) niet gevonden");
            }

            ViewBag.Account = account;

            var viewModel = AccountModel.MapFrom(account);

            return View(viewModel);
        }

    }
}
