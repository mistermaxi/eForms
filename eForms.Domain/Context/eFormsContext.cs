using eForms.Domain.Enums;
using eForms.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;

namespace eForms.Domain.Context
{
    public class eFormsContext : DbContext, IeFormsContext
    {
        
       
        #region Authorization
        public DbSet<User> tbl_Users { get; set; }
        public DbSet<UserRole> tbl_UserRoles { get; set; }
        #endregion

        #region eForms
        public DbSet<OpenNetReq> tbl_OpenNetReq { get; set; }
        public DbSet<ClassNetReq> tbl_ClassNetReq { get; set; }
        public DbSet<DS7642> tbl_DS7642 { get; set; }
        public DbSet<DS7642Detail> tbl_DS7642Detail { get; set; }
        public DbSet<NewArrvEMP> tbl_NewArrvEMP { get; set; }
        public DbSet<NewArrvDEP> tbl_NewArrvDEP { get; set; }
        public DbSet<NewArrvEMERG> tbl_NewArrvEMERG { get; set; }
        public DbSet<NewArrvLANG> tbl_NewArrvLANG { get; set; }
        public DbSet<UploadDoc> tbl_UploadDocs { get; set; }
        
        #endregion

        #region Inventory
        public DbSet<Manufacturer> tbl_Manufacturer { get; set; }
        public DbSet<MBDevice> tbl_MBDevice { get; set; }
        public DbSet<Model> tbl_Model { get; set; }
        public DbSet<Sim> tbl_Sim { get; set; }
        public DbSet<Transaction> tbl_Transaction { get; set; }
        public DbSet<TransactionDetail> tbl_TransactionDetail { get; set; }
        #endregion

        #region settings
        public DbSet<BuildingAnnexes> tbl_rBuildingsAnnex { get; set; }
        public DbSet<Forms> tbl_rForms { get; set; }
        public DbSet<Country> tbl_rCountries { get; set; }
        public DbSet<EmployeeType> tbl_rEmployeeTypes { get; set; }
        public DbSet<ISO> tbl_rISO { get; set; }
        public DbSet<ISSO> tbl_rISSO { get; set; }
        public DbSet<IPC> tbl_rIPCs { get; set; }
        public DbSet<Languages> tbl_rLanguages { get; set; }
        public DbSet<MilitaryRanks> tbl_rMilitaryRanks { get; set; }
        public DbSet<Posts> tbl_rPosts { get; set; }
        public DbSet<Prefixes> tbl_rPrefixes { get; set; }
        public DbSet<Relationships> tbl_rRelationships { get; set; }
        public DbSet<Sections> tbl_rSections { get; set; }
        public DbSet<State> tbl_rStates { get; set; }
        public DbSet<SMTP> tbl_rSMTP { get; set; }
        public DbSet<ADUser> vw_ADSI { get; set; }
        #endregion

        

        #region transaction management
        public IDbContextTransaction BeginTransaction() { return Database.BeginTransaction(); }
        public void CommitTransaction() { Database.CommitTransaction(); }
        public void RollBackTransaction() { Database.RollbackTransaction(); }
        #endregion


        private IHttpContextAccessor httpContextAccessor;

        public eFormsContext(DbContextOptions<eFormsContext> options, IHttpContextAccessor _httpContextAccessor) : base(options)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<eForms.Domain.Models.ADUser>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vw_ADSI");
            });

            eFormsContextSeed.Seed(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            DateTime now = DateTime.UtcNow;

            string user = httpContextAccessor
                .HttpContext?.User?.Claims
                .Where(x => x.Type == "name")
                .FirstOrDefault()
                ?.Value ?? "anonymous";

            //IEnumerable<MonitoredEntity> addedEntities = ChangeTracker.Entries<MonitoredEntity>()
            //   .Where(x => x.State == EntityState.Added)
            //   .Select(x => x.Entity);
            //foreach (MonitoredEntity added in addedEntities)
            //{
            //    added.CreatedDate = now;
            //    added.CreatedBy = user;
            //    added.ModifiedDate = now;
            //    added.ModifiedBy = user;
            //}
            //IEnumerable<MonitoredEntity> modifiedEntities = ChangeTracker.Entries<MonitoredEntity>()
            //   .Where(x => x.State == EntityState.Modified)
            //   .Select(x => x.Entity);
            //foreach (MonitoredEntity modified in modifiedEntities)
            //{
            //    modified.ModifiedDate = now;
            //    modified.ModifiedBy = user;
            //}

            //---- Try to use defaultEntity
            IEnumerable<DefaultModel> addedEntities = ChangeTracker.Entries<DefaultModel>()
               .Where(x => x.State == EntityState.Added)
               .Select(x => x.Entity);
            foreach (DefaultModel added in addedEntities)
            {
                added.CreatedDate = now;
                added.CreatedBy = user;
                added.ModifiedDate = now;
                added.ModifiedBy = user;
            }

            IEnumerable<DefaultModel> modifiedEntities = ChangeTracker.Entries<DefaultModel>()
               .Where(x => x.State == EntityState.Modified)
               .Select(x => x.Entity);

            foreach (DefaultModel modified in modifiedEntities)
            {
                modified.ModifiedDate = now;
                modified.ModifiedBy = user;
            }
            return base.SaveChangesAsync(); ;
        }
    }
}
