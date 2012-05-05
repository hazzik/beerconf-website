namespace BeerConf.Web.Infrastructure
{
    using Brandy.Core;
    using Brandy.Web.Forms;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class FormsAndQueryInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            var formHandlers = AllTypes.FromAssemblyNamed("BeerConf.Web.Application")
                .BasedOn(typeof (IFormHandler<>))
                .WithService.AllInterfaces()
                .LifestyleTransient();

            container.Register(formHandlers,
                               Component.For<IFormHandlerFactory>().AsFactory());

            var queries = AllTypes.FromAssemblyNamed("BeerConf.Infrastructure.NHibernate")
                .BasedOn(typeof (IQuery<,>))
                .WithService.AllInterfaces()
                .LifestyleTransient();
            
            container.Register(queries,
                               Component.For(typeof(IQueryFor<>)).ImplementedBy(typeof(QueryFor<>)).LifeStyle.Transient,
                               Component.For<IQueryBuilder>().AsFactory(),
                               Component.For<IQueryFactory>().AsFactory());
        }

        #endregion
    }
}
