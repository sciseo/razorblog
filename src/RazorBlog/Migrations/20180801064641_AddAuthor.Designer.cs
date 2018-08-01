﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorBlog;

namespace RazorBlog.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20180801064641_AddAuthor")]
    partial class AddAuthor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("RazorBlog.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("RazorBlog_Categories");
                });

            modelBuilder.Entity("RazorBlog.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorEmail")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<bool>("IsApproved");

                    b.Property<Guid>("PostId");

                    b.Property<DateTime>("Published");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("RazorBlog_Comments");
                });

            modelBuilder.Entity("RazorBlog.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryId");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256);

                    b.Property<string>("MetaKeywords")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("Published");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("RazorBlog_Posts");
                });

            modelBuilder.Entity("RazorBlog.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("PostId");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("PostId", "Slug")
                        .IsUnique();

                    b.ToTable("RazorBlog_Tags");
                });

            modelBuilder.Entity("RazorBlog.Models.Comment", b =>
                {
                    b.HasOne("RazorBlog.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RazorBlog.Models.Post", b =>
                {
                    b.HasOne("RazorBlog.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.OwnsOne("RazorBlog.Models.Author", "Author", b1 =>
                        {
                            b1.Property<Guid?>("PostId");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnName("AuthorEmail")
                                .HasMaxLength(128);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnName("AuthorName")
                                .HasMaxLength(128);

                            b1.ToTable("RazorBlog_Posts");

                            b1.HasOne("RazorBlog.Models.Post")
                                .WithOne("Author")
                                .HasForeignKey("RazorBlog.Models.Author", "PostId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("RazorBlog.Models.MarkdownString", "Body", b1 =>
                        {
                            b1.Property<Guid>("PostId");

                            b1.Property<string>("Value")
                                .HasColumnName("Body");

                            b1.ToTable("RazorBlog_Posts");

                            b1.HasOne("RazorBlog.Models.Post")
                                .WithOne("Body")
                                .HasForeignKey("RazorBlog.Models.MarkdownString", "PostId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("RazorBlog.Models.MarkdownString", "Excerpt", b1 =>
                        {
                            b1.Property<Guid>("PostId");

                            b1.Property<string>("Value")
                                .HasColumnName("Excerpt");

                            b1.ToTable("RazorBlog_Posts");

                            b1.HasOne("RazorBlog.Models.Post")
                                .WithOne("Excerpt")
                                .HasForeignKey("RazorBlog.Models.MarkdownString", "PostId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("RazorBlog.Models.Tag", b =>
                {
                    b.HasOne("RazorBlog.Models.Post")
                        .WithMany("Tags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}