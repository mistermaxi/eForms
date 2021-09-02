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
        DbSet<User> tbl_Users { get; set; }
        DbSet<UserRole> tbl_UserRoles { get; set; }
        #endregion

        #region eForms
        DbSet<OpenNetReq> tbl_OpenNetReq { get; set; }
        DbSet<ClassNetReq> tbl_ClassNetReq { get; set; }
        DbSet<DS7642> tbl_DS7642 { get; set; }
        DbSet<DS7642Detail> tbl_DS7642Detail { get; set; }
        DbSet<NewArrvEMP> tbl_NewArrvEMP { get; set; }
        DbSet<NewArrvDEP> tbl_NewArrvDEP { get; set; }
        DbSet<NewArrvEMERG> tbl_NewArrvEMERG { get; set; }
        DbSet<NewArrvLANG> tbl_NewArrvLANG { get; set; }
        DbSet<UploadDoc> tbl_UploadDocs { get; set; }
        

        #endregion

        #region Inventory
        DbSet<Manufacturer> tbl_Manufacturer { get; set; }
        DbSet<MBDevice> tbl_MBDevice { get; set; }
        DbSet<Model> tbl_Model { get; set; }
        DbSet<Sim> tbl_Sim { get; set; }
        DbSet<Transaction> tbl_Transaction { get; set; }
        DbSet<TransactionDetail> tbl_TransactionDetail { get; set; }
        #endregion

        #region settings
        DbSet<BuildingAnnexes> tbl_rBuildingsAnnex { get; set; }
        DbSet<Forms> tbl_rForms { get; set; }
        DbSet<Country> tbl_rCountries { get; set; }
        DbSet<EmployeeType> tbl_rEmployeeTypes { get; set; }
        DbSet<ISO> tbl_rISO { get; set; }
        DbSet<ISSO> tbl_rISSO { get; set; }
        DbSet<IPC> tbl_rIPCs { get; set; }
        DbSet<Languages> tbl_rLanguages { get; set; }
        DbSet<MilitaryRanks> tbl_rMilitaryRanks { get; set; }
        DbSet<Posts> tbl_rPosts { get; set; }
        DbSet<Prefixes> tbl_rPrefixes { get; set; }
        DbSet<Relationships> tbl_rRelationships { get; set; }
        DbSet<Sections> tbl_rSections { get; set; }
        DbSet<State> tbl_rStates { get; set; }
        DbSet<SMTP> tbl_rSMTP { get; set; }
        DbSet<ADUser> vw_ADSI { get; set; }

        #endregion



        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry Entry(object entity);
    }
}
