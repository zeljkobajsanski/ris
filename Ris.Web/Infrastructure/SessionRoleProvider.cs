using System.Web;
using Rs.Dnevnik.Ris.Core.Model;
using System.Linq;

namespace Ris.Web.Infrastructure
{
    public class SessionRoleProvider : System.Web.Security.RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            var korisnik = HttpContext.Current.Session["Korisnik"] as KorisnickiNalog;
            if (korisnik == null) return false;
            if (korisnik.KorisnickoIme != username) return false;
            return korisnik.Radnik.UlogeRadnika.Any(x => x.Naziv == roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            var korisnik = HttpContext.Current.Session["Korisnik"] as KorisnickiNalog;
            if (korisnik == null) return new string[0];
            if (korisnik.KorisnickoIme != username) return new string[0];
            return korisnik.Radnik.UlogeRadnika.Select(x => x.Naziv).ToArray();
        }

        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}