using System;
using Application.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace Application.Services {

    public class AccountService : IAccountService {

        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository) {
            _accountRepository = accountRepository;
        }

        public Account GetById(int id) {
            return _accountRepository.GetById(id);
        }

        public bool TransferMoney(Account sender, Account recipient, int amount) {
            throw new NotImplementedException();
        }
    }
}
