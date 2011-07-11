namespace BeerConf.Migrations
{
    using System.Configuration;
    using FluentMigrator.Runner.Announcers;
    using FluentMigrator.Runner.Initialization;

    public class MigrationsRunner
    {
        public static void Run()
        {
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["BeerConf"];
            var runnerContext = new RunnerContext(new NullAnnouncer())
                                    {
                                        Database = "sqlserver",
                                        Connection = connectionString.ConnectionString,
                                        Target = typeof(MigrationsRunner).Assembly.FullName,
                                    };
            new TaskExecutor(runnerContext).Execute();
        }
    }
}
