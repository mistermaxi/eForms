using AutoMapper;
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

namespace eForms.Services.Interfaces
{
    public class RelationshipService : IRelationshipService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public RelationshipService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<Relationships> GetDbSet()
        {
            return context.tbl_rRelationships;
        }

        public async Task<List<RelationshipModel>> GetAllRelationship()
        {

            List<RelationshipModel> dto = mapper.Map<List<Relationships>, List<RelationshipModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<Relationships> GetQueryable()
        {
            return context.tbl_rRelationships;
        }
        public async Task<RelationshipModel> ReadAsync(int id)
        {
            Relationships model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<RelationshipModel>(model);
        }
        public async Task<int> CreateRelationship(RelationshipModel model)
        {
            Relationships relationship = mapper.Map<Relationships>(model);
            context.tbl_rRelationships.Add(relationship);
            await context.SaveChangesAsync();
            return relationship.Id;
        }
        public async Task UpdateRelationshipAsync(RelationshipModel model)
        {
            context.tbl_rRelationships.Update(mapper.Map<Relationships>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<RelationshipModel>> SearchForRelationshipAsync(string search)
        {
            List<Relationships> relationships = await context.tbl_rRelationships
                .Where(x => x.Relationship.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<RelationshipModel>>(relationships);
        }
        public async Task DeleteRelationship(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageMilRank, id);
            context.tbl_rRelationships.Remove(new Relationships() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
