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

            CreateMap<User, UsersModel>().ReverseMap();
            CreateMap<UserRole, UserRolesModel>().ReverseMap();
            CreateMap<ADUser, ADUserModel>().ReverseMap();

            ///////////////////////////////
            CreateMap<OpenNetReq, OpenNetModel>().ReverseMap();
            CreateMap<ClassNetReq, ClassNetModel>().ReverseMap();
            CreateMap<DS7642, DS7642Model>().ReverseMap();
            CreateMap<DS7642Detail, DS7642DetailModel>().ReverseMap();
            CreateMap<NewArrvEMP, NewArrvEMPModel>().ReverseMap();
            CreateMap<NewArrvDEP, NewArrvDEPModel>().ReverseMap();
            CreateMap<NewArrvEMERG, NewArrvEMERGModel>().ReverseMap();
            CreateMap<NewArrvLANG, NewArrvLANGModel>().ReverseMap();
            CreateMap<UploadDoc, UploadDocModel>().ReverseMap();

            ///////////////////////////////
            CreateMap<Manufacturer, ManufacturerModel>().ReverseMap();
            CreateMap<MBDevice, MBDeviceModel>().ReverseMap();
            CreateMap<Model, ModelModel>().ReverseMap();
            CreateMap<Sim, SimModel>().ReverseMap();
            CreateMap<Transaction, TransactionModel>().ReverseMap();
            CreateMap<TransactionDetail, TransactionDetailModel>().ReverseMap();

            ///////////////////////////////
            CreateMap<BuildingAnnexes, BuildingAnnexModel>().ReverseMap();
            CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<EmployeeType, EmpTypeModel>().ReverseMap();
            CreateMap<Forms, FormModel>().ReverseMap();
            CreateMap<IPC, IPCModel>().ReverseMap();
            CreateMap<ISO, ISOModel>().ReverseMap();
            CreateMap<ISSO, ISSOModel>().ReverseMap();
            CreateMap<Languages, LanguageModel>().ReverseMap();
            CreateMap<MilitaryRanks, MilitaryRankModel>().ReverseMap();
            CreateMap<Posts, PostModel>().ReverseMap();
            CreateMap<Prefixes, PrefixModel>().ReverseMap();
            CreateMap<Relationships, RelationshipModel>().ReverseMap();
            CreateMap<Sections, SectionModel>().ReverseMap();
            CreateMap<SMTP, SMTPModel>().ReverseMap();
            CreateMap<State, StateModel>().ReverseMap();

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
