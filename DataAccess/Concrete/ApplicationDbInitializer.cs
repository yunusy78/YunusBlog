using Business.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Concrete
{
    public class ApplicationDbInitializer : IApplicationDbInitializer
    {
        public static void Initialize(Context db, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> rm)
        {

            
             //db.Database.EnsureCreated();
            // Add test data to simplify debugging and testing

            db.SaveChanges();



            
        }


        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}