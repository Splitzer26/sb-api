using Microsoft.EntityFrameworkCore;
using SBAPI.Domain.Entities.AccountType;
using SBAPI.Domain.Entities.Banks;
using SBAPI.Domain.Entities.BranchOffices;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.CashRegisters;
using SBAPI.Domain.Entities.Cities;
using SBAPI.Domain.Entities.Clients;
using SBAPI.Domain.Entities.ClientTypes;
using SBAPI.Domain.Entities.Company;
using SBAPI.Domain.Entities.Departments;
using SBAPI.Domain.Entities.DistributionProducts;
using SBAPI.Domain.Entities.FamilyProducts;
using SBAPI.Domain.Entities.Invoices;
using SBAPI.Domain.Entities.ListedProducts;
using SBAPI.Domain.Entities.ListSuppliers;
using SBAPI.Domain.Entities.Origins;
using SBAPI.Domain.Entities.ProductPrices;
using SBAPI.Domain.Entities.Products;
using SBAPI.Domain.Entities.ProductsInputs;
using SBAPI.Domain.Entities.ProductsOutputs;
using SBAPI.Domain.Entities.ProductStatuses;
using SBAPI.Domain.Entities.ProductsToBuy;
using SBAPI.Domain.Entities.ProductsToSale;
using SBAPI.Domain.Entities.ProductsTransfer;
using SBAPI.Domain.Entities.PurchaseOrders;
using SBAPI.Domain.Entities.Quotations;
using SBAPI.Domain.Entities.Roles;
using SBAPI.Domain.Entities.SalesOrders;
using SBAPI.Domain.Entities.SectionsProduct;
using SBAPI.Domain.Entities.SoldProducts;
using SBAPI.Domain.Entities.Statuses;
using SBAPI.Domain.Entities.SupplierBankAccounts;
using SBAPI.Domain.Entities.TypeStatuses;
using SBAPI.Domain.Entities.TypesUnitOfMeasurements;
using SBAPI.Domain.Entities.UnitOfMeasurements;
using SBAPI.Domain.Entities.Users;
using SBAPI.Domain.Entities.Warehouses;

namespace SBAPI.Domain
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           //BranchOffices
            builder.Entity<BranchOffice>()
                .HasOne(u => u.Company)
                .WithMany()
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
            //CashRegistrer
            builder.Entity<CashRegister>()
                .HasOne(u => u.BranchOffice)
                .WithMany()
                .HasForeignKey(u => u.BranchOfficeId)
                .OnDelete(DeleteBehavior.Restrict);
            //Cities
            builder.Entity<City>()
                .HasOne(u => u.Department)
                .WithMany()
                .HasForeignKey(u => u.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            //Client
            builder.Entity<Client>()
                .HasOne(u => u.ClientType)
                .WithMany()
                .HasForeignKey(u => u.ClientTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Client>()
                .HasOne(u => u.City)
                .WithMany()
                .HasForeignKey(u => u.CityId)
                .OnDelete(DeleteBehavior.Restrict);
            //Distribution Products
            builder.Entity<DistributionProducts>()
                .HasOne(u => u.Product)
                .WithMany()
                .HasForeignKey(u => u.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<DistributionProducts>()
                .HasOne(u => u.Warehouse)
                .WithMany()
                .HasForeignKey(u => u.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);
            //Family Product
            builder.Entity<FamilyProduct>()
                .HasOne(u => u.SectionProduct)
                .WithMany()
                .HasForeignKey(u => u.SectionProductId)
                .OnDelete(DeleteBehavior.Restrict);
            //Invoice
            builder.Entity<Invoice>()
                .HasOne(u => u.CashRegister)
                .WithMany()
                .HasForeignKey(u => u.CashRegistrerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Invoice>()
                .HasOne(u => u.Client)
                .WithMany()
                .HasForeignKey(u => u.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Invoice>()
               .HasOne(u => u.CreatedBy)
               .WithMany()
               .HasForeignKey(u => u.CreatedById)
               .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Invoice>()
               .HasOne(u => u.ModifiedBy)
               .WithMany()
               .HasForeignKey(u => u.ModifiedById)
               .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Invoice>()
                .HasOne(u => u.Status)
                .WithMany()
                .HasForeignKey(u => u.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            //Listed Products
            builder.Entity<ListedProduct>()
               .HasOne(u => u.Quotation)
               .WithMany()
               .HasForeignKey(u => u.QuotationId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ListedProduct>()
              .HasOne(u => u.Product)
              .WithMany()
              .HasForeignKey(u => u.ProductId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ListedProduct>()
              .HasOne(u => u.Tax)
              .WithMany()
              .HasForeignKey(u => u.TaxId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ListedProduct>()
              .HasOne(u => u.CreatedBy)
              .WithMany()
              .HasForeignKey(u => u.CreatedById)
              .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ListedProduct>()
              .HasOne(u => u.ModifiedBy)
              .WithMany()
              .HasForeignKey(u => u.ModifiedById)
              .OnDelete(DeleteBehavior.Restrict);
            //List Suppliers
            builder.Entity<ListSuppliers>()
              .HasOne(u => u.Supplier)
              .WithMany()
              .HasForeignKey(u => u.SupplierId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ListSuppliers>()
             .HasOne(u => u.Product)
             .WithMany()
             .HasForeignKey(u => u.ProductId)
             .OnDelete(DeleteBehavior.Restrict);
            //Product Prices
            builder.Entity<ProductPrices>()
              .HasOne(u => u.Product)
              .WithMany()
              .HasForeignKey(u => u.ProductId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductPrices>()
             .HasOne(u => u.ClientType)
             .WithMany()
             .HasForeignKey(u => u.TypeClientId)
             .OnDelete(DeleteBehavior.Restrict);
            //Product
            builder.Entity<Product>()
              .HasOne(u => u.FamilyProduct)
              .WithMany()
              .HasForeignKey(u => u.FamilyProductId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Product>()
             .HasOne(u => u.RegularSupplier)
             .WithMany()
             .HasForeignKey(u => u.RegularSupplierId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Product>()
              .HasOne(u => u.ProductStatus)
              .WithMany()
              .HasForeignKey(u => u.ProductStatusId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Product>()
             .HasOne(u => u.Tax)
             .WithMany()
             .HasForeignKey(u => u.TaxId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Product>()
             .HasOne(u => u.UnitOfMeasurement)
             .WithMany()
             .HasForeignKey(u => u.UnitOfMeasurementId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Product>()
             .HasOne(u => u.CreatedBy)
             .WithMany()
             .HasForeignKey(u => u.CreatedById)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Product>()
             .HasOne(u => u.ModifiedBy)
             .WithMany()
             .HasForeignKey(u => u.ModifiedById)
             .OnDelete(DeleteBehavior.Restrict);
            //Product Inputs
            builder.Entity<ProductInput>()
             .HasOne(u => u.Product)
             .WithMany()
             .HasForeignKey(u => u.ProductId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductInput>()
             .HasOne(u => u.Origin)
             .WithMany()
             .HasForeignKey(u => u.OriginId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductInput>()
            .HasOne(u => u.Transfer)
            .WithMany()
            .HasForeignKey(u => u.TransferId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductInput>()
            .HasOne(u => u.PurchaseOrder)
            .WithMany()
            .HasForeignKey(u => u.PurchaseOrderId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductInput>()
            .HasOne(u => u.WarehouseDestiny)
            .WithMany()
            .HasForeignKey(u => u.WarehouseDestinyId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductInput>()
            .HasOne(u => u.CreatedBy)
            .WithMany()
            .HasForeignKey(u => u.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductInput>()
            .HasOne(u => u.ModifiedBy)
            .WithMany()
            .HasForeignKey(u => u.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);
            //Product Output
            builder.Entity<ProductOutput>()
             .HasOne(u => u.Product)
             .WithMany()
             .HasForeignKey(u => u.ProductId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductOutput>()
             .HasOne(u => u.Origin)
             .WithMany()
             .HasForeignKey(u => u.OriginId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductOutput>()
            .HasOne(u => u.Transfer)
            .WithMany()
            .HasForeignKey(u => u.TransferId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductOutput>()
            .HasOne(u => u.Invoice)
            .WithMany()
            .HasForeignKey(u => u.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductOutput>()
            .HasOne(u => u.WarehouseFrom)
            .WithMany()
            .HasForeignKey(u => u.WarehouseFromId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductOutput>()
            .HasOne(u => u.CreatedBy)
            .WithMany()
            .HasForeignKey(u => u.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductOutput>()
            .HasOne(u => u.ModifiedBy)
            .WithMany()
            .HasForeignKey(u => u.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);
            //Product To Buy
            builder.Entity<ProductToBuy>()
             .HasOne(u => u.PurchaseOrder)
             .WithMany()
             .HasForeignKey(u => u.PurchaseOrderId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductToBuy>()
             .HasOne(u => u.Product)
             .WithMany()
             .HasForeignKey(u => u.ProductId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductToBuy>()
            .HasOne(u => u.Tax)
            .WithMany()
            .HasForeignKey(u => u.TaxId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductToBuy>()
            .HasOne(u => u.CreatedBy)
            .WithMany()
            .HasForeignKey(u => u.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductToBuy>()
            .HasOne(u => u.ModifiedBy)
            .WithMany()
            .HasForeignKey(u => u.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);
            //Product To Sell
            builder.Entity<ProductToSell>()
            .HasOne(u => u.SaleOrder)
            .WithMany()
            .HasForeignKey(u => u.SaleOrderId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductToSell>()
             .HasOne(u => u.Product)
             .WithMany()
             .HasForeignKey(u => u.ProductId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductToSell>()
            .HasOne(u => u.Tax)
            .WithMany()
            .HasForeignKey(u => u.TaxId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductToSell>()
            .HasOne(u => u.CreatedBy)
            .WithMany()
            .HasForeignKey(u => u.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductToSell>()
            .HasOne(u => u.ModifiedBy)
            .WithMany()
            .HasForeignKey(u => u.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);
            //Product Transfer
            builder.Entity<ProductTransfer>()
            .HasOne(u => u.WarehouseFrom)
            .WithMany()
            .HasForeignKey(u => u.WarehouseFromId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductTransfer>()
             .HasOne(u => u.Product)
             .WithMany()
             .HasForeignKey(u => u.ProductId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductTransfer>()
            .HasOne(u => u.WarehouseTo)
            .WithMany()
            .HasForeignKey(u => u.WarehouseToId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductTransfer>()
            .HasOne(u => u.CreatedBy)
            .WithMany()
            .HasForeignKey(u => u.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductTransfer>()
            .HasOne(u => u.ModifiedBy)
            .WithMany()
            .HasForeignKey(u => u.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductTransfer>()
                .HasOne(u => u.Status)
                .WithMany()
                .HasForeignKey(u => u.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            //Purchase Order
            builder.Entity<PurchaseOrder>()
            .HasOne(u => u.Supplier)
            .WithMany()
            .HasForeignKey(u => u.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<PurchaseOrder>()
            .HasOne(u => u.CreatedBy)
            .WithMany()
            .HasForeignKey(u => u.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<PurchaseOrder>()
            .HasOne(u => u.ModifiedBy)
            .WithMany()
            .HasForeignKey(u => u.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<PurchaseOrder>()
                .HasOne(u => u.Status)
                .WithMany()
                .HasForeignKey(u => u.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            //Quotations
            builder.Entity<Quotation>()
            .HasOne(u => u.Client)
            .WithMany()
            .HasForeignKey(u => u.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Quotation>()
            .HasOne(u => u.CreatedBy)
            .WithMany()
            .HasForeignKey(u => u.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Quotation>()
            .HasOne(u => u.ModifiedBy)
            .WithMany()
            .HasForeignKey(u => u.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Quotation>()
                .HasOne(u => u.Status)
                .WithMany()
                .HasForeignKey(u => u.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            //Sale Order
            builder.Entity<SaleOrder>()
            .HasOne(u => u.Client)
            .WithMany()
            .HasForeignKey(u => u.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SaleOrder>()
            .HasOne(u => u.CreatedBy)
            .WithMany()
            .HasForeignKey(u => u.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SaleOrder>()
            .HasOne(u => u.ModifiedBy)
            .WithMany()
            .HasForeignKey(u => u.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SaleOrder>()
                .HasOne(u => u.Status)
                .WithMany()
                .HasForeignKey(u => u.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            //Sold Product
            builder.Entity<SoldProduct>()
           .HasOne(u => u.Invoice)
           .WithMany()
           .HasForeignKey(u => u.InvoiceId)
           .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SoldProduct>()
             .HasOne(u => u.Product)
             .WithMany()
             .HasForeignKey(u => u.ProductId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SoldProduct>()
            .HasOne(u => u.Tax)
            .WithMany()
            .HasForeignKey(u => u.TaxId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SoldProduct>()
            .HasOne(u => u.CreatedBy)
            .WithMany()
            .HasForeignKey(u => u.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SoldProduct>()
            .HasOne(u => u.ModifiedBy)
            .WithMany()
            .HasForeignKey(u => u.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);
            //Statuses
            builder.Entity<Status>()
            .HasOne(u => u.TypeStatus)
            .WithMany()
            .HasForeignKey(u => u.TypeStatusId)
            .OnDelete(DeleteBehavior.Restrict);
            //Supplier Bank Account
            builder.Entity<SupplierBankAccount>()
            .HasOne(u => u.Bank)
            .WithMany()
            .HasForeignKey(u => u.BankId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SupplierBankAccount>()
            .HasOne(u => u.AccountType)
            .WithMany()
            .HasForeignKey(u => u.AccountTypeId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SupplierBankAccount>()
           .HasOne(u => u.Supplier)
           .WithMany()
           .HasForeignKey(u => u.SupplierId)
           .OnDelete(DeleteBehavior.Restrict);
            //Unit of Measurement
            builder.Entity<UnitOfMeasurement>()
           .HasOne(u => u.TypeUnitOfMeasurement)
           .WithMany()
           .HasForeignKey(u => u.TypeUnitOfMeasurementId)
           .OnDelete(DeleteBehavior.Restrict);
            //User
            builder.Entity<User>()
           .HasOne(u => u.Rol)
           .WithMany()
           .HasForeignKey(u => u.RolId)
           .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<User>()
                .HasOne(u => u.Status)
                .WithMany()
                .HasForeignKey(u => u.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            //Warehouse
            builder.Entity<Warehouse>()
           .HasOne(u => u.BranchOffice)
           .WithMany()
           .HasForeignKey(u => u.BranchOfficeId)
           .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Warehouse>()
                .HasOne(u => u.Status)
                .WithMany()
                .HasForeignKey(u=>u.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

        }
        public DbSet<Bank> Branks { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Business> Company { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DistributionProducts> DistributionProducts { get; set; }
        public DbSet<FamilyProduct> FamilyProducts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ListedProduct> ListedProducts { get; set; }
        public DbSet<ListSuppliers> ListSuppliers { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<ProductPrices> ProductPrices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInput> ProductInputs { get; set; }
        public DbSet<ProductOutput> ProductOutputs { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<ProductToBuy> ProductsToBuy { get; set; }
        public DbSet<ProductToSell> ProductsToSell { get; set; }
        public DbSet<ProductTransfer> ProductTransfers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<SaleOrder> SalesOrder { get; set; }
        public DbSet<SectionProduct> SectionsProducts { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<SupplierBankAccount> SupplierBankAccounts { get; set; }
        public DbSet<TypeBankAccount> TypeBankAccount { get; set; }
        public DbSet<TypeStatus> TypeStatuses { get; set; }
        public DbSet<TypeUnitOfMeasurement> TypeUnitOfMeasurements { get; set; }
        public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
