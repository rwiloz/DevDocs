using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace G3.Core.Utils.LinqExt
{
    public static class QueryHelper
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, string orderBy)
        {
            var ob = "asc";
            if (string.Compare(orderBy, "asc", true) == 0)
            {
                ob = "OrderBy";
            }
            else if (string.Compare(orderBy, "desc", true) == 0)
            {
                ob = "OrderByDescending";
            }
            return ApplyOrder<T>(source, propertyName, ob);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return ApplyOrder<T>(source, propertyName, "OrderBy");
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return ApplyOrder<T>(source, propertyName, "OrderByDescending");
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return ApplyOrder<T>(source, propertyName, "ThenBy");
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return ApplyOrder<T>(source, propertyName, "ThenByDescending");
        }

        static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string propertyName, string methodName)
        {
            string[] props = propertyName.Split('.');
            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (var prop in props)
            {
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> source, string propertyName, string value, bool startWithIfString = false)
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName);
            object o;

            // converting string to property type, by using Parse function
            if (property.PropertyType != typeof(string))
            {
                var parse = property.PropertyType.GetMethod("Parse", new[] { typeof(string) });
                if (parse == null) throw new NotImplementedException(string.Format("Cannot convert string to {0}.", property.PropertyType));
                var parseType = typeof(Func<>).MakeGenericType(property.PropertyType);
                var parseDelegate = Expression.Lambda(parseType, Expression.Call(parse, Expression.Constant(value, typeof(string)))).Compile();
                try { o = parseDelegate.DynamicInvoke(); }
                catch (TargetInvocationException ex) { throw ex.InnerException; }
            }
            else o = value;

            // creating predicate
            var sourceParam = Expression.Parameter(type, "x");
            var propExpr = Expression.Property(sourceParam, propertyName);
            var predicateExpr = (startWithIfString && property.PropertyType == typeof(string)) ?
                (Expression)Expression.Call(propExpr, property.PropertyType.GetMethod("StartsWith", new[] { typeof(string) }), Expression.Constant(o, property.PropertyType)) :
                (Expression)Expression.Equal(propExpr, Expression.Constant(o, property.PropertyType));
            var delegateType = typeof(Func<,>).MakeGenericType(type, typeof(bool));
            var lambda = Expression.Lambda<Func<T, bool>>(predicateExpr, sourceParam);

            return source.Where(lambda);
        }

        public delegate BinaryExpression BinaryExpressionDelegate(Expression left, Expression right);

        public static IQueryable<T> Where<T>(this IQueryable<T> source, string propertyName, string value, QueryHelperBinarySearch searchType)
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName);
            object o;

            // converting string to property type, by using Parse function
            if (property.PropertyType != typeof(string))
            {
                var parse = property.PropertyType.GetMethod("Parse", new[] { typeof(string) });
                if (parse == null) throw new NotImplementedException(string.Format("Cannot convert string to {0}.", property.PropertyType));
                var parseType = typeof(Func<>).MakeGenericType(property.PropertyType);
                var parseDelegate = Expression.Lambda(parseType, Expression.Call(parse, Expression.Constant(value, typeof(string)))).Compile();
                try { o = parseDelegate.DynamicInvoke(); }
                catch (TargetInvocationException ex) { throw ex.InnerException; }
            }
            else o = value;

            // creating predicate
            var sourceParam = Expression.Parameter(type, "x");
            var propExpr = Expression.Property(sourceParam, propertyName);

            MethodInfo binaryExpression = typeof(Expression).GetMethod(searchType.ToString(), BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(Expression), typeof(Expression) }, null);

            var predicateExpr = (Expression)binaryExpression.Invoke(null, new object[] { propExpr, Expression.Constant(o, property.PropertyType) });
            var delegateType = typeof(Func<,>).MakeGenericType(type, typeof(bool));
            var lambda = Expression.Lambda<Func<T, bool>>(predicateExpr, sourceParam);

            return source.Where(lambda);
        }


    }
    public enum QueryHelperBinarySearch
    {
        GreaterThanOrEqual,
        LessThanOrEqual
    }
}
