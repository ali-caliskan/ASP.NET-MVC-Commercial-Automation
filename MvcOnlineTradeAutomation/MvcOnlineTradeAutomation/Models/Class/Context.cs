using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineTradeAutomation.Models.Class
{
    // : DbContext sınıfından miras almış olduk.
    public class Context: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<InvoicePen> InvoicePens { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<SalesMovement> SalesMovements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<todo> todos { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoFollow> CargoFollows { get; set; }
        public DbSet<message> messages { get; set; }

    }
}