using DAL.Entities;

namespace DAL.Repositories.Interfaces {

    public interface IAccountRepository : IRepository {

        Account GetById(int id);
        bool TransferMoney(Account sender, Account recipient, int amount);

    }

}
