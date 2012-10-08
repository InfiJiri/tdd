using DAL.Entities;

namespace INFITDD.Tests.Helpers {

    public class DatabaseCleaner {

        public static void Clean() {
            var context = new TddEntities();
            context.Database.ExecuteSqlCommand("DELETE FROM Account");
            context.Database.ExecuteSqlCommand("DELETE FROM [Transaction]");
        }

    }

}
