#pragma checksum "C:\Temp\01-Projects\Web Apps\ASP.NET Core\eForms\eForms\eForms\Pages\Admin\Inventory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2695f74f5292c872dc599dceec226110d7fd2787"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(eForms.Pages.Admin.Inventory.Pages_Admin_Inventory_Index), @"mvc.1.0.razor-page", @"/Pages/Admin/Inventory/Index.cshtml")]
namespace eForms.Pages.Admin.Inventory
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Temp\01-Projects\Web Apps\ASP.NET Core\eForms\eForms\eForms\Pages\_ViewImports.cshtml"
using eForms;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2695f74f5292c872dc599dceec226110d7fd2787", @"/Pages/Admin/Inventory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"206d5409da418844a5c62981b9da3e71928474c5", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Inventory_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Temp\01-Projects\Web Apps\ASP.NET Core\eForms\eForms\eForms\Pages\Admin\Inventory\Index.cshtml"
   ViewData["Title"] = "eForms Application";
    ViewData["breadcrumb1"] = "Admin";
    ViewData["breadcrumb2"] = "Inventory"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container-fluid\">\n    <div class=\"animated fadeIn\">\n        <div class=\"row\">\n            <div class=\"col-sm-6 col-lg-3\">\n                <h2>Inventory</h2>\n            </div>\n        </div>\n    </div>\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eForms.Pages.Admin.Inventory.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<eForms.Pages.Admin.Inventory.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<eForms.Pages.Admin.Inventory.IndexModel>)PageContext?.ViewData;
        public eForms.Pages.Admin.Inventory.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
