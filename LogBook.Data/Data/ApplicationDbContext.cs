using LogBook.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LogBook.DataLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Activity> Logs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser", "System");
            modelBuilder.Entity<LogType>().ToTable("LogTypes", "Data");
            modelBuilder.Entity<Activity>().ToTable("Logs", "Data");
            modelBuilder.Entity<Project>().ToTable("Projects", "Data");
            modelBuilder.Entity<Tenant>().ToTable("Tenant", "Data");
            modelBuilder.Entity<ErrorLog>().ToTable("ErrorLogs", "Data");
        }

        //private IHttpContextAccessor _httpContextAccessor { get; set; }
        //private readonly IEncryptionProvider _provider;

        //        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //        {
        //            // _httpContextAccessor = httpContextAccessor;
        //            this._provider = new GenerateEncryptionProvider("3fea5a718694c5a12edc24d4fba3a142");                                                
        //        }

        //        public DbSet<ActivityLog> ActivityLogs { get; set; }
        //        public DbSet<SystemVariables> SystemVariables { get; set; }
        //        public DbSet<FreelanceUser> FreelanceUsers { get; set; }
        //        public DbSet<EmailTemplate> EmailTemplates { get; set; }

        //        //Sync Service
        //        public DbSet<SyncTask> SyncTasks { get; set; }
        //        public DbSet<SyncFunction> SyncFunctions { get; set; }
        //        public DbSet<SyncTaskError> SyncTaskErrors { get; set; }
        //        public DbSet<XeroCredential> XeroCredentials { get; set; }
        //        public DbSet<SyncNameChange> SyncNameChanges { get; set; }
        //        //Security
        //        public DbSet<SecurityUser> SecurityUsers { get; set; }
        //        public DbSet<Permission> Permissions { get; set; }
        //        public DbSet<Assignment> Assignments { get; set; }
        //        //Barcodes
        //        public DbSet<DefaultTheme> DefaultThemes { get; set; }
        //        public DbSet<LabelTheme> LabelThemes { get; set; }
        //        public DbSet<ZebraPrinter> ZebraPrinters { get; set; }
        //        public DbSet<PrinterThemeAssignment> PrinterThemeAssignments { get; set; }
        //        public DbSet<StandardizationIndex> StandardizationIndexe { get; set; }
        //        public DbSet<ItemReport> ItemReports { get; set; }
        //        //RFID
        //        public DbSet<RFIDAssignment> RFIDAssigments { get; set; }
        //        public DbSet<EarlyReturn> EarlyReturns { get; set; }
        //        public DbSet<Capture_temp> CaptureTemps { get; set; }
        //        public DbSet<ReturningTag> ExpectedTags { get; set; }
        //        public DbSet<Fixture> Fixtures { get; set; }
        //        public DbSet<CrewPatch> CrewPatches { get; set; }

        //        public DbSet<RfidLog> RfidItemLogs { get; set; }
        //        public DbSet<RepairsReport> RepairsReports { get; set; }

        //        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //        {
        //            base.OnModelCreating(modelBuilder);
        //            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser", "CrewPortal");
        //            modelBuilder.Entity<ActivityLog>().ToTable("ActivityLog");
        //            modelBuilder.Entity<SystemVariables>().ToTable("SystemVariables");
        //            modelBuilder.Entity<XeroCredential>().ToTable("XeroCredentials");
        //            modelBuilder.Entity<Capture_temp>().ToTable("CaptureTemps");
        //            modelBuilder.Entity<ReturningTag>().ToTable("ExpectedTags");
        //            modelBuilder.Entity<Fixture>().ToTable("Fixtures");
        //            modelBuilder.Entity<CrewPatch>().ToTable("CrewPatches");

        //            modelBuilder.Entity<SyncFunction>().HasData(
        //                new SyncFunction { Id = 1, Deleted = null, Enabled = true, Name = "Company Update", Origin = 0 },
        //                new SyncFunction { Id = 2, Deleted = null, Enabled = true, Name = "Company Update", Origin = 1 },
        //                new SyncFunction { Id = 3, Deleted = null, Enabled = true, Name = "Company Created", Origin = 0 },
        //                new SyncFunction { Id = 6, Deleted = null, Enabled = true, Name = "Invoice Update", Origin = 0 },
        //                new SyncFunction { Id = 7, Deleted = null, Enabled = true, Name = "Invoice Update", Origin = 1 },
        //                new SyncFunction { Id = 9, Deleted = null, Enabled = true, Name = "Invoice Created", Origin = 0 },
        //                new SyncFunction { Id = 17, Deleted = null, Enabled = true, Name = "Company Note Sync", Origin = 1 },
        //                new SyncFunction { Id = 20, Deleted = null, Enabled = true, Name = "Person Update", Origin = 0 },
        //                new SyncFunction { Id = 21, Deleted = null, Enabled = true, Name = "Person Created", Origin = 0 },
        //                new SyncFunction { Id = 22, Deleted = null, Enabled = true, Name = "Purchase Order Update", Origin = 0 },
        //                new SyncFunction { Id = 23, Deleted = null, Enabled = true, Name = "Purchase Order Created", Origin = 0 },
        //                new SyncFunction { Id = 24, Deleted = null, Enabled = true, Name = "Project Update", Origin = 0 },
        //                new SyncFunction { Id = 25, Deleted = null, Enabled = true, Name = "Project Created", Origin = 0 },
        //                new SyncFunction { Id = 26, Deleted = null, Enabled = true, Name = "Invoice Credit Note Created", Origin = 0 },
        //                new SyncFunction { Id = 27, Deleted = null, Enabled = true, Name = "Invoice Credit Note Update", Origin = 0 },
        //                new SyncFunction { Id = 28, Deleted = null, Enabled = true, Name = "Purchase Order Credit Note Created", Origin = 0 },
        //                new SyncFunction { Id = 29, Deleted = null, Enabled = true, Name = "Purchase Order Credit Note Update", Origin = 0 },
        //                new SyncFunction { Id = 30, Deleted = null, Enabled = true, Name = "Purchase Order Paid Flag Sync", Origin = 1 }
        //            );

        //            modelBuilder.Entity<XeroCredential>().HasData(
        //                new XeroCredential { Id = 1, Deleted = null, KeyNumber = 1 },
        //                new XeroCredential { Id = 2, Deleted = null, KeyNumber = 2 }
        //            );

        //            modelBuilder.Entity<EmailTemplate>().HasData(
        //                new EmailTemplate
        //                {
        //                    Key = "CREWING_GENERATE_LINK",
        //                    Content = "Dear {{Name}} - Welcome to Edge, <br>You have created an Edge login using your email address. <br/>To login to your account and view your jobs please use the link below. <br/> <a href='{{URL}}'>Click Here</a>",
        //                    Subject = "Welcome to Edge",
        //                    BaseTemplate = "BasicTemplate.html"
        //                },
        //                new EmailTemplate
        //                {
        //                    Key = "FREELANCER_FORM_CONFIRMATION",
        //                    Content = "",
        //                    Subject = "TSL - Thank you for your application",
        //                    BaseTemplate = "FreelancerFormSubmittedTemplate.html"
        //                }
        //            );

        //            modelBuilder.Entity<SystemVariables>().HasData(
        //                new SystemVariables { Id = 1, Name = "HireTrackHeartbeatStatus", Value = null },
        //                new SystemVariables { Id = 2, Name = "HireTrackHeatbeatChecksBeforeEmail", Value = null },
        //                new SystemVariables { Id = 3, Name = "ErrorReporting_ToAddress", Value = "sam.tamplin@tsllighting.com" },
        //                new SystemVariables { Id = 4, Name = "ErrorReporting_FromAddress", Value = "syncservice@tsllighting.com" },
        //                new SystemVariables { Id = 5, Name = "ErrorReporting_FromAddress", Value = "syncservice@tsllighting.com" },
        //                new SystemVariables { Id = 6, Name = "AccountSync_ExcludeAccRefs", Value = "TESTACCOUNTREF" },
        //                new SystemVariables { Id = 7, Name = "AccountSync_IncludeOnlyAccRefs", Value = null },
        //                new SystemVariables { Id = 8, Name = "AccountSync_OverrideSageStatusToHtStatusZeroCredit", Value = "6" },
        //                new SystemVariables { Id = 9, Name = "AccountSync_OverrideSageStatusIfCreditExceeded", Value = "0,1,2,4,5,8,9,10" },
        //                new SystemVariables { Id = 10, Name = "AccountSync_OverrideSageStatusToHtStatus", Value = "4" },
        //                new SystemVariables { Id = 11, Name = "SalesManagerXeroTrackingGuid", Value = "c2668201-468c-4480-bbc2-109a768cbfeb" },
        //                new SystemVariables { Id = 12, Name = "JobTypeXeroTrackingGuid", Value = "bdd811fd-87d9-4ae8-b810-eac45329c7d2" },
        //                new SystemVariables { Id = 13, Name = "InvoiceConversion_NominalCode", Value = "5500,4500|5530,4530|5535,4535|5540,4540|5550,4550|5560,4560|5570,4570|5590,4590|5600,4600|5610,4610|5710,4710|5800,4800" },
        //                new SystemVariables { Id = 14, Name = "InvoiceTaxLookup", Value = "1,ECZROUTPUTSERVICES|3,SROUTPUT|4,OUTPUT2|6,EXEMPTOUTPUT|7,SROUTPUT|8,ZERORATEDOUTPUT" },
        //                new SystemVariables { Id = 15, Name = "PurchaseOrderConversion_NominalCode", Value = "4500,5500|4530,5530|4535,5535|4540,5540|4550,5550|4560,5560|4570,5570|4590,5590|4600,5600|4610,5610|4710,5710|4800,5800|4520,5500" },
        //                new SystemVariables { Id = 16, Name = "POTaxLookup", Value = "1,NONE|3,SRINPUT|4,INPUT2|6,EXEMPTINPUT|7,SRINPUT|8,ZERORATEDINPUT" },
        //                new SystemVariables { Id = 18, Name = "HasXeroFailedTokenEmailBeenSent", Value = "false" },
        //                new SystemVariables { Id = 19, Name = "QuoteOfTheDayID", Value = "0" },
        //                new SystemVariables { Id = 20, Name = "QuoteOfTheDayToday", Value = "20/01/2023" },
        //                new SystemVariables { Id = 21, Name = "HireTrackHeartbeatBackupStatus", Value = null },
        //                new SystemVariables { Id = 22, Name = "HireTrackHeartbeatBackupChecksBeforeEmail", Value = null },
        //                new SystemVariables { Id = 23, Name = "CreateBarcodeInProgress", Value = null }

        //            );

        //            //System and Security
        //            modelBuilder.Entity<SecurityUser>().ToTable("SecurityUsers");
        //            modelBuilder.Entity<SecurityHeadOfDepartment>().ToTable("SecurityHeadOfDepartments");
        //            modelBuilder.Entity<Permission>().ToTable("Permissions");
        //            modelBuilder.Entity<Assignment>().ToTable("Assignments");
        //            modelBuilder.Entity<DataLayer.Models.System.Activity>().ToTable("ActivityLogs", "System");

        //            //Transport Tables
        //            modelBuilder.Entity<Route>().ToTable("Routes");
        //            modelBuilder.Entity<RouteAssignment>().ToTable("RouteAssignments");
        //            modelBuilder.Entity<RouteCustomDrop>().ToTable("RouteCustomDrops");
        //            modelBuilder.Entity<Location>().ToTable("RouteLocations");
        //            modelBuilder.Entity<Restriction>().ToTable("RouteRestrictions");
        //            modelBuilder.Entity<CalendarEvent>().ToTable("TransportCalendarEvents");
        //            modelBuilder.Entity<ThirdPartyAssignment>().ToTable("TransportThirdPartyAssignments");
        //            modelBuilder.Entity<OnSiteContact>().ToTable("TransportContacts");
        //            modelBuilder.Entity<Activity>().ToTable("TransportActivityLog");

        //            //Logistics Tables
        //            modelBuilder.Entity<Models.Logistics.Assignment>().ToTable("LogisiticsAssignments");
        //            modelBuilder.Entity<Models.Logistics.POD>().ToTable("LogisiticsPODs");

        //            modelBuilder.Entity<Quote>().ToTable("DashboardQuotes");

        //            //DePrep Tables
        //            modelBuilder.Entity<DePrepAssignment>().ToTable("DePrepAssignments");
        //            modelBuilder.Entity<DePrepActivity>().ToTable("DePrepActivities");

        //            //(New) Crewing Tables
        //            modelBuilder.Entity<FreelancerForm>().ToTable("FreelancerForms", "Crewing");
        //            modelBuilder.Entity<FreelancerSkill>().ToTable("FreelancerSkills", "Crewing");
        //            modelBuilder.Entity<FreelancerAttribute>().ToTable("FreelancerAttributes", "Crewing");
        //            modelBuilder.Entity<FreelancerTermsAndConditions>().ToTable("FreelancerTermsAndConditions", "Crewing");
        //            modelBuilder.Entity<HTSkills>().ToTable("HTSkills", "Crewing");
        //            modelBuilder.Entity<HTAttributes>().ToTable("HTAttributes", "Crewing");
        //            modelBuilder.Entity<ExtraTOIL>().ToTable("ExtraTOIL", "Crewing");
        //            modelBuilder.Entity<AvailabilityRequest>().ToTable("AvailabilityRequests", "Crewing");
        //            modelBuilder.Entity<AvailabilityRequestSavedContent>().ToTable("AvailabilityRequestSavedContent", "Crewing");
        //            modelBuilder.Entity<AvailabilityRequestShift>().ToTable("AvailabilityRequestShifts", "Crewing");
        //            modelBuilder.Entity<AvailabilityRequestInvite>().ToTable("AvailabilityRequestInvites", "Crewing");
        //            modelBuilder.Entity<AvailabilityRequestResponse>().ToTable("AvailabilityRequestResponses", "Crewing");

        //            modelBuilder.Entity<RouteCustomDrop>().HasData(
        //                new RouteCustomDrop { Id = 1, Title = "TSL Basingstoke", Latitude = "51.28154783885638", Longitude = "-1.0677388870134288" }
        //            );
        //            modelBuilder.Entity<Location>().HasData(
        //                new Location { Id = 1, Name = "Use Delivery Address", Deleted = null, Latitude = "", Longitude = "" },
        //                new Location { Id = 2, Name = "Use Main Address", Deleted = null, Latitude = "", Longitude = ""  }
        //            );

        //            modelBuilder.Entity<Permission>().HasData(
        //                //Security
        //                new Permission { Id = 1, Deleted = null, Name = "Security", },
        //                new Permission { Id = 2, Deleted = null, Name = "View Permissions", PermissionsHeaderId = 1 },
        //                new Permission { Id = 10, Deleted = null, Name = "Modify Permissions", PermissionsHeaderId = 1 },

        //                //Administrator
        //                new Permission { Id = 3, Deleted = null, Name = "Administration", },
        //                //new Permission { Id = 4, Deleted = null, Name = "Super Admin", PermissionsHeaderId = 3 },
        //                //new Permission { Id = 5, Deleted = null, Name = "Administrator", PermissionsHeaderId = 3 },
        //                new Permission { Id = 6, Deleted = null, Name = "Monitor", PermissionsHeaderId = 3 },
        //                new Permission { Id = 7, Deleted = null, Name = "Send Report For Users", PermissionsHeaderId = 3 },
        //                new Permission { Id = 26, Deleted = null, Name = "Department Admin", PermissionsHeaderId = 3 },
        //                new Permission { Id = 47, Deleted = null, Name = "Quotes", PermissionsHeaderId = 3 },
        //                new Permission { Id = 69, Deleted = null, Name = "Emulate Crew", PermissionsHeaderId = 3 },
        //                new Permission { Id = 77, Deleted = null, Name = "Emulate Staff", PermissionsHeaderId = 3 },

        //                 //(New) Crewing
        //                new Permission { Id = 62, Deleted = null, Name = "Crewing"},
        //                //new Permission { Id = 59, Deleted = null, Name = "Freelancer Admin Portal View", PermissionsHeaderId = 8 },
        //                //new Permission { Id = 60, Deleted = null, Name = "Freelancer Admin Portal Edit", PermissionsHeaderId = 8 },
        //                new Permission { Id = 63, Deleted = null, Name = "Admin View", PermissionsHeaderId = 62 },
        //                new Permission { Id = 64, Deleted = null, Name = "Admin Edit", PermissionsHeaderId = 62 },
        //                new Permission { Id = 65, Deleted = null, Name = "Schedule View", PermissionsHeaderId = 62 },
        //                new Permission { Id = 66, Deleted = null, Name = "Schedule Edit", PermissionsHeaderId = 62 },
        //                new Permission { Id = 67, Deleted = null, Name = "Map View", PermissionsHeaderId = 62 },
        //                new Permission { Id = 68, Deleted = null, Name = "Schedule Toil", PermissionsHeaderId = 62},

        //                //Jobs
        //                new Permission { Id = 8, Deleted = null, Name = "Jobs", },
        //                new Permission { Id = 9, Deleted = null, Name = "Project Management", PermissionsHeaderId = 8 },
        //                new Permission { Id = 15, Deleted = null, Name = "Full Access", PermissionsHeaderId = 8 },
        //                new Permission { Id = 33, Deleted = null, Name = "Kit Lists", PermissionsHeaderId = 8 },
        //                new Permission { Id = 37, Deleted = null, Name = "Schedules", PermissionsHeaderId = 8 },
        //                new Permission { Id = 53, Deleted = null, Name = "DePrep", PermissionsHeaderId = 8 },
        //                new Permission { Id = 55, Deleted = null, Name = "DePrep Warehouse View All", PermissionsHeaderId = 8 },
        //                new Permission { Id = 56, Deleted = null, Name = "DePrep Project Managers", PermissionsHeaderId = 8 },
        //                new Permission { Id = 57, Deleted = null, Name = "DePrep Assets", PermissionsHeaderId = 8 },
        //                new Permission { Id = 61, Deleted = null, Name = "DePrep Reports", PermissionsHeaderId = 8 },

        //                //Accounts
        //                new Permission { Id = 11, Deleted = null, Name = "Accounts", },
        //                new Permission { Id = 12, Deleted = null, Name = "Sync Service", PermissionsHeaderId = 11 },

        //                //Inventory
        //                new Permission { Id = 13, Deleted = null, Name = "Inventory", },
        //                new Permission { Id = 14, Deleted = null, Name = "Active Jobs", PermissionsHeaderId = 13 },
        //                new Permission { Id = 19, Deleted = null, Name = "Repairs", PermissionsHeaderId = 13 },
        //                new Permission { Id = 49, Deleted = null, Name = "Repair Fault", PermissionsHeaderId = 13 },
        //                new Permission { Id = 52, Deleted = null, Name = "QR Code Print", PermissionsHeaderId = 13 },

        //                //Barcodes
        //                new Permission { Id = 16, Deleted = null, Name = "Barcodes", },
        //                new Permission { Id = 17, Deleted = null, Name = "Reprint Existing", PermissionsHeaderId = 16 },
        //                new Permission { Id = 18, Deleted = null, Name = "Edit Create", PermissionsHeaderId = 16 },
        //                new Permission { Id = 20, Deleted = null, Name = "Rename Barcode", PermissionsHeaderId = 16 },
        //                new Permission { Id = 27, Deleted = null, Name = "Missing Serial Numbers", PermissionsHeaderId = 16 },
        //                new Permission { Id = 29, Deleted = null, Name = "Barcode Log", PermissionsHeaderId = 3 },
        //                new Permission { Id = 38, Deleted = null, Name = "Barcode Type Update", PermissionsHeaderId = 3 },
        //                new Permission { Id = 54, Deleted = null, Name = "Create Barcodes", PermissionsHeaderId = 16 },

        //                //RFID
        //                new Permission { Id = 30, Deleted = null, Name = "RFID"},
        //                new Permission { Id = 32, Deleted = null, Name = "RFID User", PermissionsHeaderId = 30 },
        //                new Permission { Id = 34, Deleted = null, Name = "Early Return Approver", PermissionsHeaderId = 30 },
        //                new Permission { Id = 35, Deleted = null, Name = "RFID Assignment", PermissionsHeaderId = 30 },
        //                new Permission { Id = 36, Deleted = null, Name = "RFID Assignment - (HOME PAGE)", PermissionsHeaderId = 30 },
        //                new Permission { Id = 70, Deleted = new DateTime(2024, 4, 16), Name = "Assign RFID", PermissionsHeaderId = 30 },
        //                new Permission { Id = 71, Deleted = null, Name = "Assignment List", PermissionsHeaderId = 30 },
        //                new Permission { Id = 72, Deleted = null, Name = "Capture List", PermissionsHeaderId = 30 },
        //                new Permission { Id = 73, Deleted = null, Name = "Expected Item List", PermissionsHeaderId = 30 },
        //                new Permission { Id = 74, Deleted = null, Name = "Readers List", PermissionsHeaderId = 30 },
        //                new Permission { Id = 75, Deleted = new DateTime(2024, 4, 16), Name = "Early Returns", PermissionsHeaderId = 30 },
        //                new Permission { Id = 76, Deleted = null, Name = "RFID Log", PermissionsHeaderId = 30 },

        //                //Transport
        //                new Permission { Id = 21, Deleted = null, Name = "Transport", },
        //                new Permission { Id = 22, Deleted = null, Name = "View", PermissionsHeaderId = 21 },
        //                new Permission { Id = 23, Deleted = null, Name = "Plan Routes", PermissionsHeaderId = 21 },
        //                new Permission { Id = 24, Deleted = null, Name = "Review", PermissionsHeaderId = 21 },
        //                new Permission { Id = 25, Deleted = null, Name = "Write", PermissionsHeaderId = 21 },
        //                new Permission { Id = 28, Deleted = null, Name = "Driver", PermissionsHeaderId = 21 },
        //                new Permission { Id = 31, Deleted = null, Name = "Exceptions", PermissionsHeaderId = 21 },
        //                new Permission { Id = 48, Deleted = null, Name = "Calendar", PermissionsHeaderId = 21 },
        //                new Permission { Id = 50, Deleted = null, Name = "Companies", PermissionsHeaderId = 21 },
        //                new Permission { Id = 51, Deleted = null, Name = "Locations", PermissionsHeaderId = 21 },

        //                //Logistics
        //                new Permission { Id = 41, Deleted = null, Name = "Logistics", },
        //                new Permission { Id = 42, Deleted = null, Name = "KitLists", PermissionsHeaderId = 41 },
        //                new Permission { Id = 43, Deleted = null, Name = "Programme", PermissionsHeaderId = 41 },
        //                new Permission { Id = 44, Deleted = null, Name = "Schedule", PermissionsHeaderId = 41 },
        //                new Permission { Id = 45, Deleted = null, Name = "POD", PermissionsHeaderId = 41 },
        //                new Permission { Id = 46, Deleted = null, Name = "PODs", PermissionsHeaderId = 41 }
        //            );

        //            //BARCODES AND RFID related tables
        //            modelBuilder.Entity<DefaultTheme>().ToTable("DefaultThemes");
        //            modelBuilder.Entity<LabelTheme>().ToTable("LabelThemes");
        //            modelBuilder.Entity<ZebraPrinter>().ToTable("ZebraPrinter");
        //            modelBuilder.Entity<PrinterThemeAssignment>().ToTable("PrinterThemeAssignment");
        //            modelBuilder.Entity<StandardizationIndex>().ToTable("StandardizationIndex");
        //            modelBuilder.Entity<ItemReport>().ToTable("ItemReports");

        //            modelBuilder.Entity<StandardizationIndex>().HasData(new StandardizationIndex() { Id = 1, SIV = 200000});

        //            modelBuilder.Entity<LabelTheme>().HasData(
        //                new LabelTheme
        //                {
        //                    Id = 1,
        //                    Name = "Standard Barcode",
        //                    ThemeBuilder = @"
        //^XA
        //^LH0,0
        //^CI28


        //^FO72,84^BY6
        //^BCN,160,N,N
        //^FD>;{0}^FS

        //^A0N,35
        //^FO18,35
        //^FH^FDTSL Lighting Ltd^FS

        //^A0N,35
        //^FO12,252
        //^FH^FD{1}^FS

        //^FO84,214
        //^GB{2},30,15,W,0^FS

        //^A0N,35
        //^FO84,216
        //^FH^FD{0}^FS
        //^XZ",
        //                    Deleted = null
        //                },
        //                new LabelTheme
        //                {
        //                    Id = 2,
        //                    Name = "Thin Silver",
        //                    ThemeBuilder = @"
        //^XA

        //^LH0,0
        //^CI28


        //^FO60,60^BY6
        //^BCN,80,N,N
        //^FD>9{0}^FS

        //^A0N,45
        //^FO45,20
        //^FH^FDTSL Lighting Ltd^FS

        //^A0N,40
        //^FO370,20
        //^FH^FD{0}^FS

        //^XZ",
        //                    Deleted = null
        //                },
        //                new LabelTheme
        //                {
        //                    Id = 3,
        //                    Name = "Wrap Around",
        //                    ThemeBuilder = @"
        //^XA
        //^LH0,0
        //^CI28


        //^FO72,108^BY2
        //^BCN,130,N,N
        //^FD>;{0}^FS

        //^A0N,35
        //^FO24,60
        //^FH^FDTSL Lighting Ltd^FS

        //^A0N,35
        //^FO72,248
        //^FH^FD{0}^FS

        //^XZ",
        //                    Deleted = null
        //                }
        //            );
        //            modelBuilder.Entity<RFIDAssignment>().ToTable("RFIDAssignment");
        //            modelBuilder.Entity<EarlyReturn>().ToTable("EarlyReturn");
        //            modelBuilder.Entity<RfidLog>().ToTable("RfidLogs");

        //            // Encryption
        //            modelBuilder.UseEncryption(this._provider);


        //        }
    }
}
