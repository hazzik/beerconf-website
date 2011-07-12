namespace Domain.NHibernate.Tests
{
    using System.IO;
    using BeerConf.Domain.NHibernate;
    using Xunit;
    using global::NHibernate.Cfg;
    using global::NHibernate.Tool.hbm2ddl;

    internal class LiveDbDump
    {
        [Fact]
        public void GenerateCreationScript()
        {
            Configuration configuration = new NHibernateConfigurer().Configure();
            var exportOutput = new StringWriter();
            new SchemaExport(configuration)
                .SetDelimiter("\r\nGO\r\n")
                .Execute(true, false, false);
        }
    }
}
