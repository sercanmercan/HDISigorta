﻿// <auto-generated />
using System;
using HDISigorta.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HDISigorta.Persistence.Migrations
{
    [DbContext(typeof(HDISigortaDbContext))]
    partial class HDISigortaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HDISigorta.Domain.Entities.Agreements.Agreement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ValidityPeriod")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Agreements");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DealerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DealerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Dealers.Dealer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppUsersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppUsersId");

                    b.ToTable("Dealers");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Identities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("MyTenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Maintenance.Maintenance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("MaintenanceCenterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MaintenanceCenterId");

                    b.HasIndex("ProductId");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.MaintenanceCenters.MaintenanceCenter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppUsersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppUsersId");

                    b.ToTable("MaintenanceCenters");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Personnels.Personnel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppUsersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DepartmentType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppUsersId");

                    b.ToTable("Personnels");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgreementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BuyingPrice")
                        .HasColumnType("float");

                    b.Property<DateTime?>("BuyingTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsChangedPart")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRepairedPart")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductStatus")
                        .HasColumnType("int");

                    b.Property<double>("ProfitMargin")
                        .HasColumnType("float");

                    b.Property<double>("RiskCost")
                        .HasColumnType("float");

                    b.Property<double>("SellingPrice")
                        .HasColumnType("float");

                    b.Property<DateTime?>("SellingTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Products.ProductHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProductStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductHistories");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Customers.Customer", b =>
                {
                    b.HasOne("HDISigorta.Domain.Entities.Dealers.Dealer", "Dealer")
                        .WithMany()
                        .HasForeignKey("DealerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Dealers.Dealer", b =>
                {
                    b.HasOne("HDISigorta.Domain.Entities.Identities.AppUser", "AppUsers")
                        .WithMany()
                        .HasForeignKey("AppUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Maintenance.Maintenance", b =>
                {
                    b.HasOne("HDISigorta.Domain.Entities.MaintenanceCenters.MaintenanceCenter", "MaintenanceCenter")
                        .WithMany()
                        .HasForeignKey("MaintenanceCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HDISigorta.Domain.Entities.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaintenanceCenter");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.MaintenanceCenters.MaintenanceCenter", b =>
                {
                    b.HasOne("HDISigorta.Domain.Entities.Identities.AppUser", "AppUsers")
                        .WithMany()
                        .HasForeignKey("AppUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Personnels.Personnel", b =>
                {
                    b.HasOne("HDISigorta.Domain.Entities.Identities.AppUser", "AppUsers")
                        .WithMany()
                        .HasForeignKey("AppUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Products.Product", b =>
                {
                    b.HasOne("HDISigorta.Domain.Entities.Agreements.Agreement", "Agreement")
                        .WithMany("Products")
                        .HasForeignKey("AgreementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agreement");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Products.ProductHistory", b =>
                {
                    b.HasOne("HDISigorta.Domain.Entities.Products.Product", "Product")
                        .WithMany("ProductHistories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Agreements.Agreement", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("HDISigorta.Domain.Entities.Products.Product", b =>
                {
                    b.Navigation("ProductHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
