using System;
using System.Linq;
using DAL.Context;
using DAL.Context.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories {

    public class AccountRepository : IAccountRepository {

        private TddEntities _context;

        public AccountRepository() { }

        public AccountRepository(TddUnitOfWork unitOfWork) {
            this._context = unitOfWork.Entities;
        }

        public void SetContext(TddUnitOfWork unitOfWork) {
            this._context = unitOfWork.Entities;
        }

        public Account GetById(int id) {
            return _context.Accounts.SingleOrDefault(a => a.Id == id);
        }

        public bool TransferMoney(Account sender, Account recipient, int amount) {
            sender.Balance    -= amount;
            recipient.Balance += amount;
            return true;
        }

    }

}
