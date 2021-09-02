using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public interface IUploadService
    {
        Task<int> CountAsync();
        Task<List<UploadDocModel>> GetAllUploads();
        Task<UploadDocModel> ReadAsync(int id);
       
        public Task UpdateUploadAsync(UploadDocModel model);
        Task<List<UploadDocModel>> SearchForUploadsAsync(string search);
        Task DeleteFile(int Id);

        //////////////////////////////////////////

        Task<int> CreateUpload(UploadDocModel model);
        string Upload2Folder(IFormFile files);
    }
}
