namespace BeerConf.Domain.NHibernate
{
    using System;
    using Brandy.Core;
    using Brandy.NHibernate;
    using Entities;
    using FluentNHibernate;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using global::NHibernate.Cfg;

    public class NHibernateConfigurator : INHibernateConfigurator
    {
        #region INHibernateConfigurator Members

        public Configuration Configure()
        {
            MsSqlConfiguration db = MsSqlConfiguration.MsSql2008
                .ConnectionString(x => x.FromConnectionStringWithKey("BeerConf"))
                .ShowSql()
                .UseReflectionOptimizer()
                .AdoNetBatchSize(100);

            var automappingConfiguration = new StoreConfiguration();

            return Fluently.Configure()
                .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<User>(automappingConfiguration)
                                                      .Conventions.AddFromAssemblyOf<INHibernateConfigurator>()
                                                      .Conventions.AddFromAssemblyOf<NHibernateConfigurator>()
                                                      .UseOverridesFromAssemblyOf<NHibernateConfigurator>()
                                   ))
                .ExposeConfiguration(c => c.SetProperty("generate_statistics", "true")
                                              .SetProperty("adonet.batch_size", "100"))
                .CurrentSessionContext("managed_web")
                .Database(db)
                .BuildConfiguration();
        }

        #endregion

        #region Nested type: StoreConfiguration

        private class StoreConfiguration : DefaultAutomappingConfiguration
        {
            public override bool ShouldMap(Type type)
            {
                return typeof (IEntity).IsAssignableFrom(type);
            }

            public override bool IsId(Member member)
            {
                return member.Name == "Id";
            }
        }

        #endregion
    }
}
