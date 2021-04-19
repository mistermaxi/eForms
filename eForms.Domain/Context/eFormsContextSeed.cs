using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Domain.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace eForms.Domain.Context
{
    public class eFormsContextSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedFakeDataCommon(modelBuilder);

            
        }

        #region SeedFakeDataCommon
        public static void SeedFakeDataCommon(ModelBuilder modelBuilder)
        {
            //#region adminconfiguration
            //modelBuilder.Entity<AdminConfiguration>().HasData(
            //  new AdminConfiguration()
            //  {
            //      Name = "General Management",
            //      Id = 1
            //  },
            //  new AdminConfiguration()
            //  {
            //      Name = "Individual Management",
            //      Id = 2
            //  }
            //);
            //#endregion
        }
        #endregion



    }
}
