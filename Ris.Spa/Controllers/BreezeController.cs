using System.Linq;
using System.Web.Http;
using Breeze.WebApi;
using Rs.Dnevnik.Ris.Core.Model;
using Rs.Dnevnik.Ris.EntityFramework;

namespace Ris.Spa.Controllers
{
    [BreezeController]
    public class BreezeController : ApiController
    {
        private readonly EFContextProvider<DataContext> fContextProvider = new EFContextProvider<DataContext>();
 
        [HttpGet]
        public string Metadata()
        {
            return fContextProvider.Metadata();
        }

        [HttpGet]
        public IQueryable<Publikacija> Publikacije()
        {
            return fContextProvider.Context.Publikacije;
        } 
    }
}