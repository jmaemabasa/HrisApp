using HrisApp.Shared.Models.Payroll;

namespace HrisApp.Server.Data
{
#nullable disable
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //MASTER DATA
            modelBuilder.Entity<DivisionT>().HasData(
                new DivisionT { Id = 1, Name = "Sales Operations" }, // new DivisionT { Id = 1, Name = "Sales Operations Division" },
                new DivisionT { Id = 2, Name = "FAMS" }, //new DivisionT { Id = 2, Name = "Finance Accounting Management Service Division" },
                new DivisionT { Id = 3, Name = "Supply Chain Management Service" },
                new DivisionT { Id = 4, Name = "Central Administration" }, // new DivisionT { Id = 4, Name = "Central Administration Division" },
                new DivisionT { Id = 5, Name = "Agro Industrial" } //new DivisionT { Id = 5, Name = "Agro Industrial Division" }
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

                new DepartmentT { Id = 9, Name = "General Accounting", DivisionId = 2 },
                new DepartmentT { Id = 10, Name = "Sales Accounting", DivisionId = 2 },
                new DepartmentT { Id = 11, Name = "Information Technology", DivisionId = 2 },
                new DepartmentT { Id = 12, Name = "Treasury", DivisionId = 2 },

                new DepartmentT { Id = 16, Name = "Warehouse", DivisionId = 3 },
                new DepartmentT { Id = 17, Name = "Transport", DivisionId = 3 },
                new DepartmentT { Id = 18, Name = "Inventory Planning and Principal Relations", DivisionId = 3 },
                new DepartmentT { Id = 19, Name = "Order Processing", DivisionId = 3 },
                new DepartmentT { Id = 20, Name = "Logistics", DivisionId = 3 },

                new DepartmentT { Id = 21, Name = "Human Resource", DivisionId = 4 },
                new DepartmentT { Id = 22, Name = "General Services", DivisionId = 4 },

                new DepartmentT { Id = 23, Name = "Canaan", DivisionId = 5 },
                new DepartmentT { Id = 24, Name = "RTL", DivisionId = 5 },
                new DepartmentT { Id = 25, Name = "Pullet", DivisionId = 5 }
            );

            modelBuilder.Entity<SectionT>().HasData(
                new SectionT { Id = 4, Name = "Hapi Dealer", DivisionId = 1, DepartmentId = 6}, //uric
                new SectionT { Id = 5, Name = "Servicing", DivisionId = 1, DepartmentId = 6},
                new SectionT { Id = 6, Name = "Expansion", DivisionId = 1, DepartmentId = 6},
                new SectionT { Id = 7, Name = "DTEX", DivisionId = 1, DepartmentId = 6},
                new SectionT { Id = 8, Name = "Servicing", DivisionId = 1, DepartmentId = 8 }, //Gcash
                new SectionT { Id = 9, Name = "Expansion", DivisionId = 1, DepartmentId = 8 },
                new SectionT { Id = 10, Name = "Merchandising", DivisionId = 1, DepartmentId = 8 },
                new SectionT { Id = 11, Name = "Scan To Pay", DivisionId = 1, DepartmentId = 8 },
                new SectionT { Id = 12, Name = "Inventory and Accnts. Payable", DivisionId = 1, DepartmentId = 9 }, //FAMS GA
                new SectionT { Id = 13, Name = "General Accounting", DivisionId = 1, DepartmentId = 9 },
                new SectionT { Id = 14, Name = "Tax and Compliance", DivisionId = 1, DepartmentId = 9 },
                new SectionT { Id = 15, Name = "Accounts Receivable", DivisionId = 1, DepartmentId = 10 }, //FAMS SA
                new SectionT { Id = 16, Name = "Credit and Collection", DivisionId = 1, DepartmentId = 10 },
                new SectionT { Id = 17, Name = "Billing to Cash Settlement", DivisionId = 1, DepartmentId = 10 },
                new SectionT { Id = 18, Name = "Cash Operations", DivisionId = 1, DepartmentId = 12 } //FAMS TR
                );

            modelBuilder.Entity<PositionT>().HasData(
                new PositionT { Id = 1, PosCode = "S101", Name = "FSS", DivisionId = 1, DepartmentId = 1, Plantilla = 1 /*, SectionId = 1 */}, //No Section Sonic 1
                new PositionT { Id = 2, PosCode = "S102", Name = "Feeder", DivisionId = 1, DepartmentId = 1, Plantilla = 9 /*, SectionId = 1*/ },
                new PositionT { Id = 3, PosCode = "S103", Name = "FCCR", DivisionId = 1, DepartmentId = 1, Plantilla = 2 /*, SectionId = 1*/ },

                new PositionT { Id = 4, PosCode = "S3K01", Name = "FSS", DivisionId = 1, DepartmentId = 4, Plantilla = 1 /*, SectionId = 1*/ }, //No Section Sonic 3 Kidapawan
                new PositionT { Id = 5, PosCode = "S3K02", Name = "DT Booking/ GT Booking", DivisionId = 1, DepartmentId = 4, Plantilla = 1 },
                new PositionT { Id = 6, PosCode = "S3K03", Name = "DSS", DivisionId = 1, DepartmentId = 4, Plantilla = 1 },
                new PositionT { Id = 7, PosCode = "S3K04", Name = "PM Salesman", DivisionId = 1, DepartmentId = 4, Plantilla = 1 },
                new PositionT { Id = 8, PosCode = "S3K05", Name = "OMNI Feeder", DivisionId = 1, DepartmentId = 4, Plantilla = 3 },
                new PositionT { Id = 9, PosCode = "S3K06", Name = "FCCR", DivisionId = 1, DepartmentId = 4, Plantilla = 1 },

                new PositionT { Id = 10, PosCode = "S3C01", Name = "FSS", DivisionId = 1, DepartmentId = 5, Plantilla = 1  /*, SectionId = 1*/ }, //No Section Sonic 3 Cotabato
                new PositionT { Id = 11, PosCode = "S3C02", Name = "DT Booking/ GT Booking", DivisionId = 1, DepartmentId = 5, Plantilla = 2 },
                new PositionT { Id = 12, PosCode = "S3C03", Name = "DSS", DivisionId = 1, DepartmentId = 5 , Plantilla = 1 },
                new PositionT { Id = 13, PosCode = "S3C04", Name = "OMNI Feeder", DivisionId = 1, DepartmentId = 5 , Plantilla = 3 },
                new PositionT { Id = 14, PosCode = "S3C05", Name = "FCCR", DivisionId = 1, DepartmentId = 5 , Plantilla = 1 },

                new PositionT { Id = 15, PosCode = "URIC01", Name = "Operations Manager", DivisionId = 1, DepartmentId = 6 , Plantilla = 1 }, //URIC
                new PositionT { Id = 16, PosCode = "URICHAP01", Name = "HAPI Supervisor", DivisionId = 1, DepartmentId = 6, SectionId = 4, Plantilla = 1 }, //URIC HAPI DEALER
                new PositionT { Id = 17, PosCode = "URICHAP02", Name = "HAPI Dealer Coor", DivisionId = 1, DepartmentId = 6, SectionId = 4, Plantilla = 4 },
                new PositionT { Id = 18, PosCode = "URICSER01", Name = "Field Sales Supervisor", DivisionId = 1, DepartmentId = 6, SectionId = 5, Plantilla = 1 }, //URIC SERVICING
                new PositionT { Id = 19, PosCode = "URICSER02", Name = "MAG Supervisor", DivisionId = 1, DepartmentId = 6, SectionId = 5, Plantilla = 1 },
                new PositionT { Id = 20, PosCode = "URICSER03", Name = "GTAS", DivisionId = 1, DepartmentId = 6, SectionId = 5, Plantilla = 5 },
                new PositionT { Id = 21, PosCode = "URICSER04", Name = "SMS", DivisionId = 1, DepartmentId = 6, SectionId = 5, Plantilla = 11 },
                new PositionT { Id = 22, PosCode = "URICEXP01", Name = "NAO Supervisor", DivisionId = 1, DepartmentId = 6, SectionId = 6, Plantilla = 1 }, //URIC EXPANSION
                new PositionT { Id = 23, PosCode = "URICEXP02", Name = "NAO", DivisionId = 1, DepartmentId = 6, SectionId = 6, Plantilla = 2 },
                new PositionT { Id = 24, PosCode = "URICEXP02", Name = "HAPI NAO", DivisionId = 1, DepartmentId = 6, SectionId = 6, Plantilla = 4 },
                new PositionT { Id = 25, PosCode = "URICDTE01", Name = "IT & Support Services Staff", DivisionId = 1, DepartmentId = 6, SectionId = 7, Plantilla = 1 },  //URIC DTEX
                new PositionT { Id = 26, PosCode = "URICDTE02", Name = "Teleservices Support Staff / Online Coor", DivisionId = 1, DepartmentId = 6, SectionId = 7, Plantilla = 1 },

                new PositionT { Id = 27, PosCode = "GCASH01", Name = "Field Sales Manager", DivisionId = 1, DepartmentId = 8 , Plantilla = 1 },  //GCASH
                new PositionT { Id = 28, PosCode = "GCASH02", Name = "Field Sales Supervisor", DivisionId = 1, DepartmentId = 8, Plantilla = 1 },  //GCASH
                new PositionT { Id = 29, PosCode = "GCASHSER01", Name = "Field Sales Supervisor", DivisionId = 1, DepartmentId = 8, SectionId = 8, Plantilla = 1 },  //GCASH SERVICING
                new PositionT { Id = 30, PosCode = "GCASHSER02", Name = "Sonic DSP", DivisionId = 1, DepartmentId = 8, SectionId = 8, Plantilla = 4 },  
                new PositionT { Id = 31, PosCode = "GCASHSER03", Name = "DSP (Commando/Incubator)", DivisionId = 1, DepartmentId = 8, SectionId = 8, Plantilla = 6 },
                new PositionT { Id = 32, PosCode = "GCASHEXP01", Name = "Ambassador", DivisionId = 1, DepartmentId = 8, SectionId = 9, Plantilla = 2 },  //GCASH EXPANSION
                new PositionT { Id = 33, PosCode = "GCASHMER01", Name = "Merchandiser", DivisionId = 1, DepartmentId = 8, SectionId = 10, Plantilla = 3 }, //GCASH MERCHANDISING
                new PositionT { Id = 34, PosCode = "GCASHSCA01", Name = "Scan to Pay", DivisionId = 1, DepartmentId = 8, SectionId = 11, Plantilla = 3 }, //GCASH SCAN TO PAY

                new PositionT { Id = 35, PosCode = "GAINV01", Name = "Team Leader/Supervisor", DivisionId = 2, DepartmentId = 9, SectionId = 12, Plantilla = 1 }, //FAMS GA - IAP
                new PositionT { Id = 36, PosCode = "GAINV02", Name = "Trade Payable Staff", DivisionId = 2, DepartmentId = 9, SectionId = 12, Plantilla = 2 },
                new PositionT { Id = 37, PosCode = "GAINV03", Name = "Non Trade Payable Staff", DivisionId = 2, DepartmentId = 9, SectionId = 12, Plantilla = 1 },
                new PositionT { Id = 38, PosCode = "GAGEN01", Name = "Team Leader/Supervisor", DivisionId = 2, DepartmentId = 9, SectionId = 13, Plantilla = 1 }, //FAMS GA - GA
                new PositionT { Id = 39, PosCode = "GAGEN02", Name = "Gen Accounting Staff", DivisionId = 2, DepartmentId = 9, SectionId = 13, Plantilla = 3 },
                new PositionT { Id = 40, PosCode = "GATAX01", Name = "Team Leader/Supervisor", DivisionId = 2, DepartmentId = 9, SectionId = 14, Plantilla = 1 }, //FAMS GA - TC
                new PositionT { Id = 41, PosCode = "GATAX02", Name = "Tax and Compliance Staff", DivisionId = 2, DepartmentId = 9, SectionId = 14, Plantilla = 3 },
                new PositionT { Id = 42, PosCode = "SAACC01", Name = "Team Leader", DivisionId = 2, DepartmentId = 10, SectionId = 15, Plantilla = 1 }, //FAMS SA - AR
                new PositionT { Id = 43, PosCode = "SAACC02", Name = "Accounts Receivable Staff", DivisionId = 2, DepartmentId = 10, SectionId = 15, Plantilla = 4 },
                new PositionT { Id = 44, PosCode = "SACRE01", Name = "Credit and Collection Staff", DivisionId = 2, DepartmentId = 10, SectionId = 16, Plantilla = 6 }, //FAMS SA - CC
                new PositionT { Id = 45, PosCode = "SACRE02", Name = "C&C - Billings to Customer", DivisionId = 2, DepartmentId = 10, SectionId = 16, Plantilla = 1 },
                new PositionT { Id = 46, PosCode = "SABIL01", Name = "Billing to Cash Settlement Staff", DivisionId = 2, DepartmentId = 10, SectionId = 17, Plantilla = 1 }, //FAMS SA - BCS
                new PositionT { Id = 47, PosCode = "IT01", Name = "Manager", DivisionId = 2, DepartmentId = 11, Plantilla = 1 }, //FAMS IT
                new PositionT { Id = 48, PosCode = "IT02", Name = "IT Associate", DivisionId = 2, DepartmentId = 11, Plantilla = 2 },
                new PositionT { Id = 49, PosCode = "IT03", Name = "IT Staff", DivisionId = 2, DepartmentId = 11, Plantilla = 3 },
                new PositionT { Id = 50, PosCode = "TREASURYCAS01", Name = "Cash Operations Head", DivisionId = 2, DepartmentId = 12, SectionId = 18, Plantilla = 1 }, //FAMS T -CO
                new PositionT { Id = 51, PosCode = "TREASURYCAS02", Name = "Davao Cashier", DivisionId = 2, DepartmentId = 12, SectionId = 18, Plantilla = 3 },
                new PositionT { Id = 52, PosCode = "TREASURYCAS03", Name = "Cotabato Cashier", DivisionId = 2, DepartmentId = 12, SectionId = 18, Plantilla = 1 },
                new PositionT { Id = 53, PosCode = "TREASURYCAS04", Name = "Kidapawan Cashier", DivisionId = 2, DepartmentId = 12, SectionId = 18, Plantilla = 1 },
                new PositionT { Id = 54, PosCode = "TREASURYCAS05", Name = "Digos Cashier", DivisionId = 2, DepartmentId = 12, SectionId = 18, Plantilla = 1 }
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
                new StatusT { Id = 2, Name = "Inactive" },
                new StatusT { Id = 3, Name = "Resigned" },
                new StatusT { Id = 4, Name = "Terminated" },
                new StatusT { Id = 5, Name = "Awol" },
                new StatusT { Id = 6, Name = "Retired" }
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

            modelBuilder.Entity<CashBondT>().HasData(
             new CashBondT { Id = 1, Name = "Yes" },
             new CashBondT { Id = 2, Name = "No" }
            );

            modelBuilder.Entity<RateTypeT>().HasData(
             new RateTypeT { Id = 1, Name = "Monthly Rate" },
             new RateTypeT { Id = 2, Name = "Daily Rate" }
            );

            modelBuilder.Entity<ScheduleTypeT>().HasData(
             new ScheduleTypeT { Id = 1, Name = "Regular", TimeIn = "08:00 AM", TimeOut = "05:00 PM" }
            );

            modelBuilder.Entity<RestDayT>().HasData(
             new RestDayT { Id = 1, Name = "Sunday" },
             new RestDayT { Id = 2, Name = "Monday" },
             new RestDayT { Id = 3, Name = "Tuesday" },
             new RestDayT { Id = 4, Name = "Wednesday" },
             new RestDayT { Id = 5, Name = "Thursday" },
             new RestDayT { Id = 6, Name = "Friday" },
             new RestDayT { Id = 7, Name = "Saturday" }
            );

            modelBuilder.Entity<UserRoleT>().HasData(
             new UserRoleT { Id = 1, Name = "Administrator", RoleCode = "Admin" },
             new UserRoleT { Id = 2, Name = "User", RoleCode = "User" }
            );
        }

        public DbSet<UserMasterT> UserMasterT { get; set; }
        public DbSet<UserRoleT> UserRoleT { get; set; }


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
        public DbSet<EmploymentDateT> EmploymentDateT { get; set; }

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

        //PAYROLL
        public DbSet<CashBondT> CashBondT { get; set; }
        public DbSet<RateTypeT> RateTypeT { get; set; }
        public DbSet<ScheduleTypeT> ScheduleTypeT { get; set; }
        public DbSet<PayrollT> PayrollT { get; set; }
        public DbSet<RestDayT> RestDayT { get; set; }
    }
}
