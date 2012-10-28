using System;
using Application.Services.Interfaces;
using DAL.Context;
using DAL.Context.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.Helpers;
using DAL.Repositories.Interfaces;

namespace Application.Services {

    public class AccountService : IAccountService {

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        private readonly Type _accountRepositoryType;
        private readonly IAccountRepository _accountRepository;

        private TddUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IUnitOfWorkFactory unitOfWorkFactory) {
            _accountRepository = accountRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public AccountService(Type accountRepositoryType, IUnitOfWorkFactory unitOfWorkFactory) {
            _accountRepositoryType = accountRepositoryType;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public IAccountRepository AccountRepository {
            get {
                _accountRepository.SetContext(this._unitOfWork);
                return _accountRepository;
            }
        }

        public Account GetById(int id) {
            using (this._unitOfWork = this._unitOfWorkFactory.CreateUnitOfWork()) {
                return AccountRepository.GetById(id);
            }
        }

        public bool TransferMoney(Account sender, Account recipient, int amount) {
            using (this._unitOfWork = this._unitOfWorkFactory.CreateUnitOfWork()) {
                if (AccountRepository.TransferMoney(sender, recipient, amount)) {
                    this._unitOfWork.Commit();
                    return true;
                }
                return false;
            }
         }

    }
}
