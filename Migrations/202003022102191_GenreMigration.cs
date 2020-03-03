namespace ComputerClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
            "dbo.Genres",
            c => new
            {
                Id = c.Int(nullable: false),
                Name = c.String(),
            })
            .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Genres");
        }
    }
}
