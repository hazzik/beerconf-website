namespace BeerConf.Web.Infrastructure
{
    using Brandy.Core;
    using Brandy.NHibernate;
    using Castle.Core;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using NHibernate;
    using NHibernateConfigurator = BeerConf.Infrastructure.NHibernate.NHibernateConfigurator;

    public class NHibernateInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof (IRepository<>)).ImplementedBy(typeof (NHibernateRepository<>)).LifeStyle.Transient,
                               Component.For<INHibernateConfigurator>().ImplementedBy<NHibernateConfigurator>(),
                               Component.For<ILinqProvider>().ImplementedBy<NHibernateLinqProvider>().LifeStyle.Transient,
                               Component.For<ISessionProvider>().ImplementedBy<DefaultSessionProvider>().LifeStyle.PerWebRequest);

            container.Register(Component.For<ISessionFactory>()
                                   .UsingFactoryMethod(x => x.Resolve<INHibernateConfigurator>().Configure().BuildSessionFactory())
                                   .LifeStyle.Is(LifestyleType.Singleton));
        }

        #endregion
    }
}
