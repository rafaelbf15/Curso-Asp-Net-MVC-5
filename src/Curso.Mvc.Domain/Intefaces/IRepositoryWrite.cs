using Curso.Mvc.Domain.Models;
using System;

namespace Curso.Mvc.Domain.Intefaces
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(Guid id);
        int SaveChanges();
    }

}
