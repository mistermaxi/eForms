using eForms.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eForms.Domain.Context
{
    public interface IeFormsContext : IDisposable
    {
        #region Authorization
        DbSet<tbl_eForm_User> tbl_eForm_Users { get; set; }
        DbSet<tbl_eForm_UserRole> tbl_eForm_UserRoles { get; set; }
        #endregion

        #region eForms
        DbSet<tbl_eFormReqOpenNet> tbl_eFormReqOpenNet { get; set; }
        DbSet<tbl_eFormReqClassNet> tbl_eFormReqClassNet { get; set; }
        DbSet<tbl_eFormNewArrvEMP> tbl_eFormNewArrvEMP { get; set; }
        DbSet<tbl_eFormUploadDoc> tbl_eFormUploadDocs { get; set; }

        #endregion

        #region settings
        DbSet<tbl_rBuildingAnnex> tbl_rBuildingsAnnex { get; set; }
        DbSet<tbl_rForm> tbl_rForms { get; set; }
        DbSet<tbl_rCountry> tbl_rCountries { get; set; }
        DbSet<tbl_rEmployeeType> tbl_rEmployeeTypes { get; set; }
        DbSet<tbl_rISO> tbl_rISO { get; set; }
        DbSet<tbl_rISSO> tbl_rISSO { get; set; }
        DbSet<tbl_rIPC> tbl_rIPCs { get; set; }
        DbSet<tbl_rLanguage> tbl_rLanguages { get; set; }
        DbSet<tbl_rMilitaryRank> tbl_rMilitaryRanks { get; set; }
        DbSet<tbl_rPost> tbl_rPosts { get; set; }
        DbSet<tbl_rPrefix> tbl_rPrefixes { get; set; }
        DbSet<tbl_rRelationship> tbl_rRelationships { get; set; }
        DbSet<tbl_rSection> tbl_rSections { get; set; }
        DbSet<tbl_rState> tbl_rStates { get; set; }
        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry Entry(object entity);
    }
}
