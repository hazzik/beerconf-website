namespace BeerConf.Domain.NHibernate
{
    using System;
    using FluentNHibernate;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using global::Domain;
    using global::NHibernate.Cfg;

    public class NHibernateConfigurer : INHibernateConfigurer
    {
        public Configuration Configure()
        {
            MsSqlConfiguration db = MsSqlConfiguration.MsSql2008
                .ConnectionString(x => x.FromConnectionStringWithKey("BeerConf"))
                .ShowSql()
                .UseReflectionOptimizer()
                .AdoNetBatchSize(100);

            var automappingConfiguration = new StoreConfiguration();

            return Fluently.Configure()
                .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<IEntity>(automappingConfiguration)
                                                      .Conventions.AddFromAssemblyOf<NHibernateConfigurer>()
                                                      .UseOverridesFromAssemblyOf<NHibernateConfigurer>()
                                   ))
                .ExposeConfiguration(c => c.SetProperty("generate_statistics", "true")
                                              .SetProperty("adonet.batch_size", "100"))
                .CurrentSessionContext("managed_web")
                .Database(db)
                .BuildConfiguration();
        }

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
