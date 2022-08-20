using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(chat => chat.Id);

            builder.Property(chat => chat.Name)
                .HasMaxLength(30);

            builder.ToTable("Chats");
        }
    }
}
