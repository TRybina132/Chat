using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class UserChatConfiguration : IEntityTypeConfiguration<UserChat>
    {
        public void Configure(EntityTypeBuilder<UserChat> builder)
        {
            builder.HasKey(uc => new
            {
                uc.UserId,
                uc.ChatId
            });

            builder.HasOne<User>(uc => uc.User)
                .WithMany(user => user.UserChats)
                .HasForeignKey(uc => uc.UserId);

            builder.HasOne<Chat>(uc => uc.Chat)
                .WithMany(chat => chat.UserChats)
                .HasForeignKey(uc => uc.ChatId);

            builder.ToTable("UserChats");
        }
    }
}
