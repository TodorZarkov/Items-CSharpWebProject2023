﻿// <auto-generated />
using System;
using Items.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace Items.Data.Migrations
{
    [DbContext(typeof(ItemsDbContext))]
    partial class ItemsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Items.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                });

            modelBuilder.Entity("Items.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatorId = new Guid("04023b09-a38e-48e1-1082-08db8d0db110"),
                            Name = "Various"
                        },
                        new
                        {
                            Id = 2,
                            CreatorId = new Guid("04023b09-a38e-48e1-1082-08db8d0db110"),
                            Name = "Toys"
                        },
                        new
                        {
                            Id = 3,
                            CreatorId = new Guid("04023b09-a38e-48e1-1082-08db8d0db110"),
                            Name = "Cars"
                        },
                        new
                        {
                            Id = 4,
                            CreatorId = new Guid("04023b09-a38e-48e1-1082-08db8d0db110"),
                            Name = "Weapons"
                        },
                        new
                        {
                            Id = 5,
                            CreatorId = new Guid("04023b09-a38e-48e1-1082-08db8d0db110"),
                            Name = "Puzzles"
                        });
                });

            modelBuilder.Entity("Items.Data.Models.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BuyerComment")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("BuyerConfirm")
                        .HasColumnType("bit");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("BuyerOk")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ContractDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliverDue")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Fulfilled")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Quantity")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("SellerComment")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("SellerOk")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SendDue")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("SellerId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Items.Data.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsoCode = "USD",
                            Name = "United States dollar",
                            Symbol = "$"
                        },
                        new
                        {
                            Id = 2,
                            IsoCode = "EUR",
                            Name = "Euro",
                            Symbol = "€"
                        },
                        new
                        {
                            Id = 3,
                            IsoCode = "BGN",
                            Name = "Bulgarian lev",
                            Symbol = "Lev"
                        });
                });

            modelBuilder.Entity("Items.Data.Models.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Items.Data.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Access")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AcquiredDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("AcquiredPrice")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal?>("CurrentPrice")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid?>("DocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndSell")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ItemVisibilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MainPictureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime?>("StartSell")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("ItemVisibilityId")
                        .IsUnique();

                    b.HasIndex("LocationId");

                    b.HasIndex("MainPictureId")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UnitId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Items.Data.Models.ItemCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemsCategories");
                });

            modelBuilder.Entity("Items.Data.Models.ItemVisibility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AcquireDocument")
                        .HasColumnType("int");

                    b.Property<int>("AcquiredDate")
                        .HasColumnType("int");

                    b.Property<int>("AcquiredPrice")
                        .HasColumnType("int");

                    b.Property<int>("AddedOn")
                        .HasColumnType("int");

                    b.Property<int>("CurrentPrice")
                        .HasColumnType("int");

                    b.Property<int>("Description")
                        .HasColumnType("int");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int>("Offers")
                        .HasColumnType("int");

                    b.Property<int>("Owner")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ItemVisibilities");
                });

            modelBuilder.Entity("Items.Data.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Geometry>("Border")
                        .HasColumnType("geography");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Point>("GeoLocation")
                        .HasColumnType("geography");

                    b.Property<Guid>("LocationVisibilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Town")
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LocationVisibilityId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Items.Data.Models.LocationVisibility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Address")
                        .HasColumnType("int");

                    b.Property<int>("Border")
                        .HasColumnType("int");

                    b.Property<int>("Country")
                        .HasColumnType("int");

                    b.Property<int>("Description")
                        .HasColumnType("int");

                    b.Property<int>("GeoLocation")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int>("Town")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LocationVisibilities");
                });

            modelBuilder.Entity("Items.Data.Models.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BarterItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("BarterQuantity")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal>("Quantity")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Value")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Id");

                    b.HasIndex("BarterItemId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("ItemId");

                    b.HasIndex("LocationId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Items.Data.Models.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Items.Data.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Items.Data.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pieces",
                            Symbol = "pcs"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Meter",
                            Symbol = "m"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Square Meter",
                            Symbol = "m2"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Kilogram",
                            Symbol = "kg"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Items.Data.Models.Category", b =>
                {
                    b.HasOne("Items.Data.Models.ApplicationUser", "Creator")
                        .WithMany("Categories")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Items.Data.Models.Contract", b =>
                {
                    b.HasOne("Items.Data.Models.ApplicationUser", "Buyer")
                        .WithMany("ContractsAsBuyer")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.ApplicationUser", "Seller")
                        .WithMany("ContractsAsSeller")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Currency");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Items.Data.Models.Item", b =>
                {
                    b.HasOne("Items.Data.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Items.Data.Models.Document", "AcquireDocument")
                        .WithMany("Items")
                        .HasForeignKey("DocumentId");

                    b.HasOne("Items.Data.Models.ItemVisibility", "ItemVisibility")
                        .WithOne("Item")
                        .HasForeignKey("Items.Data.Models.Item", "ItemVisibilityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.Location", "Location")
                        .WithMany("Items")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.Picture", "MainPicture")
                        .WithOne()
                        .HasForeignKey("Items.Data.Models.Item", "MainPictureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.ApplicationUser", "Owner")
                        .WithMany("Items")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.Place", "Place")
                        .WithMany("Items")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AcquireDocument");

                    b.Navigation("Currency");

                    b.Navigation("ItemVisibility");

                    b.Navigation("Location");

                    b.Navigation("MainPicture");

                    b.Navigation("Owner");

                    b.Navigation("Place");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Items.Data.Models.ItemCategory", b =>
                {
                    b.HasOne("Items.Data.Models.Category", "Category")
                        .WithMany("ItemsCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.Item", "Item")
                        .WithMany("ItemsCategories")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Items.Data.Models.Location", b =>
                {
                    b.HasOne("Items.Data.Models.LocationVisibility", "LocationVisibility")
                        .WithOne("Location")
                        .HasForeignKey("Items.Data.Models.Location", "LocationVisibilityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.ApplicationUser", "User")
                        .WithMany("Locations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LocationVisibility");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Items.Data.Models.Offer", b =>
                {
                    b.HasOne("Items.Data.Models.Item", "BarterItem")
                        .WithMany("AsBarterForOffers")
                        .HasForeignKey("BarterItemId");

                    b.HasOne("Items.Data.Models.ApplicationUser", "Buyer")
                        .WithMany("Offers")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.Item", "Item")
                        .WithMany("Offers")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.Location", "BuyerLocation")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("BarterItem");

                    b.Navigation("Buyer");

                    b.Navigation("BuyerLocation");

                    b.Navigation("Currency");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Items.Data.Models.Picture", b =>
                {
                    b.HasOne("Items.Data.Models.Item", "Item")
                        .WithMany("Pictures")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Items.Data.Models.Place", b =>
                {
                    b.HasOne("Items.Data.Models.Location", "Location")
                        .WithMany("Places")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Items.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Items.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Items.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Items.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Items.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("ContractsAsBuyer");

                    b.Navigation("ContractsAsSeller");

                    b.Navigation("Items");

                    b.Navigation("Locations");

                    b.Navigation("Offers");
                });

            modelBuilder.Entity("Items.Data.Models.Category", b =>
                {
                    b.Navigation("ItemsCategories");
                });

            modelBuilder.Entity("Items.Data.Models.Document", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Items.Data.Models.Item", b =>
                {
                    b.Navigation("AsBarterForOffers");

                    b.Navigation("ItemsCategories");

                    b.Navigation("Offers");

                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("Items.Data.Models.ItemVisibility", b =>
                {
                    b.Navigation("Item")
                        .IsRequired();
                });

            modelBuilder.Entity("Items.Data.Models.Location", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Places");
                });

            modelBuilder.Entity("Items.Data.Models.LocationVisibility", b =>
                {
                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("Items.Data.Models.Place", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
