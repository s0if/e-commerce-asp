﻿// <auto-generated />
using System;
using E_commerce_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_commerce_Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_commerce_core.Models.Cities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("governmetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("governmetId");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("E_commerce_core.Models.Classifications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("classifications");
                });

            modelBuilder.Entity("E_commerce_core.Models.CustomerStores", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("StoresId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId", "StoresId");

                    b.HasIndex("StoresId");

                    b.ToTable("customerStores");
                });

            modelBuilder.Entity("E_commerce_core.Models.Governments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("governments");
                });

            modelBuilder.Entity("E_commerce_core.Models.InvItemStores", b =>
                {
                    b.Property<int>("StoresId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<int>("Factory")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<double>("ReservedQuantity")
                        .HasColumnType("float");

                    b.HasKey("StoresId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("invItemStores");
                });

            modelBuilder.Entity("E_commerce_core.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPosted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReviewed")
                        .HasColumnType("bit");

                    b.Property<double>("NetPrice")
                        .HasColumnType("float");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("invoices");
                });

            modelBuilder.Entity("E_commerce_core.Models.InvoiceDetails", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("invoicesDetails");
                });

            modelBuilder.Entity("E_commerce_core.Models.Items", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SubGroupTwoId")
                        .HasColumnType("int");

                    b.Property<int>("SubGroupsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MainGroupId");

                    b.HasIndex("SubGroupTwoId");

                    b.HasIndex("SubGroupsId");

                    b.ToTable("items");
                });

            modelBuilder.Entity("E_commerce_core.Models.ItemsUnits", b =>
                {
                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Factory")
                        .HasColumnType("int");

                    b.HasKey("UnitId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("itemsUnits");
                });

            modelBuilder.Entity("E_commerce_core.Models.MainGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("mainGroups");
                });

            modelBuilder.Entity("E_commerce_core.Models.ShoppingCartItems", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("SoresId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId", "ItemId", "SoresId");

                    b.HasIndex("ItemId");

                    b.HasIndex("SoresId");

                    b.ToTable("shoppingCartItems");
                });

            modelBuilder.Entity("E_commerce_core.Models.Stores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("GovernmentsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("GovernmentsId");

                    b.HasIndex("ZoneId");

                    b.ToTable("stores");
                });

            modelBuilder.Entity("E_commerce_core.Models.SubGroupTwo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MainGroupsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubGroupsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MainGroupsId");

                    b.HasIndex("SubGroupsId");

                    b.ToTable("subGroupsTwo");
                });

            modelBuilder.Entity("E_commerce_core.Models.SubGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MainGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainGroupId");

                    b.ToTable("subGroups");
                });

            modelBuilder.Entity("E_commerce_core.Models.Units", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("units");
                });

            modelBuilder.Entity("E_commerce_core.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("GovernmentsId")
                        .HasColumnType("int");

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

                    b.Property<int>("ZonesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("GovernmentsId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ZonesId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("E_commerce_core.Models.Zones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityetId")
                        .HasColumnType("int");

                    b.Property<int>("GovernmetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityetId");

                    b.HasIndex("GovernmetId");

                    b.ToTable("zones");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("E_commerce_core.Models.Cities", b =>
                {
                    b.HasOne("E_commerce_core.Models.Governments", "Governments")
                        .WithMany("Cities")
                        .HasForeignKey("governmetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Governments");
                });

            modelBuilder.Entity("E_commerce_core.Models.Classifications", b =>
                {
                    b.HasOne("E_commerce_core.Models.Users", "Users")
                        .WithMany("Classifications")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("E_commerce_core.Models.CustomerStores", b =>
                {
                    b.HasOne("E_commerce_core.Models.Users", "Users")
                        .WithMany("CustomerStores")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.Stores", "Stores")
                        .WithMany("CustomerStores")
                        .HasForeignKey("StoresId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Stores");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("E_commerce_core.Models.InvItemStores", b =>
                {
                    b.HasOne("E_commerce_core.Models.Items", "Items")
                        .WithMany("InvItemStores")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.Stores", "Stores")
                        .WithMany("InvItemStores")
                        .HasForeignKey("StoresId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Items");

                    b.Navigation("Stores");
                });

            modelBuilder.Entity("E_commerce_core.Models.Invoice", b =>
                {
                    b.HasOne("E_commerce_core.Models.Users", "Users")
                        .WithMany("Invoice")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("E_commerce_core.Models.InvoiceDetails", b =>
                {
                    b.HasOne("E_commerce_core.Models.Invoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.Items", "Items")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("E_commerce_core.Models.Items", b =>
                {
                    b.HasOne("E_commerce_core.Models.MainGroup", "MainGroup")
                        .WithMany("Items")
                        .HasForeignKey("MainGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.SubGroupTwo", "SubGroupTwo")
                        .WithMany("Items")
                        .HasForeignKey("SubGroupTwoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.SubGroups", "SubGroups")
                        .WithMany("Items")
                        .HasForeignKey("SubGroupsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MainGroup");

                    b.Navigation("SubGroupTwo");

                    b.Navigation("SubGroups");
                });

            modelBuilder.Entity("E_commerce_core.Models.ItemsUnits", b =>
                {
                    b.HasOne("E_commerce_core.Models.Items", "Items")
                        .WithMany("ItemsUnits")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.Units", "Units")
                        .WithMany("ItemsUnits")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Items");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("E_commerce_core.Models.ShoppingCartItems", b =>
                {
                    b.HasOne("E_commerce_core.Models.Users", "Users")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.Items", "Items")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.Stores", "Stores")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("SoresId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Items");

                    b.Navigation("Stores");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("E_commerce_core.Models.Stores", b =>
                {
                    b.HasOne("E_commerce_core.Models.Cities", "Cities")
                        .WithMany("Stores")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.Governments", "Governments")
                        .WithMany("Stores")
                        .HasForeignKey("GovernmentsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.Zones", "Zones")
                        .WithMany("Stores")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cities");

                    b.Navigation("Governments");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("E_commerce_core.Models.SubGroupTwo", b =>
                {
                    b.HasOne("E_commerce_core.Models.MainGroup", "MainGroup")
                        .WithMany("SubGroupTwo")
                        .HasForeignKey("MainGroupsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.SubGroups", "SubGroups")
                        .WithMany("SubGroupTwo")
                        .HasForeignKey("SubGroupsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MainGroup");

                    b.Navigation("SubGroups");
                });

            modelBuilder.Entity("E_commerce_core.Models.SubGroups", b =>
                {
                    b.HasOne("E_commerce_core.Models.MainGroup", "MainGroup")
                        .WithMany("SubGroups")
                        .HasForeignKey("MainGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MainGroup");
                });

            modelBuilder.Entity("E_commerce_core.Models.Users", b =>
                {
                    b.HasOne("E_commerce_core.Models.Cities", "Cities")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.Governments", "Governments")
                        .WithMany("Users")
                        .HasForeignKey("GovernmentsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.Zones", "Zones")
                        .WithMany("Users")
                        .HasForeignKey("ZonesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cities");

                    b.Navigation("Governments");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("E_commerce_core.Models.Zones", b =>
                {
                    b.HasOne("E_commerce_core.Models.Cities", "Cities")
                        .WithMany("Zones")
                        .HasForeignKey("CityetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.Governments", "Governments")
                        .WithMany("Zones")
                        .HasForeignKey("GovernmetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cities");

                    b.Navigation("Governments");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("E_commerce_core.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("E_commerce_core.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_commerce_core.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("E_commerce_core.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_commerce_core.Models.Cities", b =>
                {
                    b.Navigation("Stores");

                    b.Navigation("Users");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("E_commerce_core.Models.Governments", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Stores");

                    b.Navigation("Users");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("E_commerce_core.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("E_commerce_core.Models.Items", b =>
                {
                    b.Navigation("InvItemStores");

                    b.Navigation("InvoiceDetails");

                    b.Navigation("ItemsUnits");

                    b.Navigation("ShoppingCartItems");
                });

            modelBuilder.Entity("E_commerce_core.Models.MainGroup", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("SubGroupTwo");

                    b.Navigation("SubGroups");
                });

            modelBuilder.Entity("E_commerce_core.Models.Stores", b =>
                {
                    b.Navigation("CustomerStores");

                    b.Navigation("InvItemStores");

                    b.Navigation("ShoppingCartItems");
                });

            modelBuilder.Entity("E_commerce_core.Models.SubGroupTwo", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("E_commerce_core.Models.SubGroups", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("SubGroupTwo");
                });

            modelBuilder.Entity("E_commerce_core.Models.Units", b =>
                {
                    b.Navigation("ItemsUnits");
                });

            modelBuilder.Entity("E_commerce_core.Models.Users", b =>
                {
                    b.Navigation("Classifications");

                    b.Navigation("CustomerStores");

                    b.Navigation("Invoice");

                    b.Navigation("ShoppingCartItems");
                });

            modelBuilder.Entity("E_commerce_core.Models.Zones", b =>
                {
                    b.Navigation("Stores");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
