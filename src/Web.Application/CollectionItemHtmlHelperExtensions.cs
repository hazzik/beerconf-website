namespace BeerConf.Web.Application
{
    using System;
    using System.Globalization;
    using System.Web.Mvc;

    public static class CollectionItemHtmlHelperExtensions
    {
        public static IDisposable CollectionItem(this HtmlHelper html, object index)
        {
            return new CollectionItemScope(html.ViewData.TemplateInfo, index);
        }

        #region Nested type: CollectionItemScope

        private class CollectionItemScope : IDisposable
        {
            private readonly string oldPrefix;
            private readonly TemplateInfo templateInfo;

            public CollectionItemScope(TemplateInfo templateInfo, object index)
            {
                this.templateInfo = templateInfo;
                oldPrefix = templateInfo.HtmlFieldPrefix;
                templateInfo.HtmlFieldPrefix = string.Format(CultureInfo.InvariantCulture, "{0}[{1}]", oldPrefix, index);
            }

            #region IDisposable Members

            public void Dispose()
            {
                templateInfo.HtmlFieldPrefix = oldPrefix;
            }

            #endregion
        }

        #endregion
    }
}
