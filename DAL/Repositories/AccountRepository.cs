using System.Linq;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories {

    public class AccountRepository : IAccountRepository {

        readonly TddEntities _context;

        public AccountRepository(TddEntities context) {
            _context = context;
		}

        public Account GetById(int id) {
            return _context.Accounts.SingleOrDefault(a => a.Id == id);
        } 

    }

}
