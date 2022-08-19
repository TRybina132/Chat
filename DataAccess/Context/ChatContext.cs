using Core.Entities;
using DataAccess.Configurations;
using DataAccess.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class ChatContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ChatContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);

            builder.SeedUsers();
        }

    }
}
