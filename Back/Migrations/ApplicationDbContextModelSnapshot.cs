﻿// <auto-generated />
using System;
using CohorteApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CohorteApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CohorteApi.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "8a650eb8-3760-4151-b955-962b45b77c50",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c00050ed-c5ed-4840-8737-ffac45792473",
                            Email = "nadir@mailinator.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "NADIR@MAILINATOR.COM",
                            NormalizedUserName = "NADIR",
                            PasswordHash = "AQAAAAEAACcQAAAAEDcv6K4z7RKGrO9SKyQ1OCrtytsQaCXdEF8ai2Mez5W86/6/oYDbHLWMEkM/E/rB1w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "09728ba5-ee9f-4ad9-86ba-2b2fc8efd21d",
                            TwoFactorEnabled = false,
                            UserName = "nadir"
                        },
                        new
                        {
                            Id = "dfe1c928-9648-44b6-84a9-c2bd2ff75e25",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "dda1d50a-e730-4807-b662-841246307bf3",
                            Email = "alex@mailinator.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ALEX@MAILINATOR.COM",
                            NormalizedUserName = "ALEX",
                            PasswordHash = "AQAAAAEAACcQAAAAELUFb5JguP0HnUcyrCi+pqYGZGuPUqt4fq+8uVmQWUNZ2/GID7krycdjAndISPJblg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "36effbae-67d9-4f21-b8e1-0de9b9db36fc",
                            TwoFactorEnabled = false,
                            UserName = "alex"
                        },
                        new
                        {
                            Id = "5cf8f0cb-f806-4c48-a3d1-6a00b6debdae",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e8f5e15a-0e4c-404d-ab60-3251ade05cca",
                            Email = "diego@mailinator.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "DIEGO@MAILINATOR.COM",
                            NormalizedUserName = "DIEGO",
                            PasswordHash = "AQAAAAEAACcQAAAAEFyjrybJ/eDOW/Hd9hSR1R43e2JbMZfUtq6JCd2U+p038Rks7xwRCKBYPZ3Zf7PJKg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b730d4ef-ae82-47d4-97de-374df745908b",
                            TwoFactorEnabled = false,
                            UserName = "diego"
                        },
                        new
                        {
                            Id = "a729156f-f5dd-450b-8817-4ef2763b201e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "20d91338-698c-4c3b-919b-534a7bbcca69",
                            Email = "max@mailinator.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MAX@MAILINATOR.COM",
                            NormalizedUserName = "MAX",
                            PasswordHash = "AQAAAAEAACcQAAAAEK/zD5O5GjEifG98Tx9LsOFtZxmbF8SPbdHnR2msBppGSaixjmqpZs13sFPjDCQmGw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "eae8f57d-4cde-476e-8555-14e74f90f37e",
                            TwoFactorEnabled = false,
                            UserName = "max"
                        },
                        new
                        {
                            Id = "7af2c5e3-f049-4dc8-b458-5d295276e791",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "16d55461-bc7b-48dd-ad07-e49461daa66e",
                            Email = "manuel@mailinator.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MANUEL@MAILINATOR.COM",
                            NormalizedUserName = "MANUEL",
                            PasswordHash = "AQAAAAEAACcQAAAAEPPHUnJLjx93t3tHNOiJmWs3nFYX03VdFMa9bzmP9rSFz9t/JY7vblKKuMiAjjkH8A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b75e9086-f21c-4f14-a3dd-1873796de082",
                            TwoFactorEnabled = false,
                            UserName = "manuel"
                        },
                        new
                        {
                            Id = "b630bcee-5405-41b5-8ad5-d9c97558f59f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c7016d8d-fb72-4f74-9fb4-8784f69089a9",
                            Email = "any@mailinator.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ANY@MAILINATOR.COM",
                            NormalizedUserName = "ANY",
                            PasswordHash = "AQAAAAEAACcQAAAAENQmy5JgqS35WWrkI2LNms8qU16t6mGyx6iEO0pPJz2/o2KgqabB1ZQSDGzi+I/+Mg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "928e17e2-29e9-4fd6-9850-de6b8c4df6e3",
                            TwoFactorEnabled = false,
                            UserName = "any"
                        },
                        new
                        {
                            Id = "8cdc3110-1229-4f5d-a603-8b49e7e18681",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9707e5b2-9239-4cf2-9ed2-587478b68691",
                            Email = "bel@mailinator.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "BEL@MAILINATOR.COM",
                            NormalizedUserName = "BEL",
                            PasswordHash = "AQAAAAEAACcQAAAAEGFU50RWyyWwSAAZ6u3i+o2aM7VOzinhYRSJHRfrTFCyIVhWlGR+lpuFJMi/S9CbZA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0ff2a92f-88d7-440e-b1e0-0edc642cd8fe",
                            TwoFactorEnabled = false,
                            UserName = "bel"
                        },
                        new
                        {
                            Id = "7b64ea7d-f893-4023-9b63-18cd10a00f81",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d678e972-7c1d-44ff-9ede-43a659620a04",
                            Email = "d@mailinator.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "D@MAILINATOR.COM",
                            NormalizedUserName = "D",
                            PasswordHash = "AQAAAAEAACcQAAAAEHpP0r6L5FlEAWS5avXT2CFtj6aj0Z4sDBDF6S5sTcEmrN/bTXddrPitD0L/fXaW3w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3d52be19-3e4b-47f8-8d38-083a6b41897d",
                            TwoFactorEnabled = false,
                            UserName = "d"
                        });
                });

            modelBuilder.Entity("CohorteApi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Musica"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Familiar"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Deporte"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Seminarios"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cursos y Talleres"
                        });
                });

            modelBuilder.Entity("CohorteApi.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FrontPageImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Venue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VenueImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CohorteApi.Models.Newsletter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Newsletters");
                });

            modelBuilder.Entity("CohorteApi.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsShowed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("CohorteApi.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("CohorteApi.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("CohorteApi.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateSubscribed")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateSubscribed = new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "test@mailinator.com",
                            IsActive = true
                        },
                        new
                        {
                            Id = 2,
                            DateSubscribed = new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "test2@mailinator.com",
                            IsActive = true
                        },
                        new
                        {
                            Id = 3,
                            DateSubscribed = new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "test3@mailinator.com",
                            IsActive = true
                        },
                        new
                        {
                            Id = 4,
                            DateSubscribed = new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "test4@mailinator.com",
                            IsActive = true
                        },
                        new
                        {
                            Id = 5,
                            DateSubscribed = new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "test5@mailinator.com",
                            IsActive = true
                        },
                        new
                        {
                            Id = 6,
                            DateSubscribed = new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "test6@mailinator.com",
                            IsActive = true
                        },
                        new
                        {
                            Id = 7,
                            DateSubscribed = new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "test7@mailinator.com",
                            IsActive = true
                        },
                        new
                        {
                            Id = 8,
                            DateSubscribed = new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "test8@mailinator.com",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "9c751ded-c072-4e1d-bca5-2e348d57678b",
                            ConcurrencyStamp = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "0e57fb63-fb07-43b6-b4de-08587879713e",
                            ConcurrencyStamp = "2",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "8a650eb8-3760-4151-b955-962b45b77c50",
                            RoleId = "0e57fb63-fb07-43b6-b4de-08587879713e"
                        },
                        new
                        {
                            UserId = "dfe1c928-9648-44b6-84a9-c2bd2ff75e25",
                            RoleId = "0e57fb63-fb07-43b6-b4de-08587879713e"
                        },
                        new
                        {
                            UserId = "5cf8f0cb-f806-4c48-a3d1-6a00b6debdae",
                            RoleId = "0e57fb63-fb07-43b6-b4de-08587879713e"
                        },
                        new
                        {
                            UserId = "a729156f-f5dd-450b-8817-4ef2763b201e",
                            RoleId = "0e57fb63-fb07-43b6-b4de-08587879713e"
                        },
                        new
                        {
                            UserId = "7af2c5e3-f049-4dc8-b458-5d295276e791",
                            RoleId = "0e57fb63-fb07-43b6-b4de-08587879713e"
                        },
                        new
                        {
                            UserId = "b630bcee-5405-41b5-8ad5-d9c97558f59f",
                            RoleId = "0e57fb63-fb07-43b6-b4de-08587879713e"
                        },
                        new
                        {
                            UserId = "8cdc3110-1229-4f5d-a603-8b49e7e18681",
                            RoleId = "0e57fb63-fb07-43b6-b4de-08587879713e"
                        },
                        new
                        {
                            UserId = "7b64ea7d-f893-4023-9b63-18cd10a00f81",
                            RoleId = "0e57fb63-fb07-43b6-b4de-08587879713e"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CohorteApi.Models.Event", b =>
                {
                    b.HasOne("CohorteApi.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CohorteApi.Models.Review", b =>
                {
                    b.HasOne("CohorteApi.Models.Event", "Event")
                        .WithMany("Reviews")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CohorteApi.Models.AppUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CohorteApi.Models.Sale", b =>
                {
                    b.HasOne("CohorteApi.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CohorteApi.Models.AppUser", "User")
                        .WithMany("Sales")
                        .HasForeignKey("UserId");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CohorteApi.Models.Section", b =>
                {
                    b.HasOne("CohorteApi.Models.Event", null)
                        .WithMany("Sections")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CohorteApi.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CohorteApi.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CohorteApi.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CohorteApi.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CohorteApi.Models.AppUser", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("CohorteApi.Models.Event", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}