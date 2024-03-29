﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Portfolio_API;

#nullable disable

namespace Portfolio_API.Migrations
{
    [DbContext(typeof(ApplicationDatabaseContext))]
    partial class ApplicationDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Portfolio_API.JobModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LanguageId")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Portfolio_API.LangModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ProjectModelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjectModelId");

                    b.ToTable("Langs");
                });

            modelBuilder.Entity("Portfolio_API.LanguageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Portfolio_API.ProjectModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("JobId")
                        .HasColumnType("integer");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("integer");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("LanguageId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Portfolio_API.TechModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("TopicId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Techs");
                });

            modelBuilder.Entity("Portfolio_API.TopicModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("LangId")
                        .HasColumnType("integer");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LangId");

                    b.HasIndex("LanguageId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Portfolio_API.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c643e81f-5f69-42bf-b30c-d470f4c6a590",
                            Email = "igormarcucci1@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "IGORMARCUCCI1@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEKFRtDHA1J4Id+LaRWZQcKmoPAW+Mqxm2P4oP/Vx99XZ+LkuJkazn/Qy7SfpAeruXQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8a0b2edd-ae07-4329-b882-52ed887f6a17",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Portfolio_API.JobModel", b =>
                {
                    b.HasOne("Portfolio_API.LanguageModel", "Language")
                        .WithMany("Jobs")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Portfolio_API.LangModel", b =>
                {
                    b.HasOne("Portfolio_API.ProjectModel", null)
                        .WithMany("Langs")
                        .HasForeignKey("ProjectModelId");
                });

            modelBuilder.Entity("Portfolio_API.ProjectModel", b =>
                {
                    b.HasOne("Portfolio_API.JobModel", "Job")
                        .WithMany("Projects")
                        .HasForeignKey("JobId");

                    b.HasOne("Portfolio_API.LanguageModel", "Language")
                        .WithMany("Projects")
                        .HasForeignKey("LanguageId");

                    b.Navigation("Job");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Portfolio_API.TechModel", b =>
                {
                    b.HasOne("Portfolio_API.TopicModel", "Topic")
                        .WithMany("Techs")
                        .HasForeignKey("TopicId");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Portfolio_API.TopicModel", b =>
                {
                    b.HasOne("Portfolio_API.LangModel", "Lang")
                        .WithMany("Topics")
                        .HasForeignKey("LangId");

                    b.HasOne("Portfolio_API.LanguageModel", "Language")
                        .WithMany("Topics")
                        .HasForeignKey("LanguageId");

                    b.Navigation("Lang");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Portfolio_API.JobModel", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Portfolio_API.LangModel", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Portfolio_API.LanguageModel", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("Projects");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Portfolio_API.ProjectModel", b =>
                {
                    b.Navigation("Langs");
                });

            modelBuilder.Entity("Portfolio_API.TopicModel", b =>
                {
                    b.Navigation("Techs");
                });
#pragma warning restore 612, 618
        }
    }
}
