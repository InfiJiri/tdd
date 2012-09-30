using DAL.Entities;

namespace DAL.UnitOfWorks {

    public class EntityUnitOfWorkFactory : IUnitOfWorkFactory {

        public EntitiesUnitOfWork CreateUnitOfWork() {
            return EntitiesUnitOfWork.Get(new TddEntities());
        }

    }

}
