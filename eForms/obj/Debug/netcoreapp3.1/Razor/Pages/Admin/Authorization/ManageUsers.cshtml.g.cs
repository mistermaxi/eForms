#pragma checksum "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "785f975b066614e45c39528f44b2766f238860ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(eForms.Pages.Admin.Authorization.Pages_Admin_Authorization_ManageUsers), @"mvc.1.0.razor-page", @"/Pages/Admin/Authorization/ManageUsers.cshtml")]
namespace eForms.Pages.Admin.Authorization
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
#line 1 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\_ViewImports.cshtml"
using eForms;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"785f975b066614e45c39528f44b2766f238860ad", @"/Pages/Admin/Authorization/ManageUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"206d5409da418844a5c62981b9da3e71928474c5", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Authorization_ManageUsers : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "CreateSection", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-brand btn-facebook"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "EditSection", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Are you sure do you want to delete this record?\')"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
  
    ViewData["Title"] = "eForms Application";
    ViewData["breadcrumb1"] = "Admin Module";
    ViewData["breadcrumb2"] = "Users";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container-fluid"">
    <div class=""animated fadeIn"">

        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <i class=""fa fa-align-justify""></i> ");
#nullable restore
#line 15 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
                                                       Write(ViewData["breadcrumb2"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"card-header-actions\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "785f975b066614e45c39528f44b2766f238860ad6788", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"card-body\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "785f975b066614e45c39528f44b2766f238860ad8165", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 23 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
                             if (Model.users.Count() > 0)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <table class=""table table-responsive-sm table-bordered table-striped table-sm"" id=""eformtbl"">
                                    <thead>
                                        <tr>
                                            <th class=""text-center"">Username</th>
                                            <th class=""text-center"">Email Address</th>
                                            <th class=""text-center"">Created Date</th>
                                            <th class=""text-center"">Modified Date</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 36 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
                                         foreach (var item in Model.users)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <tr>\r\n                                                <td>");
#nullable restore
#line 39 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
                                               Write(Html.DisplayFor(m => item.Username));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 40 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
                                               Write(Html.DisplayFor(m => item.EmailAddress));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td class=\"text-center\">");
#nullable restore
#line 41 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
                                                                   Write(Html.DisplayFor(m => item.CreatedDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td class=\"text-center\">");
#nullable restore
#line 42 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
                                                                   Write(Html.DisplayFor(m => item.ModifiedDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td class=\"text-center\">\r\n                                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "785f975b066614e45c39528f44b2766f238860ad11591", async() => {
                    WriteLiteral("Edit");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 44 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
                                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "785f975b066614e45c39528f44b2766f238860ad14033", async() => {
                    WriteLiteral("Del");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
                                                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 49 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </tbody>\r\n                                </table> ");
#nullable restore
#line 52 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
                                         }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <p>No record returns</p>");
#nullable restore
#line 55 "C:\==MX ENT==\01 Projects\OpenNet\eForms.FreeUI\eForms\Pages\Admin\Authorization\ManageUsers.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <!-- /.col-->\r\n        </div>\r\n        <!-- /.row-->\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eForms.Pages.Admin.ManageUsersModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<eForms.Pages.Admin.ManageUsersModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<eForms.Pages.Admin.ManageUsersModel>)PageContext?.ViewData;
        public eForms.Pages.Admin.ManageUsersModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
