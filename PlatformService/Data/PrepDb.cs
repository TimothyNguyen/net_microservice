using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {

        public static void PrepPopulation(IApplicationBuilder app) {
            using(var serviceScope = app.ApplicationServices.CreateScope()) 
            {
                // Similar with uow
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        // Call this method with constructor injection
        private static void SeedData(AppDbContext? context) {

            if(context == null) {
                throw new ArgumentNullException(nameof(context));
            }

            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                
                context.Platforms.AddRange(
                    new Platform() {Name="Dot Net", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="SQL Server Express", Publisher="Microsoft",  Cost="Free"},
                    new Platform() {Name="Kubernetes", Publisher="Cloud Native Computing Foundation",  Cost="Free"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}