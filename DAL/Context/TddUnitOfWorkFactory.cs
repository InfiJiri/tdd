using DAL.Context.Interfaces;
using DAL.Entities;

namespace DAL.Context {

    public class TddUnitOfWorkFactory : IUnitOfWorkFactory {

        public TddUnitOfWork CreateUnitOfWork() {
            return TddUnitOfWork.Get(new TddEntities());
        }


    }

}
