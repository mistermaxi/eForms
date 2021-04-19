﻿using AutoMapper;
using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Services
{
    public class PrefixService : IPrefixService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public PrefixService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<tbl_rPrefix> GetDbSet()
        {
            return context.tbl_rPrefixes;
        }

        public async Task<List<PrefixModel>> GetAllPrefixes()
        {

            List<PrefixModel> dto = mapper.Map<List<tbl_rPrefix>, List<PrefixModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<tbl_rPrefix> GetQueryable()
        {
            return context.tbl_rPrefixes;
        }
        public async Task<PrefixModel> ReadAsync(int id)
        {
            tbl_rPrefix model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<PrefixModel>(model);
        }
        public async Task<int> CreatePrefix(PrefixModel model)
        {
            tbl_rPrefix prefix = mapper.Map<tbl_rPrefix>(model);
            context.tbl_rPrefixes.Add(prefix);
            await context.SaveChangesAsync();
            return prefix.Id;
        }
        public async Task UpdatePrefixAsync(PrefixModel model)
        {
            context.tbl_rPrefixes.Update(mapper.Map<tbl_rPrefix>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<PrefixModel>> SearchForPrefixesAsync(string search)
        {
            List<tbl_rPrefix> prefixes = await context.tbl_rPrefixes
                .Where(x => x.PrefixTitle.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<PrefixModel>>(prefixes);
        }
        public async Task DeletePrefix(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageMilRank, id);
            context.tbl_rPrefixes.Remove(new tbl_rPrefix() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
