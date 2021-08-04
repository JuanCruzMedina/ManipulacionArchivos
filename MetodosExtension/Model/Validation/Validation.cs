using MetodosExtension.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.Validation
{
    public static class Validation
    {
        public static IQueryable<T> If<T>(this IQueryable<T> query, bool should, params Func<IQueryable<T>, IQueryable<T>>[] transforms)
        {
            return should
                ? transforms.Aggregate(query,
                    (current, transform) => transform.Invoke(current))
                : query;
        }

        public static IEnumerable<T> If<T>(this IEnumerable<T> query, bool should, params Func<IEnumerable<T>, IEnumerable<T>>[] transforms)
        {
            return should
                ? transforms.Aggregate(query,
                    (current, transform) => transform.Invoke(current))
                : query;
        }

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> query, bool should, Func<T, bool> predicate)
        {
            return query.If(should, q => q.Where(predicate));
        }

        public static IEnumerable<T> ReverseIf<T>(this IEnumerable<T> query, bool should)
        {
            return query.If(should, q => q.Reverse());
        }

        public static IEnumerable<T> TakeIf<T>(this IEnumerable<T> query, bool should, int count)
        {
            return query.If(should, q => q.Take(count));
        }
    }
}
