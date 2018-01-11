using System;
using System.Linq;
using System.Linq.Expressions;

namespace Connector.SDK.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<T> Where<T>(
                this IQueryable<T> source,
                Expression<Func<T, bool>> expression,
                bool use
            )
            where T : class
        {
            if (use)
                return source.Where(expression);
            else
                return source;
        }

        public static IQueryable<T> Where<T>(
                this IQueryable<T> source,
                Expression<Func<T, bool>> expression,
                bool use,
                Expression<Func<T, bool>> or
            )
            where T : class
        {
            if (use)
                return source.Where(expression);
            else
                return source.Where(or);
        }
    }
}