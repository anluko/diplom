﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobileProjectServer.Models;

#nullable disable

namespace MobileProjectServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230216145954_MobileDataBaseIntital")]
    partial class MobileDataBaseIntital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MobileProjectServer.Models.Coordinates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("MobileProjectServer.Models.Enter_History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Last_Entry")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Enter_Histories");
                });

            modelBuilder.Entity("MobileProjectServer.Models.Friends", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FirstUsersId")
                        .HasColumnType("int");

                    b.Property<string>("Friendship_Type")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("SecondUsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstUsersId");

                    b.HasIndex("SecondUsersId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("MobileProjectServer.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Login")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Password")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Phone_Number")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Photo_Path")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MobileProjectServer.Models.Coordinates", b =>
                {
                    b.HasOne("MobileProjectServer.Models.Users", "Users")
                        .WithMany("Coordinates")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MobileProjectServer.Models.Enter_History", b =>
                {
                    b.HasOne("MobileProjectServer.Models.Users", "Users")
                        .WithMany("Enter_Histories")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MobileProjectServer.Models.Friends", b =>
                {
                    b.HasOne("MobileProjectServer.Models.Users", "FirstUsers")
                        .WithMany("Friends")
                        .HasForeignKey("FirstUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobileProjectServer.Models.Users", "SecondUsers")
                        .WithMany("Friends1")
                        .HasForeignKey("SecondUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FirstUsers");

                    b.Navigation("SecondUsers");
                });

            modelBuilder.Entity("MobileProjectServer.Models.Users", b =>
                {
                    b.Navigation("Coordinates");

                    b.Navigation("Enter_Histories");

                    b.Navigation("Friends");

                    b.Navigation("Friends1");
                });
#pragma warning restore 612, 618
        }
    }
}