namespace BeerConf.Web.Infrastructure
{
    using Brandy.Web.Forms;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class FormsInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            BasedOnDescriptor formHandlers = AllTypes.FromAssemblyNamed("BeerConf.Web.Application")
                .BasedOn(typeof (IFormHandler<>))
                .WithService.AllInterfaces()
                .Configure(x => x.LifeStyle.Transient);

            container.Register(formHandlers,
                               Component.For<IFormHandlerFactory>().AsFactory());
        }

        #endregion
    }
}
