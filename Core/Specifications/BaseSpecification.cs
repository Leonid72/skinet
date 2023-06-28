using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {}
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } =
                new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDesending { get; private set; }
        public void AddOrderBy(Expression<Func<T, object>> orderByExpression) =>
            OrderBy = orderByExpression;

        public void AddOrderByDesending(Expression<Func<T, object>> orderByDesendingExpression) =>
            OrderByDesending = orderByDesendingExpression;

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; }

        protected void ApplyPaging(int take, int skip)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}