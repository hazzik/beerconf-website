namespace BeerConf.Domain.Entities
{
    using Brandy.Core;

    public class User : IEntity
    {
        public virtual string Name { get; set; }

        public virtual string Login { get; set; }

        public virtual string EMail { get; set; }

        public virtual Password Password { get; private set; }

        public virtual bool IsAdmin { get; set; }

        #region IEntity Members

        public virtual int Id { get; set; }

        #endregion

        public virtual void SetPassword(string newPassword)
        {
            Password = new Password(newPassword);
        }
    }
}
