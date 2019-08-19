using Curso.Mvc.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Curso.Mvc.Domain.Intefaces
{
    public interface IRepositoryRead<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> ObterTodosPaginado(int s, int t);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
    }


}
