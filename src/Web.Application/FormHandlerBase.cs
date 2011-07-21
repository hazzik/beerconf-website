namespace BeerConf.Web.Application
{
    using Brandy.Core;
    using Brandy.Web.Forms;

    public abstract class FormHandlerBase<T> : IFormHandler<T> where T : IForm
    {
        public IQueryBuilder Query { get; set; }

        #region IFormHandler<T> Members

        public abstract void Handle(T form);

        #endregion
    }
}