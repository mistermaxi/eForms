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
        public DbSet<tbl_eForm_User> tbl_eForm_Users { get; set; }
        public DbSet<tbl_eForm_UserRole> tbl_eForm_UserRoles { get; set; }
        #endregion

        #region eForms
        public DbSet<tbl_eFormReqOpenNet> tbl_eFormReqOpenNet { get; set; }
        public DbSet<tbl_eFormReqClassNet> tbl_eFormReqClassNet { get; set; }
        public DbSet<tbl_eFormNewArrvEMP> tbl_eFormNewArrvEMP { get; set; }
        public DbSet<tbl_eFormUploadDoc> tbl_eFormUploadDocs { get; set; }

        #endregion

        #region settings
        public DbSet<tbl_rBuildingAnnex> tbl_rBuildingsAnnex { get; set; }
        public DbSet<tbl_rForm> tbl_rForms { get; set; }
        public DbSet<tbl_rCountry> tbl_rCountries { get; set; }
        public DbSet<tbl_rEmployeeType> tbl_rEmployeeTypes { get; set; }
        public DbSet<tbl_rISO> tbl_rISO { get; set; }
        public DbSet<tbl_rISSO> tbl_rISSO { get; set; }
        public DbSet<tbl_rIPC> tbl_rIPCs { get; set; }
        public DbSet<tbl_rLanguage> tbl_rLanguages { get; set; }
        public DbSet<tbl_rMilitaryRank> tbl_rMilitaryRanks { get; set; }
        public DbSet<tbl_rPost> tbl_rPosts { get; set; }
        public DbSet<tbl_rPrefix> tbl_rPrefixes { get; set; }
        public DbSet<tbl_rRelationship> tbl_rRelationships { get; set; }
        public DbSet<tbl_rSection> tbl_rSections { get; set; }
        public DbSet<tbl_rState> tbl_rStates { get; set; }
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
