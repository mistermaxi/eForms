using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public interface ISMTPService
    {
        Task<int> CountAsync();
        Task<List<SMTPModel>> GetAll();
        Task<SMTPModel> ReadAsync(int id);
        Task<int> CreateSMTP(SMTPModel model);
        public Task UpdateSMTPAsync(SMTPModel model);
        Task<List<SMTPModel>> SearchForSMTPsAsync(string search);
        Task DeleteSMTP(int Id);
    }
}
