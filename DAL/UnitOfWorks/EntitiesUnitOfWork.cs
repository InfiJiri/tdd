using System;
using DAL.Entities;

namespace DAL.UnitOfWorks {

    public class EntitiesUnitOfWork : IDisposable {

        internal TddEntities Entities {
            get;
            set;
        }

        private EntitiesUnitOfWork() {
        }

        public static EntitiesUnitOfWork Get(TddEntities entities) {
            var res = new EntitiesUnitOfWork {
                Entities = entities
            };
            return res;
        }

        public void Dispose() {
            Entities.Dispose();
        }

        public void Commit() {
            Entities.SaveChanges();
        }
    }
}
