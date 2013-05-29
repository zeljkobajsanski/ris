namespace Rs.Dnevnik.Ris.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AgencijskeVesti : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Agencije",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 50),
                        EMail = c.String(nullable: false, maxLength: 50),
                        Default = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "AgencijskeVesti",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DatumPrijema = c.DateTime(nullable: false),
                        Subject = c.String(maxLength: 255),
                        Body = c.String(),
                        AgencijaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Agencije", t => t.AgencijaID, cascadeDelete: true)
                .Index(t => t.AgencijaID);
            
            CreateTable(
                "Konfiguracija",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Server = c.String(),
                        Port = c.Int(nullable: false),
                        Ssl = c.Boolean(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        DownloadInterval = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("AgencijskeVesti", new[] { "AgencijaID" });
            DropForeignKey("AgencijskeVesti", "AgencijaID", "Agencije");
            DropTable("Konfiguracija");
            DropTable("AgencijskeVesti");
            DropTable("Agencije");
        }
    }
}
