using Beer2Beer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beer2Beer.Data.Configuration
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        private const int MinTitleLength = 16;
        private const int MaxTitleLenght = 64;
        private const int MinContentLength = 32;
        private const int MaxContentLength = 8192;

        public void Configure(EntityTypeBuilder<Post> builder)
        {

            builder.
                HasCheckConstraint("CK_Post_Title"
                , $"LEN([Title]) >= {MinTitleLength}");

            builder
               .Property(f => f.Title)
               .HasMaxLength(MaxTitleLenght)
               .IsRequired();

            builder.
                HasCheckConstraint("CK_Post_Content"
                , $"LEN([Content]) >= {MinContentLength}");

            builder
                .Property(f => f.Content)
                .HasMaxLength(MaxContentLength)
                .IsRequired();
        }
    }
}
