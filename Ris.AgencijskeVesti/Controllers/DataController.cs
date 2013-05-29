using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Rs.Dnevnik.Ris.EntityFramework.Repositories;

namespace Ris.AgencijskeVesti.Controllers
{
    public class DataController : Controller
    {
        public JsonResult VratiAgencijskeVesti(int? idAgencije)
        {
            var vesti = new AgencijskeVestiRepository().VratiAgencijskeVesti(idAgencije);
            var agencije = new AgencijeRepository().VratiAgencije();
            var result = from v in vesti
                         join a in agencije on v.AgencijaID equals a.ID
                         select new
                                    {
                                        Datum = v.DatumPrijema.ToString("dd.MM.yyyy HH:mm"),
                                        Agencija = a.Naziv,
                                        Naslov = v.Subject,
                                        Body = v.Body
                                    };
            return Json(new {Vesti = result.ToArray(), Agencije = agencije}, JsonRequestBehavior.AllowGet);
        }

    }
}
