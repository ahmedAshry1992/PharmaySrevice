using Microsoft.EntityFrameworkCore;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace PharmacyDataAccess.DomainRepository
{
    public class MiddlewareDbContext : DbContext
    {
        public MiddlewareDbContext(DbContextOptions<MiddlewareDbContext> options):base(options)
        { }
        public DbSet<Classifiction> Classifictions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DosageForm> DosageForms { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoicesDetails { get; set; }
        public DbSet<LargeUnitType> LargeUnitTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductToSell> ProductsToSell { get; set; }
        public DbSet<PurchaceInvoice> PurchaceInvoices { get; set; }
        public DbSet<PurchaceInvoiceDetails> PurchaceInvoicesDetails { get; set; }
        public DbSet<ReturnedInvoice> ReturnedInvoices { get; set; }
        public DbSet<ReturnedInvoiceDetails> ReturnedInvoicesDetails { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<SmallUnitType> SmallUnitTypes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }






    }
}
