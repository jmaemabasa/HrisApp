
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HrisApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }



        public DbSet<UserMasterT> UserMasterT { get; set; }
        public DbSet<DivisionT> DivisionT { get; set; }
        public DbSet<DepartmentT> DepartmentT { get; set; }
        public DbSet<SectionT> SectionT { get; set; }
    }
}
