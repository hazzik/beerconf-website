namespace BeerConf.Web.Application
{
    using System;

    public static class Maybe
    {
        public static TResult With<T, TResult>(this T self, Func<T, TResult> func) where T : class
        {
            if (self != null)
                return func(self);
            return default(TResult);
        }

        public static TResult With<T, TResult>(this T? self, Func<T, TResult> func) where T : struct
        {
            if (self.HasValue)
                return func(self.Value);
            return default(TResult);
        }
    }
}