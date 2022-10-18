using Beer2Beer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beer2Beer.Data.Configuration
{
    internal class UserConfiguration: IEntityTypeConfiguration<User>
    {
        private const int MinNameLength = 4;
        private const int MaxNameLenght = 32;
        private const int maxAvatarImageSize = 1048576;

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.
                HasCheckConstraint("CK_User_FirstName"
                , $"LEN([FirstName]) >= {MinNameLength}");

            builder
               .Property(f => f.FirstName)
               .HasMaxLength(MaxNameLenght)
               .IsRequired();

            builder.
                HasCheckConstraint("CK_User_LastName"
                , $"LEN([LastName]) >= {MinNameLength}");

            builder
                .Property(f => f.LastName)
                .HasMaxLength(MaxNameLenght)
                .IsRequired();

            builder.Property(f => f.Email)
                .IsRequired();

            builder
                .HasIndex(e => e.Email)
                .IsUnique();

            builder.Property(i => i.AvatarImage)
                .HasMaxLength(maxAvatarImageSize);
        }
    }
}
