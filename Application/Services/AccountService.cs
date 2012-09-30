using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using DAL.Repositories;
using DAL.UnitOfWorks;

namespace Application.Services {

    public class AccountService {

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AccountService(IUnitOfWorkFactory unitOfWorkFactory) {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public Account GetById(int id) {
            using (var uow = _unitOfWorkFactory.CreateUnitOfWork()) {
                var cr = new AccountRepository(uow);
                return cr.GetById(id);
            }
        }

    }
}
