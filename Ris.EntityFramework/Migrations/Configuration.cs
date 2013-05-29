using Rs.Dnevnik.Ris.Core.Model;

namespace Rs.Dnevnik.Ris.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Rs.Dnevnik.Ris.EntityFramework.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Rs.Dnevnik.Ris.EntityFramework.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Konfiguracija.Add(new Konfiguracija
            {
                Server = "pop.gmail.com",
                Port = 995,
                Username = "dnevnikris@gmail.com",
                Password = "dnevnik1302",
                Ssl = true,
                DownloadInterval = 1
            });
            context.SaveChanges();
            context.Agencije.Add(new Agencija { Naziv = "Tanjug", EMail = "slanje@tanjug.rs", Default = true });
            context.Agencije.Add(new Agencija { Naziv = "Fonet", EMail = "info@fonet.rs", Default = false });
            context.SaveChanges();
        }
    }
}
