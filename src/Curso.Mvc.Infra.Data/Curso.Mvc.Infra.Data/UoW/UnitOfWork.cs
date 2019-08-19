using Curso.Mvc.Domain.Intefaces;
using Curso.Mvc.Infra.Data.Context;


namespace Curso.Mvc.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CursoMvcEssencialContext _context;

        public UnitOfWork(CursoMvcEssencialContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _context.Database.CurrentTransaction.Rollback();
        }

        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
