namespace BeerConf.Migrations
{
    using FluentMigrator;

    [Migration(201107211508)]
    public class Migration201107211508 : Migration
    {
        public override void Up()
        {
            Rename.Table("USER").To("USERS");
        }

        public override void Down()
        {
            Rename.Table("USERS").To("USER");
        }
    }
}