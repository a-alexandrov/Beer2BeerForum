using Beer2Beer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beer2Beer.Data.Configuration
{
    internal class UserConfiguration: IEntityTypeConfiguration<User>
    {
        private const int MaxNameLenght = 32;

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
               .Property(f => f.FirstName)
               .HasMaxLength(MaxNameLenght)
               .IsRequired();

            builder
                .Property(f => f.LastName)
                .HasMaxLength(MaxNameLenght)
                .IsRequired();

            builder.Property(f => f.Email)
                .IsRequired();

            builder
                .HasIndex(e => e.Email)
                .IsUnique();
        }
    }
}
