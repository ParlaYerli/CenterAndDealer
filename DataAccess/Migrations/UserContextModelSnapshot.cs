﻿// <auto-generated />
using System;
using DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Concrete.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LogTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Entities.Concrete.LogType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2020, 6, 26, 11, 55, 31, 666, DateTimeKind.Local).AddTicks(4176),
                            Name = "Login"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 2,
                            CreatedDate = new DateTime(2020, 6, 26, 11, 55, 31, 652, DateTimeKind.Local).AddTicks(6245),
                            Name = "CallCenter"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 2,
                            CreatedDate = new DateTime(2020, 6, 26, 11, 55, 31, 660, DateTimeKind.Local).AddTicks(3184),
                            Name = "Dealer"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DealerId")
                        .HasColumnType("int");

                    b.Property<string>("DealerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Test mah. Test sokak.",
                            City = "İstanbul",
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2020, 6, 26, 11, 55, 31, 664, DateTimeKind.Local).AddTicks(9527),
                            DealerId = 123123,
                            DealerName = "Dealer1",
                            FullName = "Test",
                            IsActive = true,
                            Password = "023a2d11e01237fb6eab5ca926facd39ee44b1683e84295cccef79b7df905195",
                            Phone = "5552223355",
                            RoleId = 1,
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2020, 6, 26, 11, 55, 31, 664, DateTimeKind.Local).AddTicks(7804)
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2020, 6, 26, 11, 55, 31, 665, DateTimeKind.Local).AddTicks(8788),
                            FullName = "Dealer2",
                            IsActive = true,
                            Password = "023a2d11e01237fb6eab5ca926facd39ee44b1683e84295cccef79b7df905195",
                            RoleId = 2,
                            UpdatedBy = 1,
                            UpdatedDate = new DateTime(2020, 6, 26, 11, 55, 31, 665, DateTimeKind.Local).AddTicks(8747)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}