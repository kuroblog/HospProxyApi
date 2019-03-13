using System;
using System.Linq.Expressions;
using System.Reflection;

namespace BinXiangHealth.EMT.Hosp.ProxyApi
{
    public static class PropertySupport
    {
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            return ExtractPropertyNameFromLambda(propertyExpression);
        }

        internal static string ExtractPropertyNameFromLambda(LambdaExpression expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException($"{nameof(expression)} is null.");

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException($"{nameof(expression)} is null.");

            var getMethod = property.GetMethod;
            if (getMethod.IsStatic)
                throw new ArgumentException($"{nameof(expression)} is static.");

            return memberExpression.Member.Name;
        }
    }
}
