namespace DAL.Context.Interfaces {

    public interface IUnitOfWorkFactory {

        TddUnitOfWork CreateUnitOfWork();

    }

}
