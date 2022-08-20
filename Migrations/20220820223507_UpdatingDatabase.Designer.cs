﻿// <auto-generated />
using System;
using Blog.Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace blog_api.Migrations
{
    [DbContext(typeof(BlogApiContext))]
    [Migration("20220820223507_UpdatingDatabase")]
    partial class UpdatingDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Blog.Api.Model.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("message");

                    b.Property<int>("PublicationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("registrationDate");

                    b.HasKey("CommentId")
                        .HasName("PK_comment");

                    b.HasIndex("PublicationId");

                    b.ToTable("tb_comment", (string)null);
                });

            modelBuilder.Entity("Blog.Api.Model.Publication", b =>
                {
                    b.Property<int>("PublicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CommentLimit")
                        .HasColumnType("int")
                        .HasColumnName("commentLimit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("message");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("registrationDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.HasKey("PublicationId")
                        .HasName("PK_publication");

                    b.ToTable("tb_publication", (string)null);
                });

            modelBuilder.Entity("Blog.Api.Model.Comment", b =>
                {
                    b.HasOne("Blog.Api.Model.Publication", "Publication")
                        .WithMany("Comments")
                        .HasForeignKey("PublicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publication");
                });

            modelBuilder.Entity("Blog.Api.Model.Publication", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}