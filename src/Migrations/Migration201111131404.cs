namespace BeerConf.Migrations
{
    using FluentMigrator;

    [Migration(201111131404)]
    public class Migration201111131404 : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("hibernate_unique_key")
                .WithColumn("next_hi").AsInt32().PrimaryKey().NotNullable();
            Insert.IntoTable("hibernate_unique_key").Row(new { next_hi = 0 });
        }
    }
}