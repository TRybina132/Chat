using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    //  ᓚᘏᗢ Generic type int - indicates which
    //          typr we're uisng for primary kery
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
