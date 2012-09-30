using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using DAL.Entities;

namespace INFITDD.ViewModels {

    public class AccountModel {

        public int      Id            { get; set; }
        public string   AccountNumber { get; set; }
        public DateTime Created       { get; set; }

        public static AccountModel MapFrom(Account account) {
            var accountModel = new AccountModel();

            accountModel.Id            = account.Id;
            accountModel.AccountNumber = account.AccountNumber;
            accountModel.Created       = account.Created;

            return accountModel;
        }

    }
}
