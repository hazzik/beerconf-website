namespace BeerConf.Migrations
{
    using FluentMigrator;

    [Migration(201107211436)]
    public class Migration201107211436 : Migration
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

        public override void Down()
        {
            Delete.Column("LOGIN").FromTable("USER");
            Delete.Column("E_MAIL").FromTable("USER");
            Delete.Column("NAME").FromTable("USER");
            Delete.Column("IS_ADMIN").FromTable("USER");
            Delete.Column("PASSWORD_HASH").FromTable("USER");
            Delete.Column("PASSWORD_SALT").FromTable("USER");
        }
    }
}
