namespace BeerConf.Web.Infrastructure
{
	using Castle.Core;
	using Castle.MicroKernel.Registration;
	using Castle.MicroKernel.SubSystems.Configuration;
	using Castle.Windsor;
	using Domain.NHibernate;
	using NHibernate;

	public class NHibernateInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<INHibernateConfigurer>().ImplementedBy<NHibernateConfigurer>(),
			                   Component.For<ISessionProvider>().ImplementedBy<SessionProvider>().LifeStyle.PerWebRequest);

			container.Register(Component.For<ISessionFactory>()
			                   	.UsingFactoryMethod(x => x.Resolve<INHibernateConfigurer>().Configure().BuildSessionFactory())
			                   	.LifeStyle.Is(LifestyleType.Singleton));
		}

		#endregion
	}
}
