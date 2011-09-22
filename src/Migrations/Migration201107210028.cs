namespace BeerConf.Migrations
{
    using FluentMigrator;

    [Migration(201107210028)]
    public class Migration201107210028 : AutoReversingMigration
    {
        public override void Up()
        {
            Rename.Column("BEGIN").OnTable("EVENT").To("BEGIN_DATE");
            Rename.Column("END").OnTable("EVENT").To("END_DATE");
        }
    }
}