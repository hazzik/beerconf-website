namespace BeerConf.Migrations
{
    using FluentMigrator;

    [Migration(201107122225)]
    public class Migration201107122225 : Migration
    {
        public override void Up()
        {
            Rename.Table("USERS").To("USER");
            Rename.Table("EVENTS").To("EVENT");
        }

        public override void Down()
        {
            Rename.Table("USER").To("USERS");
            Rename.Table("EVENT").To("EVENTS");
        }
    }
}