using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.UnitOfWorks;

namespace DAL.Repositories {

    public class AccountRepository {

        readonly TddEntities _context;

        public AccountRepository(EntitiesUnitOfWork ctx) {
		    _context = ctx.Entities;
		}

        public Account GetById(int id) {
            return _context.Account.SingleOrDefault(a => a.Id == id);
        } 

    }

}
