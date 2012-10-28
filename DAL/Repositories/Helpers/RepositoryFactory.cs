using System;
using DAL.Context;
using DAL.Context.Interfaces;

namespace DAL.Repositories.Helpers {

    public class RepositoryFactory {

        public static T Create<T>(Type type, TddUnitOfWork unitOfWork) {
            // Hmm, voelt niet heel netjes...
            return (T)Activator.CreateInstance(type, new object[] { unitOfWork });
        }

    }

}
