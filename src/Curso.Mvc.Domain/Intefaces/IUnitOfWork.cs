
namespace Curso.Mvc.Domain.Intefaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void BeginTransaction();
        void Rollback();
        bool SaveChanges();

    }
}
