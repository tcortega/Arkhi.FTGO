using Microsoft.EntityFrameworkCore;

namespace Arkhi.FTGO.Libs.Infra.Transactions
{
    public class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        private readonly T _context;

        public UnitOfWork(T context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        //TODO: Implement
        public void Rollback()
        {
        }
    }
}