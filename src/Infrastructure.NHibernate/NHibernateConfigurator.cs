namespace BeerConf.Infrastructure.NHibernate
{
    using System;
    using Brandy.Core;
    using Brandy.NHibernate;
    using Brandy.NHibernate.Conventions;
    using Brandy.Security.Entities;
    using Brandy.Security.NHibernate.Overrides;

    using Domain.Entities;
    using FluentNHibernate;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using global::NHibernate.Cfg;

    public class NHibernateConfigurator : INHibernateConfigurator
    {
        public Configuration Configure()
        {
            var db = MsSqlConfiguration.MsSql2008
                .ConnectionString(x => x.FromConnectionStringWithKey("BeerConf"))
                .ShowSql()
                .UseReflectionOptimizer()
                .AdoNetBatchSize(100);

            var autoPersistenceModel = AutoMap.AssemblyOf<User>(new StoreConfiguration())
                .AddMappingsFromAssemblyOf<Event>()
                .Conventions.AddFromAssemblyOf<INHibernateConfigurator>()
                .Conventions.AddFromAssemblyOf<NHibernateConfigurator>()
                .UseOverridesFromAssemblyOf<UserOverride>()
                .UseOverridesFromAssemblyOf<NHibernateConfigurator>();

            return Fluently.Configure()
                .Mappings(x => x.AutoMappings.Add(autoPersistenceModel))
                .ExposeConfiguration(c => c.SetProperty("generate_statistics", "true"))
                .CurrentSessionContext("managed_web")
                .Database(db)
                .BuildConfiguration();
        }

        private class StoreConfiguration : DefaultAutomappingConfiguration
        {
            public override string GetComponentColumnPrefix(Member member)
            {
                return string.Format("{0}_", NameConventions.GetTableName(member.PropertyType));
            }

            public override bool IsComponent(Type type)
            {
                return typeof (Password) == type || base.IsComponent(type);
            }

            public override bool ShouldMap(Type type)
            {
                return typeof (IEntity).IsAssignableFrom(type);
            }

            public override bool IsId(Member member)
            {
                return member.Name == "Id";
            }
        }
    }
}
