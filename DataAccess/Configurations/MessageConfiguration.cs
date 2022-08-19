using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(message => message.Id);

            builder.Property(message => message.SentAt)
                .HasColumnType("DATETIME");

            builder.HasOne(message => message.Sender)
                .WithMany(user => user.Messages)
                .HasForeignKey(message => message.SenderId);

            builder.HasOne(message => message.Chat)
                .WithMany(chat => chat.Messages)
                .HasForeignKey(message => message.ChatId);

            builder.ToTable("Messages");
        }
    }
}
