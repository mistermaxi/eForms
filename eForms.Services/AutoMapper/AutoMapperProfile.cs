using AutoMapper;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Models;
//using eForms.Services.Models.KeyOfficers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace eForms.Services.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<string, Enum>().ConvertUsing((s, e) => ExtensionsEnum.Parse(e.GetType(), s));
            CreateMap<Enum, string>().ConvertUsing(e => ExtensionsEnum.GetDisplay(e));

            ///////////////////////////////           

            CreateMap<tbl_eForm_User, UsersModel>().ReverseMap();
            CreateMap<tbl_eForm_UserRole, UserRolesModel>().ReverseMap();

            ///////////////////////////////
            //CreateMap<tbl_eFormReqOpenNet, tbl_eFormReqOpenNet>().ReverseMap();
            CreateMap<tbl_eFormUploadDoc, UploadDocModel>().ReverseMap();

            ///////////////////////////////
            CreateMap<tbl_rBuildingAnnex, BuildingAnnexModel>().ReverseMap();
            CreateMap<tbl_rCountry, CountryModel>().ReverseMap();
            CreateMap<tbl_rEmployeeType, EmpTypeModel>().ReverseMap();
            CreateMap<tbl_rForm, FormModel>().ReverseMap();
            CreateMap<tbl_rIPC, IPCModel>().ReverseMap();
            CreateMap<tbl_rISO, ISOModel>().ReverseMap();
            CreateMap<tbl_rISSO, ISSOModel>().ReverseMap();
            CreateMap<tbl_rLanguage, LanguageModel>().ReverseMap();
            CreateMap<tbl_rMilitaryRank, MilitaryRankModel>().ReverseMap();
            CreateMap<tbl_rPost, PostModel>().ReverseMap();
            CreateMap<tbl_rPrefix, PrefixModel>().ReverseMap();
            CreateMap<tbl_rRelationship, RelationshipModel>().ReverseMap();
            CreateMap<tbl_rSection, SectionModel>().ReverseMap();
            CreateMap<tbl_rState, StateModel>().ReverseMap();

            ///////////////////////////////

            //CreateMap<Mission, MissionModel>()
            //    .ReverseMap().ForAllMembers(x => x.Condition((src, tar, mbr) => mbr != null));

            //CreateMap<Post, PostModel>()
            //    .ReverseMap().ForAllMembers(x => x.Condition((src, tar, mbr) => mbr != null));

            //CreateMap<ClientApp, ClientAppModel>()
            //    .ForMember(x => x.DisplayName, opts => opts.MapFrom(x => x.Identity.DisplayName))
            //    .ReverseMap();

            //CreateMap<Contact, ContactModel>().ReverseMap();

            #region DefaultEntity
            //CreateMap<Entity, Entity>()
            //    .ReverseMap()
            //    .ForMember(x => x.Id, opts => opts.Ignore()); // Cannot overwrite Id from ViewModel

            //CreateMap<MonitoredEntity, Entity>()
            //    .IncludeBase<Entity, Entity>()
            //    .ReverseMap()
            //    .ForMember(x => x.CreatedBy, opts => opts.Ignore())     // Cannot overwrite from ViewModel
            //    .ForMember(x => x.CreatedDate, opts => opts.Ignore())   // Cannot overwrite from ViewModel
            //    .ForMember(x => x.ModifiedBy, opts => opts.Ignore())    // Cannot overwrite from ViewModel
            //    .ForMember(x => x.ModifiedDate, opts => opts.Ignore()); // Cannot overwrite from ViewModel
            CreateMap<eForms.Domain.Models.DefaultModel, eForms.Services.Models.DefaultModel>()
                .ReverseMap()
                .ForMember(x => x.Id, opts => opts.Ignore()); // Cannot overwrite Id from ViewModel

            CreateMap<eForms.Domain.Models.DefaultModel, eForms.Services.Models.DefaultModel>()
                .ReverseMap()
                .ForMember(x => x.CreatedBy, opts => opts.Ignore())     // Cannot overwrite from ViewModel
                .ForMember(x => x.CreatedDate, opts => opts.Ignore())   // Cannot overwrite from ViewModel
                .ForMember(x => x.ModifiedBy, opts => opts.Ignore())    // Cannot overwrite from ViewModel
                .ForMember(x => x.ModifiedDate, opts => opts.Ignore()); // Cannot overwrite from ViewModel

            #endregion
        }
    }
}
