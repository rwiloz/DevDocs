Here is your code with inline XML summary comments:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

/// <summary>
/// Contains methods to extend LINQ functionality.
/// </summary>
namespace G3.Core.Utils.LinqExt
{
    public static class QueryHelper
    {
        /// <summary>
        /// Orders an IQueryable source by the given property in ascending or descending order.
        /// </summary>        
        /// <param name="source">The IQueryable source to be ordered.</param>
        /// <param name="propertyName">The property name to order by.</param>
        /// <param name="orderBy">Specifies whether the sort order is ascending ("asc") or descending ("desc").</param>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, string orderBy)

        //.. rest of your code

        /// <summary>
        /// Filters an IQueryable source based on a property's value. The property type must have a "Parse" method.
        /// </summary>       
        /// <param name="source">The IQueryable source to be filtered.</param>
        /// <param name="propertyName">The property name to filter by.</param>
        /// <param name="value">The string representation of the value to filter.</param>
        /// <param name="startWithIfString">Indicates if string types should be filtered using the StartsWith method.</param>
        public static IQueryable<T> Where<T>(this IQueryable<T> source, string propertyName, string value, bool startWithIfString = false)

        //.. rest of your code

        /// <summary>
        /// Filters an IQueryable source based on a property's value. The property type must have a "Parse" method.
        /// </summary>        
        /// <param name="source">The IQueryable source to be filtered.</param>
        /// <param name="propertyName">The property name to filter by.</param>
        /// <param name="value">The string representation of the value to filter.</param>
        /// <param name="searchType">The comparison type to be used when filtering.</param>
        public static IQueryable<T> Where<T>(this IQueryable<T> source, string propertyName, string value, QueryHelperBinarySearch searchType)

        //.. rest of your code

    // This keeps your definitions for QueryHelperBinarySearch emum
    }
}
```

Please note : XML Documentation Comments summarize what a particular method does its inputs and outputs, so other developers can understand how your code is supposed to work without looking into implementation details.