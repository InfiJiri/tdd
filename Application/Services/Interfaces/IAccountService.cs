using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace Application.Services.Interfaces {

    public interface IAccountService {

        Account GetById(int id);

        bool TransferMoney(Account sender, Account recipient, int amount);

    }
}
