﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PharmacyService.DataAccess.DomainRepository;

namespace PharmacyService.DataAccess.Migrations
{
    [DbContext(typeof(MiddlewareDbContext))]
    partial class MiddlewareDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PharmacyService.Models.Domain.Classification", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("classification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Classifictions");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.Company", b =>
                {
                    b.Property<int>("companyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ownerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("companyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("points")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.DosageForm", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<string>("form")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("DosageForms");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.Invoice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<int?>("customerId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("statusId")
                        .HasColumnType("int");

                    b.Property<int>("typeId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.InvoiceDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<float>("discount")
                        .HasColumnType("real");

                    b.Property<int>("invoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("items")
                        .HasColumnType("int");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("productToSellId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("invoiceId");

                    b.ToTable("InvoicesDetails");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.InvoiceStatus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("invoiceStatuses");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.InvoiceType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("invoiceTypes");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.LargeUnitType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("LargeUnitTypes");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.Pranche", b =>
                {
                    b.Property<int>("pranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.HasKey("pranchId");

                    b.HasIndex("companyId");

                    b.ToTable("Pranches");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("alive")
                        .HasColumnType("bit");

                    b.Property<string>("arabicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("classificationId")
                        .HasColumnType("int");

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<int>("dosageFormsID")
                        .HasColumnType("int");

                    b.Property<string>("englishName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("internationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("largeUnitTypeID")
                        .HasColumnType("int");

                    b.Property<byte>("largeUnits")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<bool>("regitered")
                        .HasColumnType("bit");

                    b.Property<string>("regitrationNumberInMinistryOfHealth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("smallUnitTypeID")
                        .HasColumnType("int");

                    b.Property<byte>("smallUnits")
                        .HasColumnType("tinyint");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.ProductToSell", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("exist")
                        .HasColumnType("bit");

                    b.Property<bool>("isBonus")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("items")
                        .HasColumnType("int");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("purchaceInvoiceDetailsId")
                        .HasColumnType("int");

                    b.Property<bool>("returned")
                        .HasColumnType("bit");

                    b.Property<int>("returnedItems")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("productId");

                    b.HasIndex("purchaceInvoiceDetailsId");

                    b.ToTable("ProductsToSell");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.ProductsCompany", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("about")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ProductsCompanies");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.PurchaceInvoice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("supplierId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("PurchaceInvoices");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.PurchaceInvoiceDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("bonus")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<float>("discountPercentage")
                        .HasColumnType("real");

                    b.Property<DateTime>("expireDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("purchaceInvoiceId")
                        .HasColumnType("int");

                    b.Property<decimal>("purchacePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("purchaceInvoiceId");

                    b.ToTable("PurchaceInvoicesDetails");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.ReturnedInvoice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<int>("invoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ReturnedInvoices");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.ReturnedInvoiceDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<int>("invoiceDetailsId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("numOfReturnedItems")
                        .HasColumnType("int");

                    b.Property<int>("returnedInvoiceId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("returnedInvoiceId");

                    b.ToTable("ReturnedInvoicesDetails");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.Shift", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("end")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("extraditedMomey")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<decimal>("receivedMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("start")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<decimal>("value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.SmallUnitType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("SmallUnitTypes");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.Supplier", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("hireDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.InvoiceDetails", b =>
                {
                    b.HasOne("PharmacyService.Models.Domain.Invoice", "MyProperty")
                        .WithMany("MyProperty")
                        .HasForeignKey("invoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyProperty");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.Pranche", b =>
                {
                    b.HasOne("PharmacyService.Models.Domain.Company", "company")
                        .WithMany("pranches")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.ProductToSell", b =>
                {
                    b.HasOne("PharmacyService.Models.Domain.Product", "product")
                        .WithMany("productsToSell")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyService.Models.Domain.PurchaceInvoiceDetails", "purchaceInvoiceDetails")
                        .WithMany("MyProperty")
                        .HasForeignKey("purchaceInvoiceDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("purchaceInvoiceDetails");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.PurchaceInvoiceDetails", b =>
                {
                    b.HasOne("PharmacyService.Models.Domain.PurchaceInvoice", "purchaceInvoice")
                        .WithMany("MyProperty")
                        .HasForeignKey("purchaceInvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("purchaceInvoice");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.ReturnedInvoiceDetails", b =>
                {
                    b.HasOne("PharmacyService.Models.Domain.ReturnedInvoice", "returnedInvoice")
                        .WithMany("returnedInvoicesDetails")
                        .HasForeignKey("returnedInvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("returnedInvoice");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.Company", b =>
                {
                    b.Navigation("pranches");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.Invoice", b =>
                {
                    b.Navigation("MyProperty");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.Product", b =>
                {
                    b.Navigation("productsToSell");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.PurchaceInvoice", b =>
                {
                    b.Navigation("MyProperty");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.PurchaceInvoiceDetails", b =>
                {
                    b.Navigation("MyProperty");
                });

            modelBuilder.Entity("PharmacyService.Models.Domain.ReturnedInvoice", b =>
                {
                    b.Navigation("returnedInvoicesDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
