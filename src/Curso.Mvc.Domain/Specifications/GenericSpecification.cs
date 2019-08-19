﻿using Curso.Mvc.Domain.Models;
using DomainValidation.Interfaces.Specification;
using System;
using System.Linq.Expressions;

namespace Curso.Mvc.Domain.Specifications
{
    public class GenericSpecification<T> : ISpecification<T> where T : Entity
    {
        public Expression<Func<T, bool>> Expression { get; }

        public GenericSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return Expression.Compile().Invoke(entity);
        }
    }
}
