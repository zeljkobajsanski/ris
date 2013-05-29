using System.Data.Entity;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Core.Utils;

namespace Rs.Dnevnik.Ris.EntityFramework.Configurations
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
            // Novinska kuca
            var dnevnik = new NovinskaKuca {Naziv = "DNEVNIK"};
            context.NovinskeKuce.Add(dnevnik);
            context.SaveChanges();

            // Sektori
            var redakcija = new Sektor {Naziv = "Redakcija", NovinskaKuca = dnevnik};
            var oglasi = new Sektor { Naziv = "Oglasi", NovinskaKuca = dnevnik };
            var it = new Sektor { Naziv = "IT", NovinskaKuca = dnevnik };
            var produkcija = new Sektor { Naziv = "Produkcija", NovinskaKuca = dnevnik };
            context.Sektori.Add(redakcija);
            context.Sektori.Add(oglasi);
            context.Sektori.Add(it);
            context.Sektori.Add(produkcija);
            context.SaveChanges();

            // Odeljenja
            var it1 = new Odeljenje() {Naziv = "IT", Sektor = it};
            var kultura = new Odeljenje { Naziv = "Kultura", Sektor = redakcija };
            var svet = new Odeljenje {Naziv = "Svet", Sektor = redakcija};
            var desk = new Odeljenje {Naziv = "Desk", Sektor = redakcija};
            var sport = new Odeljenje {Naziv = "Sport", Sektor = redakcija};
            context.Odeljanja.Add(it1);
            context.Odeljanja.Add(svet);
            context.Odeljanja.Add(kultura);
            context.Odeljanja.Add(desk);
            context.Odeljanja.Add(sport);
            context.SaveChanges();

            // Radnici
            var administrator = new Radnik {Ime = "Admin", Prezime = "Admin", Odeljenje = it1};
            var r1 = new Radnik {Ime = "Ime1", Prezime = "Prezime1", Odeljenje = svet};
            var r2 = new Radnik {Ime = "Ime2", Prezime = "Prezime2", Odeljenje = svet};
            var r3 = new Radnik {Ime = "Ime3", Prezime = "Prezime3", Odeljenje = kultura};
            var r4 = new Radnik {Ime = "Ime4", Prezime = "Prezime4", Odeljenje = kultura};
            var r5 = new Radnik {Ime = "Ime5", Prezime = "Prezime5", Odeljenje = kultura};
            var r6 = new Radnik {Ime = "Ime6", Prezime = "Prezime6", Odeljenje = desk};
            var r7 = new Radnik {Ime = "Ime7", Prezime = "Prezime7", Odeljenje = sport};
            var r8 = new Radnik {Ime = "Ime8", Prezime = "Prezime8", Odeljenje = sport};

            context.Radnici.Add(administrator);
            context.Radnici.Add(r3);
            context.Radnici.Add(r4);
            context.Radnici.Add(r1);
            context.Radnici.Add(r2);
            context.Radnici.Add(r5);
            context.Radnici.Add(r6);
            context.Radnici.Add(r7);
            context.Radnici.Add(r8);
            context.SaveChanges();

            // Publikacije
            var dnevnikPub = new Publikacija {Naziv = "Dnevnik"};
            svet.PodrazumevanaPublikacija = dnevnikPub;
            kultura.PodrazumevanaPublikacija = dnevnikPub;
            desk.PodrazumevanaPublikacija = dnevnikPub;
            sport.PodrazumevanaPublikacija = dnevnikPub;
            var lovacPub = new Publikacija {Naziv = "Lovac"};
            context.Publikacije.Add(dnevnikPub);
            context.Publikacije.Add(lovacPub);
            context.SaveChanges();

            // Rubrike
            var sportRub = new Rubrika {Naziv = "Sport", Publikacija = dnevnikPub, Sort = 3};
            var kulturaRub = new Rubrika {Naziv = "Kultura", Publikacija = dnevnikPub, Sort = 1};
            var svetRub = new Rubrika {Naziv = "Svet", Publikacija = dnevnikPub, Sort = 2};
            svet.PodrazumevanaRubrika = svetRub;
            sport.PodrazumevanaRubrika = sportRub;
            kultura.PodrazumevanaRubrika = kulturaRub;
            context.Rubrike.Add(sportRub);
            context.Rubrike.Add(kulturaRub);
            context.Rubrike.Add(svetRub);
            context.SaveChanges();

            // Ocene
            var pohvala = new Ocena {Vrednost = 4, Opis = "Pohvala"};
            var propust = new Ocena {Vrednost = 2, Opis = "Propust"}; 
            var isticeSe = new Ocena {Vrednost = 3, Opis = "Ističe se"};
            context.Ocene.Add(pohvala);
            context.Ocene.Add(propust);
            context.Ocene.Add(isticeSe);
            context.SaveChanges();

            // Tip teksta
            var reportaza = new TipTeksta {Naziv = "Reportaža"};
            var intervju = new TipTeksta {Naziv = "Intervju"};
            var razgovor = new TipTeksta {Naziv = "Razgovor"};
            var komentar = new TipTeksta {Naziv = "Komentar"};
            var prikaz = new TipTeksta {Naziv = "Prikaz"};
            var clanak = new TipTeksta {Naziv = "Članak"};
            var osvrt = new TipTeksta {Naziv = "Osvrt"};
            var inMemoriam = new TipTeksta {Naziv = "In memoriam"};
            var izvestaj = new TipTeksta {Naziv = "Izvestaj"};
            var najava = new TipTeksta {Naziv = "Najava"};
            var odjava = new TipTeksta {Naziv = "Odjava"};
            var infotramcija = new TipTeksta {Naziv = "Informacija"};
            var vest = new TipTeksta {Naziv = "Vest"};
            var fotoVest = new TipTeksta {Naziv = "Foto vest"};
            var anketa = new TipTeksta {Naziv = "Anketa"};
            var tabela = new TipTeksta {Naziv = "Tabela"};
            var ostalo = new TipTeksta {Naziv = "Ostalo"};
            context.TipoviTeksta.Add(reportaza);
            context.TipoviTeksta.Add(intervju);
            context.TipoviTeksta.Add(razgovor);
            context.TipoviTeksta.Add(komentar);
            context.TipoviTeksta.Add(prikaz);
            context.TipoviTeksta.Add(clanak);
            context.TipoviTeksta.Add(osvrt);
            context.TipoviTeksta.Add(inMemoriam);
            context.TipoviTeksta.Add(izvestaj);
            context.TipoviTeksta.Add(najava);
            context.TipoviTeksta.Add(odjava);
            context.TipoviTeksta.Add(infotramcija);
            context.TipoviTeksta.Add(vest);
            context.TipoviTeksta.Add(fotoVest);
            context.TipoviTeksta.Add(anketa);
            context.TipoviTeksta.Add(tabela);
            context.TipoviTeksta.Add(ostalo);
            context.SaveChanges();
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

            context.GrupeMaterijala.Add(new GrupaMaterijala() {Naziv = "Sport"});
            context.GrupeMaterijala.Add(new GrupaMaterijala() {Naziv = "Politika"});
            context.SaveChanges();

            var admin = new UlogaRadnika() { Naziv = "Admin" };
            var novinar = new UlogaRadnika() {Naziv = "Novinar"};
            var urednik = new UlogaRadnika() {Naziv = "Urednik"};
            var lektor = new UlogaRadnika() {Naziv = "Lektor"};
            var dtp = new UlogaRadnika() {Naziv = "DTP"};
            
            context.UlogeRadnika.Add(admin);
            context.UlogeRadnika.Add(novinar);
            context.UlogeRadnika.Add(urednik);
            context.UlogeRadnika.Add(lektor);
            context.UlogeRadnika.Add(dtp);
            context.SaveChanges();
            administrator.UlogeRadnika.Add(admin);
            r1.UlogeRadnika.Add(novinar);
            r1.UlogeRadnika.Add(urednik);
            r1.UlogeRadnika.Add(admin);
            r2.UlogeRadnika.Add(lektor);
            r3.UlogeRadnika.Add(novinar);
            r4.UlogeRadnika.Add(lektor);
            r5.UlogeRadnika.Add(novinar);
            r6.UlogeRadnika.Add(novinar);
            r7.UlogeRadnika.Add(novinar);
            r8.UlogeRadnika.Add(novinar);
            r8.UlogeRadnika.Add(urednik);
            context.SaveChanges();

            var adminUser = new KorisnickiNalog
            {
                KorisnickoIme = "admin",
                RadnikID = administrator.ID,
                LozinkaPlain = "admin",
                Lozinka = HashUtilities.CalculateMd5Hash("admin")
            };
            
            context.KorisnickiNalozi.Add(adminUser);
            context.SaveChanges();
        }
    }
}