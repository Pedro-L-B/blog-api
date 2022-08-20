using Blog.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Api.EntityConfig;

public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("tb_comment");
        builder.HasKey(p => p.CommentId)
            .HasName("PK_comment");
        builder.Property(p => p.Message)
            .IsRequired()
            .HasColumnName("message")
            .HasColumnType("varchar(300)");
        builder.Property(p => p.RegistrationDate)
            .IsRequired()
            .HasColumnName("registrationDate");
    }
}