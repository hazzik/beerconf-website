namespace BeerConf.Migrations
{
    using FluentMigrator;

    [Migration(201108141844)]
    public class Migration201108141844 : Migration
    {
        public override void Up()
        {
            Alter.Table("EVENT").AddColumn("MAX_PLACES").AsInt32().Nullable();
        }

        public override void Down()
        {
            Delete.Column("MAX_PLACES").FromTable("EVENT");
        }
    }
}
