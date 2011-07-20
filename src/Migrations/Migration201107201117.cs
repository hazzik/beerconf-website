namespace BeerConf.Migrations
{
	using FluentMigrator;

	[Migration(201107201117)]
	public class Migration201107201117 : Migration
	{
		public override void Up()
		{
			Rename.Column("STARTED_AT").OnTable("EVENT").To("BEGIN");
			Rename.Column("FINISHED_AT").OnTable("EVENT").To("END");
		}

		public override void Down()
		{
			Rename.Column("BEGIN").OnTable("EVENT").To("STARTED_AT");
			Rename.Column("END").OnTable("EVENT").To("FINISHED_AT");
		}
	}
}