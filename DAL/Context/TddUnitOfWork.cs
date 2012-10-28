using System;
using DAL.Context.Interfaces;
using DAL.Entities;

namespace DAL.Context {

    public class TddUnitOfWork : IDisposable {

        internal TddEntities Entities { get; set; }

        private TddUnitOfWork() { }

        public static TddUnitOfWork Get(TddEntities entities) {
            var res = new TddUnitOfWork {
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
