using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.XtraPrinting.Native;
using Ris.Web.Utils.Message;
using Ris.Web.ViewModels;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.Interfaces.Repositories;

namespace Ris.Web.Controllers
{
    public class FotoArhivaController : Controller
    {
        private readonly IRepositoryFactory fRepositoryFactory;

        public FotoArhivaController(IRepositoryFactory fRepositoryFactory)
        {
            this.fRepositoryFactory = fRepositoryFactory;
        }

        public ActionResult Unos()
        {
            ViewBag.Publikacije = fRepositoryFactory.PublikacijeRepository.Publikacije();
            ViewBag.GrupeMaterijala = fRepositoryFactory.GrupeMaterijalaRepository.VratiSve();
            return View(new MaterijalInfo(){Kreiran = DateTime.Now});
        }

        [HttpPost][ValidateInput(true)]
        public ActionResult Unos(MaterijalInfo materijalInfo)
        {
            if (!ModelState.IsValid)
            {
                TempData["StatusMessage"] = new StatusMessage("Podaci nisu ispravni", StatusMessageType.Error);
                return View(materijalInfo);
            }
            
            var files = UploadControlExtension.GetUploadedFiles("Upload");
            foreach (var uploadedFile in files)
            {
                var filePath = "/Blob/FotoArhiva/" + uploadedFile.FileName;
                var thumbnail = "/Blob/FotoArhiva/Thumbnails/" + uploadedFile.FileName;
                materijalInfo.Materijali.Add(new Materijal(){Putanja = filePath, Thumbnail = thumbnail});
                var serverPath = HttpContext.Server.MapPath("~" + filePath);
                var thumbnailPath = HttpContext.Server.MapPath("~" + thumbnail);
                using (var img = Image.FromStream(uploadedFile.FileContent))
                {
                    var thumbnailImage = img.GetThumbnailImage(100, 100, () => true, IntPtr.Zero);
                    thumbnailImage.Save(thumbnailPath);
                }
                uploadedFile.SaveAs(serverPath);
            }
            fRepositoryFactory.MaterijalRepository.Add(materijalInfo);
            fRepositoryFactory.MaterijalRepository.Save();
            TempData["StatusMessage"] = new StatusMessage("Podaci su uspešno sačuvani", StatusMessageType.Success);
            return RedirectToAction("Unos");
        }

        public ActionResult PretraziFotoArhivu(string naziv, string tag, int? publikacija, int? grupaMaterijala)
        {
            var materijali = fRepositoryFactory.MaterijalRepository.Pretrazi(naziv, tag, publikacija, grupaMaterijala).ToArray();
            foreach (var materijal in materijali)
            {
                materijal.Putanja = @Url.Content("~" + materijal.Putanja);
                materijal.Thumbnail = @Url.Content("~" + materijal.Thumbnail);
            }
            return Json(materijali, JsonRequestBehavior.AllowGet);
        }

        public FileResult Preuzmi(int id)
        {
            var materijal = fRepositoryFactory.MaterijalRepository.VratiMaterijal(id);
            var putanja = materijal.Putanja;
            var file = HttpContext.Server.MapPath("~" + putanja);
            return File(file, "image/jpeg");
            //return File(file, "application/octet-stream");
        }

        public ActionResult PretragaFotoArhive()
        {
            var vm = new PretragaFotoArhiveViewModel
            {
                Publikacije = fRepositoryFactory.PublikacijeRepository.Publikacije(),
                GrupeMaterijala = fRepositoryFactory.GrupeMaterijalaRepository.VratiSve(),
            };
            return PartialView("PretragaSlika", vm);
        }
    }
}
