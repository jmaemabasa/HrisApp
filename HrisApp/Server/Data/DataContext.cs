using HrisApp.Shared.Models.Announcement;
using HrisApp.Shared.Models.Assets.Consumables;
using HrisApp.Shared.Models.Assets.Licenses;
using HrisApp.Shared.Models.Attendance;
using HrisApp.Shared.Models.Audit;
using HrisApp.Shared.Models.Dashboard;

namespace HrisApp.Server.Data
{
#nullable disable

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

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
                new SectionT { Id = 4, Name = "Hapi Dealer", DivisionId = 1, DepartmentId = 6 }, //uric
                new SectionT { Id = 5, Name = "Servicing", DivisionId = 1, DepartmentId = 6 },
                new SectionT { Id = 6, Name = "Expansion", DivisionId = 1, DepartmentId = 6 },
                new SectionT { Id = 7, Name = "DTEX", DivisionId = 1, DepartmentId = 6 },
                new SectionT { Id = 8, Name = "Servicing", DivisionId = 1, DepartmentId = 8 }, //Gcash
                new SectionT { Id = 9, Name = "Expansion", DivisionId = 1, DepartmentId = 8 },
                new SectionT { Id = 10, Name = "Merchandising", DivisionId = 1, DepartmentId = 8 },
                new SectionT { Id = 11, Name = "Scan To Pay", DivisionId = 1, DepartmentId = 8 },
                new SectionT { Id = 12, Name = "Inventory and Accnts. Payable", DivisionId = 1, DepartmentId = 9 }, //FAMS GA
                new SectionT { Id = 13, Name = "General Accounting", DivisionId = 1, DepartmentId = 9 },
                new SectionT { Id = 14, Name = "Tax and Compliance", DivisionId = 1, DepartmentId = 9 },
                new SectionT { Id = 15, Name = "Accounts Receivable", DivisionId = 1, DepartmentId = 10 }, //FAMS SA
                new SectionT { Id = 16, Name = "Credit and Collection", DivisionId = 1, DepartmentId = 10 },
                new SectionT { Id = 17, Name = "Billing to Cash Settlement", DivisionId = 1, DepartmentId = 10 }
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
             new RateTypeT { Id = 1, Name = "Monthly" },
             new RateTypeT { Id = 2, Name = "Daily" },
             new RateTypeT { Id = 3, Name = "Hourly" }
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
             new UserRoleT { Id = 1, Name = "System Administrator", RoleCode = "SysAdmin" },
             new UserRoleT { Id = 2, Name = "User", RoleCode = "User" },
             new UserRoleT { Id = 3, Name = "HR", RoleCode = "HR" },
             new UserRoleT { Id = 4, Name = "Technical", RoleCode = "Technical" },
             new UserRoleT { Id = 5, Name = "General Admin", RoleCode = "GenAdmin" },
             new UserRoleT { Id = 6, Name = "CAD Admin", RoleCode = "CadAdmin" }
            );

            modelBuilder.Entity<LeaveTypesT>().HasData(
                new LeaveTypesT { Id = 1, Name = "Emergency", Unit = 1, Description = "Day", Code = "EL" },
                new LeaveTypesT { Id = 2, Name = "Maternity", Unit = 1, Description = "Day", Code = "ML" },
                new LeaveTypesT { Id = 3, Name = "Paternity", Unit = 1, Description = "Day", Code = "PL" },
                new LeaveTypesT { Id = 4, Name = "Sick", Unit = 1, Description = "Day", Code = "SL" },
                new LeaveTypesT { Id = 5, Name = "Vacation", Unit = 1, Description = "Day", Code = "VL" },
                new LeaveTypesT { Id = 6, Name = "Other", Unit = 1, Description = "Day", Code = "OL" }
            );

            modelBuilder.Entity<AssetStatusT>().HasData(
             new RestDayT { Id = 1, Name = "IN USED" },
             new RestDayT { Id = 2, Name = "NOT USED" },
             new RestDayT { Id = 3, Name = "FOR REPAIR" },
             new RestDayT { Id = 4, Name = "IN SERVICE CENTER" },
             new RestDayT { Id = 5, Name = "FOR DISPOSAL" },
             new RestDayT { Id = 6, Name = "DISPOSED" }
            );

            modelBuilder.Entity<AssetTypesT>().HasData(
             new AssetTypesT { Id = 1, AType_Code = "001", AType_Name = "Main" },
             new AssetTypesT { Id = 2, AType_Code = "002", AType_Name = "Accessory" },
             new AssetTypesT { Id = 3, AType_Code = "003", AType_Name = "Licenses" },
             new AssetTypesT { Id = 4, AType_Code = "004", AType_Name = "Consumables" }
            );

            modelBuilder.Entity<ConsumablesT>()
                .Property(e => e.Id)
                .UseIdentityColumn(1, 1); 

            modelBuilder.Entity<UOMT>()
               .Property(e => e.Id)
               .UseIdentityColumn(1, 1);

            modelBuilder.Entity<ConsumableImageT>()
              .Property(e => e.Id)
              .UseIdentityColumn(1, 1); 
            
            modelBuilder.Entity<Cons_TransactionT>()
              .Property(e => e.Id)
              .UseIdentityColumn(1, 1);
            
            modelBuilder.Entity<VendorT>()
              .Property(e => e.Id)
              .UseIdentityColumn(1, 1);

            modelBuilder.Entity<AssetLicenseT>()
              .Property(e => e.Id)
              .UseIdentityColumn(1, 1);

            modelBuilder.Entity<AssetLicenseRemarksT>()
              .Property(e => e.Id)
              .UseIdentityColumn(1, 1);

            modelBuilder.Entity<AssetLicenseHistoryT>()
              .Property(e => e.Id)
              .UseIdentityColumn(1, 1);

            modelBuilder.Entity<AssLicenseImageT>()
              .Property(e => e.Id)
              .UseIdentityColumn(1, 1);

            modelBuilder.Entity<MainAssetLicensesT>()
              .Property(e => e.Id)
              .UseIdentityColumn(1, 1);

            modelBuilder.Entity<Emp_RateHistoryT>()
              .Property(e => e.Id)
              .UseIdentityColumn(1, 1);

        }

        //USERS
        public DbSet<UserMasterT> UserMasterT { get; set; }

        public DbSet<UserRoleT> UserRoleT { get; set; }
        public DbSet<AuditlogsT> AuditlogsT { get; set; }

        //Master Data
        public DbSet<DivisionT> DivisionT { get; set; }

        public DbSet<DepartmentT> DepartmentT { get; set; }
        public DbSet<SectionT> SectionT { get; set; }
        public DbSet<PositionT> PositionT { get; set; }
        public DbSet<SubPositionT> SubPositionT { get; set; }
        public DbSet<AreaT> AreaT { get; set; }
        public DbSet<PositionTechSkillT> PositionTechSkillT { get; set; }
        public DbSet<PositionKnowledgeT> PositionKnowledgeT { get; set; }
        public DbSet<PositionComAppT> PositionComAppT { get; set; }
        public DbSet<PositionWorkExpT> PositionWorkExpT { get; set; }
        public DbSet<PositionEducT> PositionEducT { get; set; }
        public DbSet<PosMPExternalT> PosMPExternalT { get; set; }
        public DbSet<PosMPInternalT> PosMPInternalT { get; set; }
        public DbSet<DailyTotalPlantillaT> DailyTotalPlantillaT { get; set; }
        public DbSet<UOMT> UOMT { get; set; }
        public DbSet<VendorT> VendorT { get; set; }

        public DbSet<LeaveTypesT> LeaveTypesT { get; set; }
        public DbSet<Emp_LeaveCreditT> Emp_LeaveCreditT { get; set; }
        public DbSet<Emp_LeaveHistoryT> Emp_LeaveHistoryT { get; set; }

        //Employee Data
        public DbSet<EmployeeT> EmployeeT { get; set; }

        public DbSet<EmploymentStatusT> EmploymentStatusT { get; set; }
        public DbSet<InactiveStatusT> InactiveStatusT { get; set; }
        public DbSet<StatusT> StatusT { get; set; }
        public DbSet<CivilStatusT> CivilStatusT { get; set; }
        public DbSet<ReligionT> ReligionT { get; set; }
        public DbSet<GenderT> GenderT { get; set; }
        public DbSet<EmerRelationshipT> EmerRelationshipT { get; set; }
        public DbSet<Emp_EmploymentDateT> Emp_EmploymentDateT { get; set; }
        public DbSet<Emp_ProfBackgroundT> Emp_ProfBackgroundT { get; set; }
        public DbSet<Emp_PosHistoryT> Emp_PosHistoryT { get; set; }
        public DbSet<Emp_EvaluationT> Emp_EvaluationT { get; set; }
        public DbSet<Emp_RateHistoryT> Emp_RateHistoryT { get; set; }

        //EDUCATIONS
        public DbSet<Emp_CollegeT> Emp_CollegeT { get; set; }

        public DbSet<Emp_DoctorateT> Emp_DoctorateT { get; set; }
        public DbSet<Emp_MasteralT> Emp_MasteralT { get; set; }
        public DbSet<Emp_OtherEducT> Emp_OtherEducT { get; set; }
        public DbSet<Emp_PrimaryT> Emp_PrimaryT { get; set; }
        public DbSet<Emp_SecondaryT> Emp_SecondaryT { get; set; }
        public DbSet<Emp_SeniorHST> Emp_SeniorHST { get; set; }

        //LICENSE AND TRAINING
        public DbSet<Emp_LicenseT> Emp_LicenseT { get; set; }

        public DbSet<Emp_TrainingT> Emp_TrainingT { get; set; }

        //Address
        public DbSet<Emp_AddressT> Emp_AddressT { get; set; }

        //IMAGES AND FILES
        public DbSet<DocumentT> DocumentT { get; set; }

        public DbSet<EmpPictureT> EmpPictureT { get; set; }

        //PAYROLL
        public DbSet<CashBondT> CashBondT { get; set; }

        public DbSet<RateTypeT> RateTypeT { get; set; }
        public DbSet<ScheduleTypeT> ScheduleTypeT { get; set; }
        public DbSet<Emp_PayrollT> Emp_PayrollT { get; set; }
        public DbSet<RestDayT> RestDayT { get; set; }

        //APPLICANT
        public DbSet<ApplicantT> ApplicantT { get; set; }

        public DbSet<App_AddressT> App_AddressT { get; set; }

        //app Family
        public DbSet<App_ChildrenT> App_ChildrenT { get; set; }

        public DbSet<App_SiblingT> App_SiblingT { get; set; }

        //app Prof Background
        public DbSet<App_ProfBackgroundT> App_ProfBackgroundT { get; set; }

        //app Prof Education
        public DbSet<App_PrimaryT> App_PrimaryT { get; set; }

        public DbSet<App_SecondaryT> App_SecondaryT { get; set; }
        public DbSet<App_SeniorHST> App_SeniorHST { get; set; }
        public DbSet<App_CollegeT> App_CollegeT { get; set; }
        public DbSet<App_DoctorateT> App_DoctorateT { get; set; }
        public DbSet<App_MasteralT> App_MasteralT { get; set; }
        public DbSet<App_OtherEducT> App_OtherEducT { get; set; }

        //app LICENSE AND TRAINING
        public DbSet<App_LicenseT> App_LicenseT { get; set; }

        public DbSet<App_TrainingT> App_TrainingT { get; set; }
        public DbSet<App_OtherAwardsT> App_OtherAwardsT { get; set; }

        //app Self Declaration
        public DbSet<App_SelfDeclarationT> App_SelfDeclarationT { get; set; }

        //ANNOUNCEMENT
        public DbSet<AnnouncementT> AnnouncementT { get; set; }

        //ATTENDANCE
        public DbSet<AttendanceRecordT> AttendanceRecordT { get; set; }

        public DbSet<ShiftTimetableT> ShiftTimetableT { get; set; }

        //ASSETS
        public DbSet<AssetStatusT> AssetStatusT { get; set; }

        public DbSet<AssetTypesT> AssetTypesT { get; set; }

        public DbSet<AssetCategoryT> AssetCategoryT { get; set; }
        public DbSet<AssetSubCategoryT> AssetSubCategoryT { get; set; }
        public DbSet<AssetAccessoryT> AssetAccessoryT { get; set; }
        public DbSet<AssetMasterT> AssetMasterT { get; set; }
        public DbSet<AssetMasterHistoryT> AssetMasterHistoryT { get; set; }
        public DbSet<AssetAccessHistoryT> AssetAccessHistoryT { get; set; }
        public DbSet<MainAssetAccessoriesT> MainAssetAccessoriesT { get; set; }
        public DbSet<AssetImageT> AssetImageT { get; set; }
        public DbSet<AssetAccessImageT> AssetAccessImageT { get; set; }
        public DbSet<AssetLastCheckT> AssetLastCheckT { get; set; }
        public DbSet<MainRemarksT> MainRemarksT { get; set; }
        public DbSet<AccessoryRemarksT> AccessoryRemarksT { get; set; }
        public DbSet<AssetVehiclesT> AssetVehiclesT { get; set; }
        public DbSet<VehicleRemarksT> VehicleRemarksT { get; set; }
        public DbSet<AssetVehicleImageT> AssetVehicleImageT { get; set; }
        public DbSet<ConsumablesT> ConsumablesT { get; set; }
        public DbSet<ConsumableImageT> ConsumableImageT { get; set; }
        public DbSet<ConsumableRemarksT> ConsumableRemarksT { get; set; }
        public DbSet<Cons_TransactionT> Cons_TransactionT { get; set; }
        public DbSet<AssetLicenseT> AssetLicenseT { get; set; }
        public DbSet<AssetLicenseRemarksT> AssetLicenseRemarksT { get; set; }
        public DbSet<AssetLicenseHistoryT> AssetLicenseHistoryT { get; set; }
        public DbSet<AssLicenseImageT> AssLicenseImageT { get; set; }
        public DbSet<MainAssetLicensesT> MainAssetLicensesT { get; set; }

    }
}