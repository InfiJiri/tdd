using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Application.Exceptions;
using Application.Services;
using Application.Services.Interfaces;
using DAL.Context;
using DAL.Context.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using INFITDD.ViewModels;

namespace INFITDD.Controllers {

    public class AccountController : Controller {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService) {
            _accountService = accountService;
        }
        
        public ActionResult Index(int? id) {
            if (!id.HasValue) {
                throw new InvalidParametersException("Geen account id opgegeven");
            }

            var account = _accountService.GetById(id.Value);

            if (account == null) {
                throw new AccountNotFoundException("Account met id (1) niet gevonden");
            }

            ViewBag.Account = account;

            var viewModel = AccountModel.MapFrom(account);

            return View(viewModel);
        }

    }
}
