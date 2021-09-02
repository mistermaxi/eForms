using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public interface IEncryptDecryptService
    {
        public string EncryptData(string text);
        public string DecryptData(string text);
        public string Encrypt(string text);
        public string Decrypt(string cipherText);
        public string EncryptString(string text);
        public string DecryptString(string text);
    }
}
