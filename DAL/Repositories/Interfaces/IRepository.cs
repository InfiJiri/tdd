using DAL.Context;
using DAL.Entities;

namespace DAL.Repositories.Interfaces {

    public interface IRepository {

        void SetContext(TddUnitOfWork unitOfWork);

    }

}
