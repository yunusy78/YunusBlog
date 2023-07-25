using Business.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Concrete;

public class ApplicationDbInitializer:IApplicationDbInitializer
{
    public static void Initialize(DataAccess.Concrete.Context db, UserManager<ApplicationUser> um,
        RoleManager<IdentityRole> rm)
    {
        

        // Delete the database before we initialize it. This is common to do during development.
        // Delete the database before we initialize it. This is common to do during development.
        //db.Database.EnsureDeleted();
        // Recreate the database and tables according to our models
        db.Database.EnsureCreated();
        // Add test data to simplify debugging and testing

        if (!rm.RoleExistsAsync(RoleService.Role_Admin).GetAwaiter().GetResult())
        {
            rm.CreateAsync(new IdentityRole(RoleService.Role_Admin)).GetAwaiter().GetResult();
            rm.CreateAsync(new IdentityRole(RoleService.Role_User_Empl)).GetAwaiter().GetResult();
            rm.CreateAsync(new IdentityRole(RoleService.Role_User_Indi)).GetAwaiter().GetResult();
            rm.CreateAsync(new IdentityRole(RoleService.Role_User_Comp)).GetAwaiter().GetResult();

            //if roles are not created, then we will create admin user as well
            
            var admin = new ApplicationUser
                { UserName = "Admin@fresh.no", Email = "Admin@fresh.no", EmailConfirmed = true };
            um.CreateAsync(admin, "Password1.").Wait();

            um.AddToRoleAsync(admin, "Admin").Wait();


            db.SaveChanges();



        }
    }


    public void Initialize()
    {
        //throw new NotImplementedException();
    }
}


