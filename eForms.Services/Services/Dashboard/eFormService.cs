using AutoMapper;
using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public class eFormService : IeFormService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        private IAuthService authService;
        public eFormService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer, IAuthService _authService)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            authService = _authService;
        }
        private DbSet<OpenNetReq> GetOpenNetReqDbSet()
        {
            return context.tbl_OpenNetReq;
        }
        public async Task<List<eFormModel>> GetAlleForm()
        {
            List<eFormModel> dto = await context.tbl_OpenNetReq
                        .Select(x => new 
                        { 
                            Id = x.Id, 
                            FirstName = x.FirstName 
                        })
                        
                        .Union(context.tbl_ClassNetReq
                        .Select(x => new 
                        { 
                            Id = x.Id, 
                            FirstName = x.FirstName 
                        }))
                        
                        .Union(context.tbl_DS7642
                        .Select(x => new 
                        { 
                            Id = x.Id, 
                            FirstName = x.FirstName 
                        }))

                        .Select(m => new eFormModel
                        { 
                            Id = m.Id,
                            FirstName = m.FirstName
                        })
                        .ToListAsync();

            return dto;
        }
    }
}
