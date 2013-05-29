using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Web.Http;
using Ris.Services.IoC;
using Ris.Spa.Models;
using Rs.Dnevnik.Ris.Core.DTO;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.EntityFramework.Repositories;
using Rs.Dnevnik.Ris.Interfaces.Services;
using Materijal = Ris.Spa.Models.Materijal;

namespace Ris.Spa.Controllers
{
    public class DataController : ApiController
    {
         [HttpGet]
         public IEnumerable<PublikacijaDTO> VratiPublikacije()
         {
             using (var rf = new RepositoryFactory())
             {
                 return rf.PublikacijeRepository.Publikacije().Select(x => new PublikacijaDTO{ID = x.ID, Naziv = x.Naziv}).ToArray();
             } 
         } 

        [HttpGet]
        public IEnumerable<RadnaListaDTO> VratiRadneListe(DateTime datum, int idPublikacije)
        {
            using (var rf = new RepositoryFactory())
            {
                var radniNalozi = rf.RadniNaloziRepository.VratiRadneNaloge(idPublikacije, datum.Date).ToList();
                var radnici = rf.RadniciRepository.VratiRadnike().ToDictionary(x => x.ID);
                var publikacije = rf.PublikacijeRepository.Publikacije().ToDictionary(x => x.ID);
                var rubrike = rf.RubrikeRepository.VratiRubrike(idPublikacije).ToDictionary(x => x.ID);
                foreach (var radnik in radnici.Values)
                {
                    if (radniNalozi.All(x => x.RadnikID != radnik.ID))
                    {
                        radniNalozi.Add(new RadniListNovinara
                        {
                            Datum = datum,
                            PublikacijaID = idPublikacije,
                            RadnikID = radnik.ID
                        });
                    }
                }
                var rn = radniNalozi.Select(x => new RadnaListaDTO()
                {
                    ID = x.ID,
                    Datum = x.Datum,
                    PublikacijaID = x.PublikacijaID.Value,
                    Publikacija = publikacije[x.PublikacijaID.Value].Naziv,
                    RadnikID = x.RadnikID,
                    Radnik = radnici[x.RadnikID.Value].ImeIPrezime,
                    RubrikaID = x.RubrikaID,
                    Rubrika =
                        x.RubrikaID.HasValue
                            ? rubrike[x.RubrikaID.Value].Naziv
                            : string.Empty,
                    TipAktivnosti = x is RadniListNovinara ? "Napisan tekst" : "Uredjen tekst",
                    TipTekstaID = x is RadniListNovinara ? ((RadniListNovinara)x).TipTekstaID : (int?)null,
                    Naslov = x is RadniListNovinara ? ((RadniListNovinara)x).NaslovTeksta : null,
                    BrojStranice = x.BrojStranice,
                    Stubaca = x is RadniListNovinara ? ((RadniListNovinara)x).Stubaca : null,
                    Centimetara = x is RadniListNovinara ? ((RadniListNovinara)x).Centimetara : null,
                    OcenaID = x.OcenaID,
                    Napomena = x.Napomena
                });
                return rn;
            }
        }

        [HttpGet]
        public UnosRadnogListaDTO UnosRadnogLista(int idPublikacije)
        {
            using (var rf = new RepositoryFactory())
            {
                return new UnosRadnogListaDTO
                {
                    Rubrike = rf.RubrikeRepository.VratiRubrike(idPublikacije).Select(x => new RubrikaDTO { ID = x.ID, Naziv = x.Naziv }).ToArray(),
                    Radnici = rf.RadniciRepository.VratiRadnike().Select(x => new RadnikDTO { ID = x.ID, ImeIPrezime = x.ImeIPrezime }).ToArray(),
                    Ocene = rf.OceneRepository.Ocene().OrderBy(x => x.Vrednost).Select(x => new OcenaDTO{ID = x.ID, Opis = x.Opis}).ToArray(),
                    TipoviAktivnosti = new[]{"Napisan tekst", "Uredjen tekst"},
                    TipoviTeksta = rf.TipoviTekstovaRepository.TipoviTekstova().Select(x => new TipTekstaDTO(){ID = x.ID, Naziv = x.Naziv}).ToArray()
                };
            }
        }

        [HttpPost]
        public void SacuvajRadniList(RadnaListaDTO radnaLista)
        {
            using (var rf = new RepositoryFactory())
            {
                RadniNalog radniList = null;
                if (radnaLista.TipAktivnosti == "Napisan tekst")
                {
                    radniList = new RadniListNovinara
                    {
                        ID = radnaLista.ID,
                        Datum = radnaLista.Datum.Date,
                        PublikacijaID = radnaLista.PublikacijaID,
                        RubrikaID = radnaLista.RubrikaID,
                        TipTekstaID = radnaLista.TipTekstaID,
                        RadnikID = radnaLista.RadnikID,
                        NaslovTeksta = radnaLista.Naslov,
                        BrojStranice = radnaLista.BrojStranice,
                        Stubaca = radnaLista.Stubaca,
                        Centimetara = radnaLista.Centimetara,
                        OcenaID = radnaLista.OcenaID,
                        Napomena = radnaLista.Napomena
                    };
                    
                }
                else if (radnaLista.TipAktivnosti == "Uredjen tekst")
                {
                    radniList = new RadniListUrednika()
                    {
                        ID = radnaLista.ID,
                        Datum = radnaLista.Datum.Date,
                        PublikacijaID = radnaLista.PublikacijaID,
                        RubrikaID = radnaLista.RubrikaID,
                        RadnikID = radnaLista.RadnikID,
                        BrojStranice = radnaLista.BrojStranice,
                        OcenaID = radnaLista.OcenaID,
                        Napomena = radnaLista.Napomena
                    };
                } else throw new Exception("Tip aktivnosti nije postavljen");
                if (!radniList.IsValid)
                {
                    throw new ValidationException(radniList.GetAllErrors());
                }
                rf.RadniNaloziRepository.Add(radniList);
                rf.RadniNaloziRepository.Save();
            }
        }
        [HttpPost]
        public void ObrisiRadnuListu(RadnaListaDTO radnaLista)
        {
            using (var rf = new RepositoryFactory())
            {
                rf.RadniNaloziRepository.Remove(new RadniNalog{ID = radnaLista.ID});
                rf.RadniNaloziRepository.Save();
            }

        }

        [HttpGet]
        public AgencijaDTO[] VratiAgencije()
        {
            using (var rf = new RepositoryFactory())
            {
                return rf.AgencijeRepository.VratiAgencije()
                  .Select(x => new AgencijaDTO {ID = x.ID, Naziv = x.Naziv, Default = x.Default})
                  .ToArray();
            }
        }

        [HttpGet]
        public PretragaVesti VratiAgencijskeVesti(DateTime? datum, int? idAgencije, string deoSadrzaja)
        {
            using (var rf = new RepositoryFactory())
            {

                var pojmoviPretrage = (deoSadrzaja != null ? deoSadrzaja.Split(' ') : new string[0]);
                var textKonvertor = Container.Default.GetInstance<ITextKonvertor>();
                var sviPojmoviPretrage = new List<string>();
                foreach (var pojamPretrage in pojmoviPretrage)
                {
                    sviPojmoviPretrage.Add(pojamPretrage);
                    var konvertovan = textKonvertor.Konvertuj(pojamPretrage);
                    if (!pojamPretrage.Equals(konvertovan))
                    {
                        sviPojmoviPretrage.Add(konvertovan);
                    }
                }
                var agencije = rf.AgencijeRepository.VratiAgencije().ToDictionary(x => x.ID);
                var vesti = rf.AgencijskeVestiRepository.PretraziVesti(datum, idAgencije, sviPojmoviPretrage).Select(x => new AgencijskaVestDTO
                {
                    ID = x.ID,
                    Datum = x.DatumPrijema,
                    Naslov = x.Subject,
                    Agencija = agencije[x.AgencijaID].Naziv
                }).ToArray();
                var pretrageVesti = new PretragaVesti
                {
                    Vesti = vesti,
                    PojmoviPretrage = sviPojmoviPretrage
                };
                return pretrageVesti;
            }
        }

        [HttpGet]
        public AgencijskaVest VratiAgencijskuVest(int id)
        {
            using (var rf = new RepositoryFactory())
            {
                return rf.AgencijskeVestiRepository.VratiPoId(id);
            }
        }

        [HttpPost]
        public Task<string> SacuvajSliku()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/Blob");
            var provider = new MultipartFormDataStreamProvider(root);

            // Read the form data and return an async task.
            var task = Request.Content.ReadAsMultipartAsync(provider).
                ContinueWith<string>(t =>
                {
                    // This illustrates how to get the file names.
                    var file = provider.FileData.Single();
                    return new FileInfo(file.LocalFileName).Name;
                });

            return task;
        }

        [HttpPost]
        public HttpResponseMessage SacuvajMaterijal(Materijal materijal)
        {
            if (string.IsNullOrEmpty(materijal.Naziv))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Naziv nije unet");
            }
            var materijalInfo = new MaterijalInfo()
            {
                Naziv = materijal.Naziv,
                Kreiran = DateTime.Now,
            };
            using (var ts = new TransactionScope())
            {
                using (var rf = new RepositoryFactory())
                {
                    rf.MaterijalRepository.Add(materijalInfo);
                    rf.MaterijalRepository.Save();

                    for (int index = 1; index <= materijal.Slike.Length; index++)
                    {
                        var fajl = materijal.Slike[index - 1];
                        var src = HttpContext.Current.Server.MapPath("~/Blob/" + fajl.Filename);
                        var dstDir = HttpContext.Current.Server.MapPath("~/Blob/FotoArhiva/" + materijalInfo.ID);
                        if (!Directory.Exists(dstDir))
                        {
                            Directory.CreateDirectory(dstDir);
                        }
                        var dst = Path.Combine(dstDir, index + fajl.Extension);
                        File.Move(src, dst);
                        using (var thumbnail = Image.FromFile(dst).GetThumbnailImage(100, 100, () => true, IntPtr.Zero))
                        {
                            string thumbnailPath = Path.Combine(dstDir, "thumb_" + index + fajl.Extension);
                            thumbnail.Save(thumbnailPath);
                        }
                        materijalInfo.Materijali.Add(new Rs.Dnevnik.Ris.Core.Model.Materijal
                        {
                            Putanja = "Blob/FotoArhiva/" + materijalInfo.ID + "/" + index + fajl.Extension,
                            Thumbnail = "Blob/FotoArhiva/" + materijalInfo.ID + "/" + "thumb_" + index + fajl.Extension
                        });
                    }
                    rf.MaterijalRepository.Save();
                    ts.Complete();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            
        }

        [HttpGet]
        public IEnumerable<Rs.Dnevnik.Ris.Core.Model.Materijal> PretraziSlike(string naziv)
        {
            using (var rf = new RepositoryFactory())
            {
                return rf.MaterijalRepository.VratiSveMaterijale(naziv);
            }
        }
    }
}