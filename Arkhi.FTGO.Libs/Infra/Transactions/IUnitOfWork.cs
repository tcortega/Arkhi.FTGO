namespace Arkhi.FTGO.Libs.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}