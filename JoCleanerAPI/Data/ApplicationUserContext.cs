using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JoCleanerAPI.Data
{
    public class ApplicationUserContext : IdentityDbContext
    {
        public ApplicationUserContext(DbContextOptions options):base(options) 
        {

        }
    }
   
}
