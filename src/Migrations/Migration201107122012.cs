namespace BeerConf.Migrations
{
    using FluentMigrator;

    [Migration(201107122012)]
    public class Migration201107122012 : Migration
    {
        public override void Up()
        {
            Create.Table("EVENT_PARTICIPANTS")
                .WithColumn("EVENT_ID").AsInt32().PrimaryKey()
                .WithColumn("USER_ID").AsInt32().PrimaryKey();

            Create.Table("EVENTS")
                .WithColumn("EVENT_ID").AsInt32().PrimaryKey().Identity().References("FK_EVENT_PARTICIPANTS_EVENTS", "EVENT_PARTICIPANTS", new[] {"EVENT_ID"})
                .WithColumn("STARTED_AT").AsDateTime().NotNullable()
                .WithColumn("FINISHED_AT").AsDateTime().NotNullable()
                .WithColumn("PLACE").AsString().NotNullable()
                .WithColumn("NAME").AsString().NotNullable()
                .WithColumn("DESCRIPTION").AsString().NotNullable();

            Create.Table("USERS")
                .WithColumn("USER_ID").AsInt32().PrimaryKey().Identity().References("FK_EVENT_PARTICIPANTS_USERS", "EVENT_PARTICIPANTS", new[] {"USER_ID"});
        }

        public override void Down()
        {
            Delete.Table("EVENT_PARTICIPANTS");
            Delete.Table("EVENTS");
            Delete.Table("USER");
        }
    }
}
