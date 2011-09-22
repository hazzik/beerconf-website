namespace BeerConf.Migrations
{
    using FluentMigrator;

    [Migration(201107211436)]
    public class Migration201107211436 : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("USER")
                .AddColumn("LOGIN").AsString().NotNullable().Unique()
                .AddColumn("E_MAIL").AsString().NotNullable().Unique()
                .AddColumn("IS_ADMIN").AsBoolean().NotNullable().WithDefaultValue(false)
                .AddColumn("PASSWORD_HASH").AsString().NotNullable()
                .AddColumn("PASSWORD_SALT").AsString().NotNullable()
                .AddColumn("NAME").AsString().Nullable();
        }
    }
}
