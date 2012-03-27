namespace BeerConf.Infrastructure.NHibernate.Tests
{
    using NHibernate;
    using Xunit;
    using global::NHibernate.Cfg;
    using global::NHibernate.Tool.hbm2ddl;

    internal class LiveDbDump
    {
        [Fact]
        public void GenerateCreationScript()
        {
            Configuration configuration = new NHibernateConfigurator().Configure();

            new SchemaExport(configuration)
                .SetDelimiter("\r\nGO\r\n")
                .Execute(true, false, false);
        }
    }
}
