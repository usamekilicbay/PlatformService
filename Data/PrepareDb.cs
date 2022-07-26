using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepareDb
    {
        public static void PreparePopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }

        private static void SeedData(AppDbContext context)
        {
            if (context.Platforms.Any())
            {
                Console.WriteLine("⇒ Already filled!");
                return;
            }

            Console.WriteLine("⇒ Seeding database...");
            context.Platforms.AddRange(
               new Platform
               {
                   Name = "SignalR",
                   Publisher = "Microsoft",
                   Cost = "150$",
               }, new Platform
               {
                   Name = "React.js",
                   Publisher = "Facebook",
                   Cost = "90$",
               }, new Platform
               {
                   Name = "Kubernetes",
                   Publisher = "Cloud Native Computing Foundation",
                   Cost = "270$",
               }
           );

            context.SaveChanges();
        }
    }
}
