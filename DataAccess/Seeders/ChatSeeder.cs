using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeders
{
    public static class ChatSeeder
    {
        public static void SeedChats(this ModelBuilder modelBuilder)
        {
            Chat cSharpDiscussing = new Chat
            {
                Id = 1,
                Name = "C# discussing",
                Type = ChatType.Group
            };

            Chat work = new Chat
            {
                Id = 2,
                Name = "Best senior developers",
                Type = ChatType.Group
            };

            modelBuilder.Entity<Chat>().HasData(cSharpDiscussing, work);
        }
    }
}
