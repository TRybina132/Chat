using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeders
{
    public static class UserSeeder
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();

            string karenUsername = "6_Ikaren";
            string karenPassword = "iLoveDogs222";

            string jonyUsername = "coolJony222";
            string jonyPassword = "Iam20040920";

            string nancyUsername = "nancy_2200";
            string nancyPassword = "nancy20002";

            User karen = new User()
            {
                Id = 1,
                UserName = karenUsername,
                NormalizedUserName = karenUsername.ToUpper(),
                FirstName = "Karen",
                LastName = "Mkadey",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            karen.PasswordHash = hasher.HashPassword(karen, karenPassword);

            User jony = new User()
            {
                Id = 3,
                UserName = jonyUsername,
                NormalizedUserName = jonyUsername.ToUpper(),
                FirstName = "Jony",
                LastName = "Kinds",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            jony.PasswordHash = hasher.HashPassword(jony, jonyPassword);

            User nancy = new User()
            {
                Id = 2,
                UserName = nancyUsername,
                NormalizedUserName = nancyUsername.ToUpper(),
                FirstName = "Nancy",
                LastName = "Petrad",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            nancy.PasswordHash = hasher.HashPassword(nancy, nancyPassword);

            modelBuilder.Entity<User>().HasData(karen, nancy, jony);
        }
    }
}
