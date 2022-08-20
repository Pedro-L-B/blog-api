using Blog.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Api.EntityConfig;

public class PublicationConfig : IEntityTypeConfiguration<Publication>
{
    public void Configure(EntityTypeBuilder<Publication> builder)
    {
        builder.ToTable("tb_publication");

        builder.HasKey(p => p.PublicationId)
            .HasName("PK_publication");

        builder.Property(p => p.PublicationId)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(p => p.Title)
            .IsRequired()
            .HasColumnName("title")
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Message)
            .IsRequired()
            .HasColumnName("message")
            .HasColumnType("varchar(500)");

        builder.Property(p => p.RegistrationDate)
            .IsRequired()
            .HasColumnName("registrationDate");

        builder.Property(p => p.CommentLimit)
            .IsRequired()
            .HasColumnName("commentLimit");
    }
}
