namespace BeerConf.Migrations
{
    using FluentMigrator;

    [Migration(201107210028)]
    public class Migration201107210028 : Migration
    {
        public override void Up()
        {
            Rename.Column("BEGIN").OnTable("EVENT").To("BEGIN_DATE");
            Rename.Column("END").OnTable("EVENT").To("END_DATE");
        }

        public override void Down()
        {
            Rename.Column("BEGIN_DATE").OnTable("EVENT").To("BEGIN");
            Rename.Column("END_DATE").OnTable("EVENT").To("END");
        }
    }
}