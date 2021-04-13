using Company.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Camp> Camps { get; set; }
        public DbSet<ViewApplication> ViewApplications { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet <Voucher> Vouchers { get; set; }
        public DbSet<ViewVoucher> ViewVouchers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }       
       
 
    }
}
