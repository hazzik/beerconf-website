namespace BeerConf.Migrations
{
	using FluentMigrator;

	[Migration(201107201117)]
	public class Migration201107201117 : AutoReversingMigration
	{
		public override void Up()
		{
			Rename.Column("STARTED_AT").OnTable("EVENT").To("BEGIN");
			Rename.Column("FINISHED_AT").OnTable("EVENT").To("END");
		}
	}
}