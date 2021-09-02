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
    public class SMTPService : ISMTPService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        private IAuthService authService;
        public SMTPService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer, IAuthService _authService)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            authService = _authService;
        }
        private DbSet<SMTP> GetDbSet()
        {
            return context.tbl_rSMTP;
        }
        public async Task<List<SMTPModel>> GetAll()
        {

            List<SMTPModel> dto = mapper.Map<List<SMTP>, List<SMTPModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<SMTP> GetQueryable()
        {
            return context.tbl_rSMTP;
        }
        public async Task<SMTPModel> ReadAsync(int id)
        {
            SMTP model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<SMTPModel>(model);
        }
        public async Task<int> CreateSMTP(SMTPModel model)
        {
            SMTP smtp = mapper.Map<SMTP>(model);
            context.tbl_rSMTP.Add(smtp);
            await context.SaveChangesAsync();
            return smtp.Id;
        }
        public async Task UpdateSMTPAsync(SMTPModel model)
        {
            context.tbl_rSMTP.Update(mapper.Map<SMTP>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<SMTPModel>> SearchForSMTPsAsync(string search)
        {
            List<SMTP> smtps = await context.tbl_rSMTP
                .Where(x => x.Name.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<SMTPModel>>(smtps);
        }
        public async Task DeleteSMTP(int id)
        {
            context.tbl_rSMTP.Remove(new SMTP() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
