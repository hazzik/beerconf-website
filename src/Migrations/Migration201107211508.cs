namespace BeerConf.Migrations
{
    using FluentMigrator;

    [Migration(201107211508)]
    public class Migration201107211508 : AutoReversingMigration
    {
        public override void Up()
        {
            Rename.Table("USER").To("USERS");
        }
    }
}