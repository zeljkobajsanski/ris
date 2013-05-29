using System.Web.Mvc;
using Rs.Dnevnik.Ris.Core.Model;

namespace Ris.Web.Infrastructure
{
    public class SessionRequired : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized) return false;
            if (httpContext.Session == null) return false;
            var korisnik = httpContext.Session["Korisnik"] as KorisnickiNalog;
            return korisnik != null;
        }
    }
}