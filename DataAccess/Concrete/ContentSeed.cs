using System;
using Entity.Concrete; 

namespace DataAccess.Concrete
{
    public class ContextSeed
    {
        public static void SeedData(Context context)
        {
            
            var blog = new Blog
            {


            };

            
           
            var about = new About
            {
                
            };

            

            context.SaveChanges(); 
        }
    }
}



