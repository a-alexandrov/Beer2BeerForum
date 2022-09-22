using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beer2Beer.Data.Configuration
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        private const int MaxTitleLenght = 32;
        private const int MaxContentLength = 8192;

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
               .Property(f => f.Title)
               .HasMaxLength(MaxTitleLenght)
               .IsRequired();

            builder
                .Property(f => f.Content)
                .HasMaxLength(MaxContentLength)
                .IsRequired();
        }
    }
}
