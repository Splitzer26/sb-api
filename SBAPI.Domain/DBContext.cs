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
using SBAPI.Domain.Entities.SupplierBankAccounts;
using SBAPI.Domain.Entities.TypesUnitOfMeasurements;
using SBAPI.Domain.Entities.UnitOfMeasurements;
using SBAPI.Domain.Entities.Users;
using SBAPI.Domain.Entities.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Domain
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options)
        {

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
        public DbSet<SupplierBankAccount> SupplierBankAccounts { get; set; }
        public DbSet<TypeBankAccount> TypeBankAccount { get; set; }
        public DbSet<TypeUnitOfMeasurement> TypeUnitOfMeasurements { get; set; }
        public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
