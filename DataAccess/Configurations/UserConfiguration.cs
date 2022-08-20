using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder
               .Property(user => user.FirstName)
               .HasMaxLength(50);

            builder
                .Property(user => user.LastName)
                .HasMaxLength(50);
        }
    }
}
