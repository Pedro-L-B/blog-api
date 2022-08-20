using Blog.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Api.EntityConfig;

public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("tb_comment");

        builder.HasKey(c => c.CommentId)
            .HasName("PK_comment");

        builder.Property(c => c.CommentId)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(c => c.Message)
            .IsRequired()
            .HasColumnName("message")
            .HasColumnType("varchar(300)");

        builder.Property(c => c.RegistrationDate)
            .IsRequired()
            .HasColumnName("registrationDate");

        builder.HasOne(p => p.Publication)
            .WithMany(c => c.Comments)
            .HasForeignKey(c => c.PublicationId);
    }
}