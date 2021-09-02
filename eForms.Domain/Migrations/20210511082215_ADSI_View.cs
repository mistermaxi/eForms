using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eForms.Domain.Migrations
{
    public partial class ADSI_View : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
            CREATE OR ALTER VIEW [dbo].[vw_ADSI] AS
                SELECT * FROM [ADSI].[dbo].[tbl_AD_BKK_CHM_FSC] ";
            
            migrationBuilder.Sql(sql);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW vw_ADSI");


        }
    }
}
