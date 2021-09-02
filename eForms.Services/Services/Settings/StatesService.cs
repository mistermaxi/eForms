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
    public class StatesService : IStatesService
    {
        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public StatesService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<State> GetDbSet()
        {
            return context.tbl_rStates;
        }

        public async Task<List<StateModel>> GetAllStates()
        {

            List<StateModel> dto = mapper.Map<List<State>, List<StateModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<State> GetQueryable()
        {
            return context.tbl_rStates;
        }
        public async Task<StateModel> ReadAsync(int id)
        {
            State model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<StateModel>(model);
        }
        public async Task<int> CreateState(StateModel model)
        {
            State state = mapper.Map<State>(model);
            context.tbl_rStates.Add(state);
            await context.SaveChangesAsync();
            return state.Id;
        }
        public async Task UpdateStateAsync(StateModel model)
        {
            context.tbl_rStates.Update(mapper.Map<State>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<StateModel>> SearchForStatesAsync(string search)
        {
            List<State> states = await context.tbl_rStates
                .Where(x => x.StateName.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<StateModel>>(states);
        }
        public async Task DeleteState(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageMilRank, id);
            context.tbl_rStates.Remove(new State() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
