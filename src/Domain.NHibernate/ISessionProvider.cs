namespace BeerConf.Domain.NHibernate
{
    using System;
    using global::NHibernate;

    public interface ISessionProvider : IDisposable
	{
		ISession CurrentSession { get; }
		void PreventCommit();
	}
}
