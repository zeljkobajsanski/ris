namespace Rs.Dnevnik.Ris.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "NovinskeKuce",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Sektori",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 50),
                        NovinskaKucaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("NovinskeKuce", t => t.NovinskaKucaID, cascadeDelete: true)
                .Index(t => t.NovinskaKucaID);
            
            CreateTable(
                "Odeljanja",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 50),
                        SektorID = c.Int(nullable: false),
                        PodrazumevanaPublikacijaID = c.Int(),
                        PodrazumevanaRubrikaID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Sektori", t => t.SektorID, cascadeDelete: true)
                .ForeignKey("Publikacije", t => t.PodrazumevanaPublikacijaID)
                .ForeignKey("Rubrike", t => t.PodrazumevanaRubrikaID)
                .Index(t => t.SektorID)
                .Index(t => t.PodrazumevanaPublikacijaID)
                .Index(t => t.PodrazumevanaRubrikaID);
            
            CreateTable(
                "Publikacije",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Rubrike",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 100),
                        PublikacijaID = c.Int(nullable: false),
                        Sort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Publikacije", t => t.PublikacijaID, cascadeDelete: true)
                .Index(t => t.PublikacijaID);
            
            CreateTable(
                "Radnici",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 50),
                        Prezime = c.String(nullable: false, maxLength: 50),
                        OdeljenjeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Odeljanja", t => t.OdeljenjeID, cascadeDelete: true)
                .Index(t => t.OdeljenjeID);
            
            CreateTable(
                "Ocene",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Opis = c.String(nullable: false, maxLength: 20),
                        Vrednost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "TipoviTekstova",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "RadniNalozi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PublikacijaID = c.Int(nullable: false),
                        RubrikaID = c.Int(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        RadnikID = c.Int(nullable: false),
                        OcenaID = c.Int(),
                        BrojStranice = c.Int(nullable: false),
                        Napomena = c.String(),
                        TipTekstaID = c.Int(),
                        NaslovTeksta = c.String(maxLength: 250),
                        Stubaca = c.Int(),
                        Centimetara = c.Int(),
                        Stranica = c.String(maxLength: 256),
                        TipAktivnosti = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Publikacije", t => t.PublikacijaID, cascadeDelete: true)
                .ForeignKey("Rubrike", t => t.RubrikaID)
                .ForeignKey("Radnici", t => t.RadnikID, cascadeDelete: true)
                .ForeignKey("Ocene", t => t.OcenaID)
                .ForeignKey("TipoviTekstova", t => t.TipTekstaID, cascadeDelete: true)
                .Index(t => t.PublikacijaID)
                .Index(t => t.RubrikaID)
                .Index(t => t.RadnikID)
                .Index(t => t.OcenaID)
                .Index(t => t.TipTekstaID);
            
        }
        
        public override void Down()
        {
            DropIndex("RadniNalozi", new[] { "TipTekstaID" });
            DropIndex("RadniNalozi", new[] { "OcenaID" });
            DropIndex("RadniNalozi", new[] { "RadnikID" });
            DropIndex("RadniNalozi", new[] { "RubrikaID" });
            DropIndex("RadniNalozi", new[] { "PublikacijaID" });
            DropIndex("Radnici", new[] { "OdeljenjeID" });
            DropIndex("Rubrike", new[] { "PublikacijaID" });
            DropIndex("Odeljanja", new[] { "PodrazumevanaRubrikaID" });
            DropIndex("Odeljanja", new[] { "PodrazumevanaPublikacijaID" });
            DropIndex("Odeljanja", new[] { "SektorID" });
            DropIndex("Sektori", new[] { "NovinskaKucaID" });
            DropForeignKey("RadniNalozi", "TipTekstaID", "TipoviTekstova");
            DropForeignKey("RadniNalozi", "OcenaID", "Ocene");
            DropForeignKey("RadniNalozi", "RadnikID", "Radnici");
            DropForeignKey("RadniNalozi", "RubrikaID", "Rubrike");
            DropForeignKey("RadniNalozi", "PublikacijaID", "Publikacije");
            DropForeignKey("Radnici", "OdeljenjeID", "Odeljanja");
            DropForeignKey("Rubrike", "PublikacijaID", "Publikacije");
            DropForeignKey("Odeljanja", "PodrazumevanaRubrikaID", "Rubrike");
            DropForeignKey("Odeljanja", "PodrazumevanaPublikacijaID", "Publikacije");
            DropForeignKey("Odeljanja", "SektorID", "Sektori");
            DropForeignKey("Sektori", "NovinskaKucaID", "NovinskeKuce");
            DropTable("RadniNalozi");
            DropTable("TipoviTekstova");
            DropTable("Ocene");
            DropTable("Radnici");
            DropTable("Rubrike");
            DropTable("Publikacije");
            DropTable("Odeljanja");
            DropTable("Sektori");
            DropTable("NovinskeKuce");
        }
    }
}
