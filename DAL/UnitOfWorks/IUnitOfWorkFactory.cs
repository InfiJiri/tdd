using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.UnitOfWorks {

    public interface IUnitOfWorkFactory {
        EntitiesUnitOfWork CreateUnitOfWork();
    }

}
