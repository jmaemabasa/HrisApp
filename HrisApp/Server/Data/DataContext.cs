
using HrisApp.Shared.Models.LiscenseAndTraining;
using System.ComponentModel;

namespace HrisApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //MASTER DATA
            modelBuilder.Entity<DivisionT>().HasData(
                new DivisionT { Id = 1, Name = "Sales Operations Division" },
                new DivisionT { Id = 2, Name = "Finance Accounting Management Service Division" },
                new DivisionT { Id = 3, Name = "Supply Chain Management Service" },
                new DivisionT { Id = 4, Name = "Central Administration Division" },
                new DivisionT { Id = 5, Name = "Agro Industrial Division" }
            );

            modelBuilder.Entity<DepartmentT>().HasData(
                new DepartmentT { Id = 1, Name = "Sonic 1", DivisionId = 1 },
                new DepartmentT { Id = 2, Name = "Sonic 2", DivisionId = 1 },
                new DepartmentT { Id = 3, Name = "Sonic 3 Digos", DivisionId = 1 },
                new DepartmentT { Id = 4, Name = "Sonic 3 Kidapawan", DivisionId = 1 },
                new DepartmentT { Id = 5, Name = "Sonic 3 Cotabato", DivisionId = 1 },
                new DepartmentT { Id = 6, Name = "URIC", DivisionId = 1 },
                new DepartmentT { Id = 7, Name = "UFS", DivisionId = 1 },
                new DepartmentT { Id = 8, Name = "GCash", DivisionId = 1 },
                new DepartmentT { Id = 9, Name = "Sales Accounting", DivisionId = 2 },
                new DepartmentT { Id = 10, Name = "Credit and Collection", DivisionId = 2 },
                new DepartmentT { Id = 11, Name = "Accounts Receivable", DivisionId = 2 },
                new DepartmentT { Id = 12, Name = "General Accounting", DivisionId = 2 },
                new DepartmentT { Id = 13, Name = "Accounts Payable", DivisionId = 2 },
                new DepartmentT { Id = 14, Name = "General Accounting", DivisionId = 2 },
                new DepartmentT { Id = 15, Name = "Tax Compliance", DivisionId = 2 },
                new DepartmentT { Id = 16, Name = "Information Technology", DivisionId = 2 },
                new DepartmentT { Id = 17, Name = "Cash Operations", DivisionId = 2 },
                new DepartmentT { Id = 18, Name = "Warehouse", DivisionId = 3 },
                new DepartmentT { Id = 19, Name = "Transport", DivisionId = 3 },
                new DepartmentT { Id = 20, Name = "Inventory Planning and Principal Relations", DivisionId = 3 },
                new DepartmentT { Id = 21, Name = "Order Processing", DivisionId = 3 },
                new DepartmentT { Id = 22, Name = "Logistics", DivisionId = 3 },
                new DepartmentT { Id = 23, Name = "Human Resource", DivisionId = 4 },
                new DepartmentT { Id = 24, Name = "General Services", DivisionId = 4 },
                new DepartmentT { Id = 25, Name = "Canaan", DivisionId = 5 },
                new DepartmentT { Id = 26, Name = "RTL", DivisionId = 5 },
                new DepartmentT { Id = 27, Name = "Pullet", DivisionId = 5 }
            );

            modelBuilder.Entity<AreaT>().HasData(
                new AreaT { Id = 1, Name = "Davao" },
                new AreaT { Id = 2, Name = "Digos" },
                new AreaT { Id = 3, Name = "Kidapawan" },
                new AreaT { Id = 4, Name = "Cotabato" },
                new AreaT { Id = 5, Name = "Calinan" },
                new AreaT { Id = 6, Name = "Gumalang" }
            );

            //EMPLOYEE DETAILS
            modelBuilder.Entity<EmploymentStatusT>().HasData(
                new EmploymentStatusT { Id = 1, Name = "Regular" },
                new EmploymentStatusT { Id = 2, Name = "Probationary" },
                new EmploymentStatusT { Id = 3, Name = "Casual" },
                new EmploymentStatusT { Id = 4, Name = "Fixed Term" },
                new EmploymentStatusT { Id = 5, Name = "Project Based" }
            );

            modelBuilder.Entity<InactiveStatusT>().HasData(
                new InactiveStatusT { Id = 1, Name = "Active" },
                new InactiveStatusT { Id = 2, Name = "Resigned" },
                new InactiveStatusT { Id = 3, Name = "Terminated" },
                new InactiveStatusT { Id = 4, Name = "Awol" },
                new InactiveStatusT { Id = 5, Name = "Retired" }
            );

            modelBuilder.Entity<StatusT>().HasData(
                new StatusT { Id = 1, Name = "Active" },
                new StatusT { Id = 2, Name = "Inactive" }
            );

            modelBuilder.Entity<CivilStatusT>().HasData(
                new CivilStatusT { Id = 1, Name = "Single" },
                new CivilStatusT { Id = 2, Name = "Married" },
                new CivilStatusT { Id = 3, Name = "Widowed" }
            );

            modelBuilder.Entity<ReligionT>().HasData(
                new ReligionT { Id = 1, Name = "Roman Catholic" },
                new ReligionT { Id = 2, Name = "Iglesia ni Cristo" },
                new ReligionT { Id = 3, Name = "Evangelicals (PCEC)" },
                new ReligionT { Id = 4, Name = "Non-Roman Catholic" },
                new ReligionT { Id = 5, Name = "Protestant (NCCP)" },
                new ReligionT { Id = 6, Name = "Aglipayan" },
                new ReligionT { Id = 7, Name = "Seventh-day Adventist" },
                new ReligionT { Id = 8, Name = "Bible Baptist Church" },
                new ReligionT { Id = 9, Name = "United Church of Christ in the Philippines" },
                new ReligionT { Id = 10, Name = "Jehovah's Witnesses" },
                new ReligionT { Id = 11, Name = "None" },
                new ReligionT { Id = 12, Name = "Others" }
            );

            modelBuilder.Entity<GenderT>().HasData(
                 new GenderT { Id = 1, Name = "Male" },
                 new GenderT { Id = 2, Name = "Female" }
            );

            modelBuilder.Entity<EmerRelationshipT>().HasData(
             new EmerRelationshipT { Id = 1, Name = "Mother" },
             new EmerRelationshipT { Id = 2, Name = "Father" },
             new EmerRelationshipT { Id = 3, Name = "Spouse" },
             new EmerRelationshipT { Id = 4, Name = "Sibling" }
            );
        }

        public DbSet<UserMasterT> UserMasterT { get; set; }

        //Master Data
        public DbSet<DivisionT> DivisionT { get; set; }
        public DbSet<DepartmentT> DepartmentT { get; set; }
        public DbSet<SectionT> SectionT { get; set; }
        public DbSet<PositionT> PositionT { get; set; }
        public DbSet<AreaT> AreaT { get; set; }


        //Employee Data
        public DbSet<EmployeeT> EmployeeT { get; set; }
        public DbSet<EmploymentStatusT> EmploymentStatusT { get; set; }
        public DbSet<InactiveStatusT> InactiveStatusT { get; set; }
        public DbSet<StatusT> StatusT { get; set; }
        public DbSet<CivilStatusT> CivilStatusT { get; set; }
        public DbSet<ReligionT> ReligionT { get; set; }
        public DbSet<GenderT> GenderT { get; set; }
        public DbSet<EmerRelationshipT> EmerRelationshipT { get; set; }

        //EDUCATIONS
        public DbSet<CollegeT> CollegeT { get; set; }
        public DbSet<DoctorateT> DoctorateT { get; set; }
        public DbSet<MasteralT> MasteralT { get; set; }
        public DbSet<OtherEducT> OtherEducT { get; set; }
        public DbSet<PrimaryT> PrimaryT { get; set; }
        public DbSet<SecondaryT> SecondaryT { get; set; }
        public DbSet<SeniorHST> SeniorHST { get; set; }

        //LICENSE AND TRAINING
        public DbSet<LicenseT> LicenseT { get; set; }
        public DbSet<TrainingT> TrainingT { get; set; }


        //Address
        public DbSet<AddressT> AddressT { get; set; }

        //IMAGES AND FILES
        public DbSet<DocumentT> DocumentT { get; set; }
        public DbSet<EmpPictureT> EmpPictureT { get; set; }
    }
}
