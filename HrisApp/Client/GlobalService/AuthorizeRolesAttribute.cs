using Microsoft.AspNetCore.Http;
using System.Linq;

namespace HrisApp.Client.GlobalService
{
    public class AuthorizeRolesAttribute : Attribute
    {
        private new List<string> Roles;

        public AuthorizeRolesAttribute(string[] roles)
        {
            Roles = roles.ToList();
        }
    }
}