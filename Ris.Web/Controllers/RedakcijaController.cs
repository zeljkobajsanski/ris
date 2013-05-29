using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using DevExpress.Web.ASPxHtmlEditor;
using DevExpress.Web.Mvc;
using Ris.Web.Infrastructure;
using Ris.Web.Utils.Message;
using Ris.Web.ViewModels;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using Rs.Dnevnik.Ris.Core.Utils;

namespace Ris.Web.Controllers
{
    [HandleError]
    public class RedakcijaController : Controller
    {
        private readonly IRepositoryFactory fRepositoryFactory;

        public RedakcijaController(IRepositoryFactory repositoryFactory)
        {
            this.fRepositoryFactory = repositoryFactory;
        }


        #region Unos teksta

        [SessionRequired(Roles = "Novinar")]
        public ActionResult UnosTeksta()
        {
            ViewBag.Title = "Unos teksta";
            var korisnik = HttpContext.Session["Korisnik"] as KorisnickiNalog;
            var vm = new UnosTekstaViewModel
            {
                Tekst = new Tekst() { AutorID = korisnik.RadnikID, TrenutnoKodID = (int)Uloga.Novinar, Datum = DateTime.Now},
                Publikacije = fRepositoryFactory.PublikacijeRepository.Publikacije(),
                TipoviTeksta = fRepositoryFactory.TipoviTekstovaRepository.TipoviTekstova(),
            };
            return View("Tekst", vm);
        }

        [HttpPost]
        public ActionResult Sacuvaj([Bind(Prefix = "Tekst")]Tekst tekst)
        {
            var htmlEditorSettings = new HtmlEditorSettings();
            Customize(htmlEditorSettings);

            //using (var ms = new MemoryStream())
            //{
            //    HtmlEditorExtension.Export(htmlEditorSettings, ms, HtmlEditorExportFormat.Rtf);
            //    ms.Position = 0;
            //    tekst.Rtf = Encoding.UTF8.GetString(ms.ToArray());
            //}
            //using (var ms = new MemoryStream())
            //{
            //    HtmlEditorExtension.Export(htmlEditorSettings, ms, HtmlEditorExportFormat.Txt);
            //    ms.Position = 0;
            //    tekst.PlainText = Encoding.UTF8.GetString(ms.ToArray());
            //}
            tekst.Html = HtmlEditorExtension.GetHtml("Html");

            var zaSnimanje = tekst.ID == 0 ? new Tekst() : fRepositoryFactory.TekstoviRepository.VratiTekst(tekst.ID);
            zaSnimanje.Datum = tekst.Datum;
            zaSnimanje.PublikacijaID = tekst.PublikacijaID;
            zaSnimanje.RubrikaID = tekst.RubrikaID;
            zaSnimanje.TipTekstaID = tekst.TipTekstaID;
            zaSnimanje.Nadnaslov = tekst.Nadnaslov;
            zaSnimanje.Naslov = tekst.Naslov;
            zaSnimanje.Podnaslov = tekst.Podnaslov;
            zaSnimanje.PlainText = tekst.PlainText;
            zaSnimanje.Rtf = tekst.Rtf;
            zaSnimanje.Html = tekst.Html;
            zaSnimanje.AutorID = tekst.AutorID;
            zaSnimanje.TrenutnoKodID = tekst.TrenutnoKodID;
            zaSnimanje.ArhiviraniTekstovi.Add(new ArhiviranTekst(){Html = zaSnimanje.Html});

            fRepositoryFactory.TekstoviRepository.Add(zaSnimanje);
            // Obrisi materijale
            foreach (var m in zaSnimanje.Materijali.ToArray())
            {
                if (tekst.Materijali.All(x => x.ID != m.ID))
                {
                    zaSnimanje.Materijali.Remove(m);
                }
            }
            // Dodaj materijale
            foreach (var m in tekst.Materijali)
            {
                if (zaSnimanje.Materijali.All((x => x.ID != m.ID)))
                {
                    zaSnimanje.Materijali.Add(m);
                    fRepositoryFactory.MaterijalRepository.MarkUnchanged(m);
                }
            }
            if (!zaSnimanje.IsValid)
            {
                TempData["StatusMessage"] = new StatusMessage("Podaci nisu validni", StatusMessageType.Error);
                return View("Tekst", new UnosTekstaViewModel
                {
                    Tekst = zaSnimanje,
                    Publikacije = fRepositoryFactory.PublikacijeRepository.Publikacije(),
                    TipoviTeksta = fRepositoryFactory.TipoviTekstovaRepository.TipoviTekstova(),
                });
            }
            fRepositoryFactory.TekstoviRepository.Save();
            TempData["StatusMessage"] = new StatusMessage("Podaci su uspešno snimljeni", StatusMessageType.Success);
            return RedirectToAction("IzmenaTeksta", new { id = zaSnimanje.ID });
        }

        [SessionRequired(Roles = "Novinar,Urednik,Lektor")]
        public ActionResult IzmenaTeksta(int id)
        {
            ViewBag.Title = "Izmena teksta";
            var korisnik = HttpContext.Session["Korisnik"] as KorisnickiNalog;
            var tekst = fRepositoryFactory.TekstoviRepository.VratiTekst(id);
                        
            if (tekst.TrenutnoKodID == (int)Uloga.Urednik && !Roles.IsUserInRole("Urednik")) throw new Exception("Tekst se ne nalazi kod urednika");
            if (tekst.TrenutnoKodID == (int)Uloga.Lektor && !Roles.IsUserInRole("Lektor")) throw new Exception("Tekst se ne nalazi kod lektora");
            if (tekst.TrenutnoKodID == (int)Uloga.Novinar && !Roles.IsUserInRole("Novinar")) throw new Exception("Tekst se ne nalazi kod novinara");
            if (tekst.TrenutnoKodID == (int)Uloga.Novinar && tekst.AutorID != korisnik.RadnikID) throw new Exception("Korisnik nije autor teksta");

            var vm = new UnosTekstaViewModel
            {
                Tekst = tekst,
                Publikacije = fRepositoryFactory.PublikacijeRepository.Publikacije(),
                TipoviTeksta = fRepositoryFactory.TipoviTekstovaRepository.TipoviTekstova(),
            };
            if (tekst.TrenutnoKodID == (int)Uloga.Novinar)
            {
                vm.SaljiNovinaru = false;
                vm.SaljiUredniku = true;
                vm.SaljiLektoru = true;
            }
            else if (tekst.TrenutnoKodID == (int)Uloga.Urednik)
            {
                vm.SaljiNovinaru = true;
                vm.SaljiUredniku = false;
                vm.SaljiLektoru = true;
                vm.SaljiUDTP = true;
            }
            else if (tekst.TrenutnoKodID == (int)Uloga.Lektor)
            {
                vm.SaljiNovinaru = true;
                vm.SaljiUredniku = true;
                vm.SaljiLektoru = false;
            }
            return View("Tekst", vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ObrisiTekst(int id)
        {
            var tekst = fRepositoryFactory.TekstoviRepository.VratiTekst(id);
            fRepositoryFactory.TekstoviRepository.Remove(tekst);
            fRepositoryFactory.TekstoviRepository.Save();
            return new EmptyResult();
        }

        [HttpPost]
        [SessionRequired]
        public ActionResult PosaljiKomentar(Komentar komentar)
        {
            if (komentar.TekstID == 0) throw new Exception("Tekst za koji se veže komentar nije snimljen");
            if (!string.IsNullOrEmpty(komentar.TekstKomentara))
            {
                komentar.Datum = DateTime.Now;
                var korisnik = HttpContext.Session["Korisnik"] as KorisnickiNalog;
                komentar.PoslaoID = korisnik.RadnikID;
                var tekst = fRepositoryFactory.TekstoviRepository.VratiTekst(komentar.TekstID);
                tekst.Komentari.Add(komentar);
                fRepositoryFactory.TekstoviRepository.Save();
            }
            return new EmptyResult();
        }
        

        [HttpPost]
        public ActionResult PosaljiNovinaru(int idTeksta)
        {
            PosaljiTekst(idTeksta, Uloga.Novinar);
            return Json(Url.Action("PregledTekstova"));
        }

        [HttpPost]
        public ActionResult PosaljiUredniku(int idTeksta)
        {
            PosaljiTekst(idTeksta, Uloga.Urednik);
            return Json(Url.Action("PregledTekstova"));
        }

        [HttpPost]
        public ActionResult PosaljiLektoru(int idTeksta)
        {
            PosaljiTekst(idTeksta, Uloga.Lektor);
            return Json(Url.Action("PregledTekstova"));
        }

        [HttpPost]
        public ActionResult PosaljiUDTP(int idTeksta)
        {
            PosaljiTekst(idTeksta, Uloga.DTP);
            return Json(Url.Action("PregledTekstova"));
        }

        public ActionResult Izvezi(string format)
        {
            var settings = new HtmlEditorSettings();
            Customize(settings);
            var fileName = "IzvozTeksta";
            var formatTeksta = HtmlEditorExportFormat.Rtf;
            switch (format)
            {
                case "Rtf":
                    fileName += ".rtf";
                    break;
                case "Txt":
                    fileName += ".txt";
                    formatTeksta = HtmlEditorExportFormat.Txt;
                    break;
                case "Pdf":
                    fileName += ".pdf";
                    formatTeksta = HtmlEditorExportFormat.Pdf;
                    break;
                case "Docx":
                    fileName += ".docx";
                    formatTeksta = HtmlEditorExportFormat.Docx;
                    break;
            }
            return HtmlEditorExtension.Export(settings, formatTeksta, fileName);
        }

        #endregion

        #region Pregled tekstova

        [SessionRequired(Roles = "Novinar,Urednik,Lektor,Admin,DTP")]
        public ActionResult PregledTekstova()
        {
            var vm = new PregledTekstovaViewModel
            {
                Datum = DateTime.Now.Date,
                Publikacije = fRepositoryFactory.PublikacijeRepository.Publikacije()
            };
            return View(vm);
        }

        [SessionRequired(Roles = "Novinar,Urednik,Lektor,Admin,DTP")]
        public ActionResult PregledTeksta(int id)
        {
            ViewBag.Title = "Pregled teksta";
            var vm = new UnosTekstaViewModel
            {
                Tekst = fRepositoryFactory.TekstoviRepository.VratiTekst(id),
                Publikacije = fRepositoryFactory.PublikacijeRepository.Publikacije(),
                TipoviTeksta = fRepositoryFactory.TipoviTekstovaRepository.TipoviTekstova(),
                ReadOnly = true
            };
            return View("Tekst", vm);
        }

        #endregion

        #region Controls
        
        public PartialViewResult VratiRubrikeZaUnosTeksta(int? idPublikacije, int? idRubrike, bool? readOnly)
        {
            var viewModel = new RubrikeViewModel()
            {
                Name = "Tekst.RubrikaID",
                BeginCallback = "RIS.Redakcija.beginUcitajRubrike",
                IdRubrike = idRubrike,
                Rubrike = fRepositoryFactory.RubrikeRepository.VratiRubrike(idPublikacije),
                ReadOnly = readOnly ?? false
            };
            return PartialView("RubrikaComboBox", viewModel);
        }

        public PartialViewResult VratiRubrikeZaPregledTekstova(int? idPublikacije, int? idRubrike)
        {
            var viewModel = new RubrikeViewModel()
            {
                Name = "cmdRubrike",
                BeginCallback = "RIS.Redakcija.beginUcitajRubrike",
                IdRubrike = idRubrike,
                Rubrike = fRepositoryFactory.RubrikeRepository.VratiRubrike(idPublikacije)
            };
            return PartialView("RubrikaComboBox", viewModel);
        }

        public PartialViewResult PublikacijeComboBox(int? idPublikacije, bool? readOnly)
        {
            var vm = new PublikacijaViewModel
            {
                Name = "Tekst.PublikacijaID",
                IdPublikacije = idPublikacije,
                Publikacije = fRepositoryFactory.PublikacijeRepository.Publikacije(),
                ReadOnly = readOnly ?? false,
                ValueChanged = "RIS.Redakcija.promenjenaPublikacija"
            };
            return PartialView("PublikacijaComboBox", vm);
        }

        public ActionResult Editor()
        {
            return PartialView("_Editor", new UnosTekstaViewModel());
        }

        public PartialViewResult RubrikePartial(int? idPublikacije, string name)
        {
            var model = new RubrikeViewModel()
            {
                Name = name,
                Rubrike = fRepositoryFactory.RubrikeRepository.VratiRubrike(idPublikacije).OrderBy(x => x.Sort)
            };
            return PartialView("RubrikaComboBox", model);
        }

        public static void Customize(HtmlEditorSettings settings)
        {
            settings.Name = "Html";
            settings.CallbackRouteValues = new { action = "Editor" };
            settings.Settings.AllowHtmlView = false;
            settings.SettingsText.DesignViewTab = "Unos";
            settings.SettingsText.PreviewTab = "Pregled";
        }

        [SessionRequired(Roles = "Novinar,Urednik,Lektor,DTP,Admin")]
        public PartialViewResult VratiPregledTekstova(int? idPublikacije, int? idRubrike, DateTime? datum)
        {
            var korisnik = HttpContext.Session["Korisnik"] as KorisnickiNalog;
            HashSet<Tekst> tekstovi = new HashSet<Tekst>();

            if (Roles.IsUserInRole("Novinar"))
            {
                var t = fRepositoryFactory.TekstoviRepository.VratiTekstoveAutora(idPublikacije, idRubrike, datum, korisnik.RadnikID, (int)Uloga.Novinar);
                foreach (var tekst in t)
                {
                    tekstovi.Add(tekst);
                }
            }
            if (Roles.IsUserInRole("Lektor"))
            {
                var t = fRepositoryFactory.TekstoviRepository.VratiTekstoveZaUlogu(idPublikacije, idRubrike, datum, (int)Uloga.Lektor);
                foreach (var tekst in t)
                {
                    tekstovi.Add(tekst);
                }
            }
            if (Roles.IsUserInRole("Urednik"))
            {
                var t = fRepositoryFactory.TekstoviRepository.VratiTekstoveZaUlogu(idPublikacije, idRubrike, datum, (int)Uloga.Urednik);
                foreach (var tekst in t)
                {
                    tekstovi.Add(tekst);
                }
            }
            if (Roles.IsUserInRole("DTP"))
            {
                var t = fRepositoryFactory.TekstoviRepository.VratiTekstoveZaUlogu(idPublikacije, idRubrike, datum, (int)Uloga.DTP);
                foreach (var tekst in t)
                {
                    tekstovi.Add(tekst);
                }
            }
            
            var vm = new PregledTekstovaViewModel
            {
                Publikacije = fRepositoryFactory.PublikacijeRepository.Publikacije(),
                Rubrike = idPublikacije.HasValue ? fRepositoryFactory.RubrikeRepository.VratiRubrike(idPublikacije) : fRepositoryFactory.RubrikeRepository.VratiSveRubrike(),
                Radnici = fRepositoryFactory.RadniciRepository.VratiRadnike(),
                Tekstovi = tekstovi,
                DozvoliBrisanje = korisnik.Radnik.UlogeRadnika.Any(x => x.ID == (int)Uloga.Admin),
                DozvoljenaIzmena = korisnik.Radnik.UlogeRadnika.All(x => x.ID != (int)Uloga.DTP)
            };
            return PartialView("PregledTekstovaGrid", vm);
        }

        public ActionResult VratiKomentare(int? id)
        {
            var model = new KomentariViewModel
            {
                IdTeksta = id,
                RanijiKomentari = fRepositoryFactory.TekstoviRepository.VratiKomentare(id),
                Komentar = new Komentar{TekstID = id ?? 0}
            };
            return PartialView("_KomentariCallbackPanel", model);
        }

        #endregion

        private void PosaljiTekst(int idTeksta, Uloga komeSeSalje)
        {
            var tekst = fRepositoryFactory.TekstoviRepository.VratiTekst(idTeksta);
            tekst.TrenutnoKodID = (int)komeSeSalje;
            fRepositoryFactory.TekstoviRepository.Save();
        }

        
    }
}
