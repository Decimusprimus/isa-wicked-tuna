﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WickedTunaInfrastructure;

namespace WickedTunaInfrastructure.Migrations
{
    [DbContext(typeof(WickedTunaDbContext))]
    [Migration("20220531011250_configured_other_users_and_entities")]
    partial class configured_other_users_and_entities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WickedTunaCore.AdventuresLessons.AdventureLesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CancellationFee")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("InstructorId")
                        .HasColumnType("text");

                    b.Property<int>("MaxNumberOfPeople")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("AdventrueLessons");
                });

            modelBuilder.Entity("WickedTunaCore.Auth.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WickedTunaCore.Auth.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ExpiryOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("text");

                    b.Property<DateTime>("RevokedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("WickedTunaCore.Boats.Boat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BoatOwnerId")
                        .HasColumnType("text");

                    b.Property<int>("CancellationFee")
                        .HasColumnType("integer");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("EngineNumger")
                        .HasColumnType("text");

                    b.Property<float>("EnginePower")
                        .HasColumnType("real");

                    b.Property<float>("MaximumSpeed")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BoatOwnerId");

                    b.ToTable("Boats");
                });

            modelBuilder.Entity("WickedTunaCore.Cottages.Cottage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdditionalServices")
                        .HasColumnType("text");

                    b.Property<string>("CottageOwnerId")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CottageOwnerId");

                    b.ToTable("Cottages");
                });

            modelBuilder.Entity("WickedTunaCore.Users.BoatOwner", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("County")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("BoatOwners");
                });

            modelBuilder.Entity("WickedTunaCore.Users.Client", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("County")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("WickedTunaCore.Users.CottageOwner", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("County")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("CottageOwners");
                });

            modelBuilder.Entity("WickedTunaCore.Users.Instructor", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("County")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("ShortBiography")
                        .HasColumnType("text");

                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("WickedTunaCore.Users.SystemAdmin", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("County")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("PasswordChanged")
                        .HasColumnType("boolean");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("SystemAdmins");
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
                    b.HasOne("WickedTunaCore.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WickedTunaCore.Auth.ApplicationUser", null)
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

                    b.HasOne("WickedTunaCore.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WickedTunaCore.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WickedTunaCore.AdventuresLessons.AdventureLesson", b =>
                {
                    b.HasOne("WickedTunaCore.Users.Instructor", "Instructor")
                        .WithMany("AdventureLessons")
                        .HasForeignKey("InstructorId");

                    b.OwnsOne("WickedTunaCore.Common.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("AdventureLessonId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasColumnType("text")
                                .HasColumnName("City");

                            b1.Property<string>("County")
                                .HasColumnType("text")
                                .HasColumnName("County");

                            b1.Property<string>("Street")
                                .HasColumnType("text")
                                .HasColumnName("Street");

                            b1.HasKey("AdventureLessonId");

                            b1.ToTable("AdventrueLessons");

                            b1.WithOwner()
                                .HasForeignKey("AdventureLessonId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("WickedTunaCore.Auth.RefreshToken", b =>
                {
                    b.HasOne("WickedTunaCore.Auth.ApplicationUser", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WickedTunaCore.Boats.Boat", b =>
                {
                    b.HasOne("WickedTunaCore.Users.BoatOwner", "BoatOwner")
                        .WithMany("Boats")
                        .HasForeignKey("BoatOwnerId");

                    b.OwnsOne("WickedTunaCore.Common.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("BoatId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasColumnType("text")
                                .HasColumnName("City");

                            b1.Property<string>("County")
                                .HasColumnType("text")
                                .HasColumnName("County");

                            b1.Property<string>("Street")
                                .HasColumnType("text")
                                .HasColumnName("Street");

                            b1.HasKey("BoatId");

                            b1.ToTable("Boats");

                            b1.WithOwner()
                                .HasForeignKey("BoatId");
                        });

                    b.Navigation("Address");

                    b.Navigation("BoatOwner");
                });

            modelBuilder.Entity("WickedTunaCore.Cottages.Cottage", b =>
                {
                    b.HasOne("WickedTunaCore.Users.CottageOwner", "CottageOwner")
                        .WithMany("Cottages")
                        .HasForeignKey("CottageOwnerId");

                    b.OwnsOne("WickedTunaCore.Common.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CottageId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasColumnType("text")
                                .HasColumnName("City");

                            b1.Property<string>("County")
                                .HasColumnType("text")
                                .HasColumnName("County");

                            b1.Property<string>("Street")
                                .HasColumnType("text")
                                .HasColumnName("Street");

                            b1.HasKey("CottageId");

                            b1.ToTable("Cottages");

                            b1.WithOwner()
                                .HasForeignKey("CottageId");
                        });

                    b.Navigation("Address");

                    b.Navigation("CottageOwner");
                });

            modelBuilder.Entity("WickedTunaCore.Users.BoatOwner", b =>
                {
                    b.HasOne("WickedTunaCore.Auth.ApplicationUser", "ApplicationUser")
                        .WithOne("BoatOwner")
                        .HasForeignKey("WickedTunaCore.Users.BoatOwner", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("WickedTunaCore.Users.Client", b =>
                {
                    b.HasOne("WickedTunaCore.Auth.ApplicationUser", "ApplicationUser")
                        .WithOne("Client")
                        .HasForeignKey("WickedTunaCore.Users.Client", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("WickedTunaCore.Users.CottageOwner", b =>
                {
                    b.HasOne("WickedTunaCore.Auth.ApplicationUser", "ApplicationUser")
                        .WithOne("CottageOwner")
                        .HasForeignKey("WickedTunaCore.Users.CottageOwner", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("WickedTunaCore.Users.Instructor", b =>
                {
                    b.HasOne("WickedTunaCore.Auth.ApplicationUser", "ApplicationUser")
                        .WithOne("Instructor")
                        .HasForeignKey("WickedTunaCore.Users.Instructor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("WickedTunaCore.Users.SystemAdmin", b =>
                {
                    b.HasOne("WickedTunaCore.Auth.ApplicationUser", "ApplicationUser")
                        .WithOne("SystemAdmin")
                        .HasForeignKey("WickedTunaCore.Users.SystemAdmin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("WickedTunaCore.Auth.ApplicationUser", b =>
                {
                    b.Navigation("BoatOwner");

                    b.Navigation("Client");

                    b.Navigation("CottageOwner");

                    b.Navigation("Instructor");

                    b.Navigation("RefreshTokens");

                    b.Navigation("SystemAdmin");
                });

            modelBuilder.Entity("WickedTunaCore.Users.BoatOwner", b =>
                {
                    b.Navigation("Boats");
                });

            modelBuilder.Entity("WickedTunaCore.Users.CottageOwner", b =>
                {
                    b.Navigation("Cottages");
                });

            modelBuilder.Entity("WickedTunaCore.Users.Instructor", b =>
                {
                    b.Navigation("AdventureLessons");
                });
#pragma warning restore 612, 618
        }
    }
}
