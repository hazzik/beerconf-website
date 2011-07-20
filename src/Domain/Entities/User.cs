namespace BeerConf.Domain.Entities
{
    using Brandy.Core;

    public class User : IEntity
    {
        public virtual string Name { get; set; }

        #region IEntity Members

        public virtual int Id { get; set; }

        #endregion
    }
}