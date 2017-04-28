namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {

            Sql("Insert into genres (ID, Name) values (1,'Jazz')");
            Sql("Insert into genres (ID, Name) values (2,'Blues')");
            Sql("Insert into genres (ID, Name) values (3,'Whites')");
            Sql("Insert into genres (ID, Name) values (4,'Pinks')");

        }

        public override void Down()
        {

            Sql("Delete from genres where ID in (1,2,3,4)");



        }
    }
}
