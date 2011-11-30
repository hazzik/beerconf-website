namespace BeerConf.Web.Application
{
    using System;
    using System.Linq;

    public static class TypeUtil
    {
        public static Type GetElementTypeOfEnumerable(Type type)
        {
            if (type.HasElementType)
            {
                return type.GetElementType();
            }
            Type iEnumerable = type.GetInterface("IEnumerable`1", true);
            if (iEnumerable != null)
            {
                return iEnumerable.GetGenericArguments().First();
            }
            if (type.IsGenericType)
            {
                return type.GetGenericArguments().First();
            }
            return null;
        }
    }
}