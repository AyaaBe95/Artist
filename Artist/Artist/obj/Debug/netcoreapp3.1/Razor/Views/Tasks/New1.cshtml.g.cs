#pragma checksum "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f26b84da0451726d95b8770519299f8fc8162cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tasks_New1), @"mvc.1.0.view", @"/Views/Tasks/New1.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\user\source\repos\Artist\Artist\Views\_ViewImports.cshtml"
using Artist;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\Artist\Artist\Views\_ViewImports.cshtml"
using Artist.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml"
using X.PagedList.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f26b84da0451726d95b8770519299f8fc8162cd", @"/Views/Tasks/New1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3477f256996594b7730369f85f52d8c17a130a58", @"/Views/_ViewImports.cshtml")]
    public class Views_Tasks_New1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<Artist.Models.Tasks>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Solve", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/Employee.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""breadcrumbs"">
    <div class=""col-sm-4"">
        <div class=""page-header float-left"">
            <div class=""page-title"">
                <h1>Tasks</h1>
            </div>
        </div>
    </div>
    <div class=""col-sm-8"">
        <div class=""page-header float-right"">
            <div class=""page-title"">
                <ol class=""breadcrumb text-right"">
                    <li class=""active"">New</li>
                </ol>
            </div>
        </div>
    </div>
</div>

<div class=""content mt-3"">

    <div class=""row "">
");
#nullable restore
#line 33 "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""col-lg-4 col-md col-sm col-xs"">
                <div class=""row align-items-center justify-content-center "">

                    <section class=""card con "" style=""width:220px"">
                        <div class=""card-header user-header alt bg-dark"">
                            <div class=""media"">

                                <div class=""media-body"">
                                    <h2 class=""text-light display-6""> ");
#nullable restore
#line 43 "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml"
                                                                 Write(Html.DisplayFor(model => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                                </div>
                            </div>
                        </div>


                        <ul class=""list-group list-group-flush"">
                            <li class=""list-group-item"">
                                <div class=""row align-items-center justify-content-center"">
                                    <strong>Employee Name:</strong>
                                </div>
                                <div class=""row align-items-center justify-content-center"">
                                    ");
#nullable restore
#line 55 "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml"
                               Write(Html.DisplayFor(model => item.User.fullname));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                </div>
                            </li>
                            <li class=""list-group-item"">
                                <div class=""row align-items-center justify-content-center"">
                                    <strong>Start Date:</strong>
                                </div>
                                <div class=""row align-items-center justify-content-center"">
                                    ");
#nullable restore
#line 64 "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml"
                               Write(item.StartDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                </div>
                            </li>
                            <li class=""list-group-item"">
                                <div class=""row align-items-center justify-content-center"">
                                    <strong>End Date:</strong>
                                </div>
                                <div class=""row align-items-center justify-content-center"">
                                    ");
#nullable restore
#line 73 "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml"
                               Write(item.EndDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                </div>
                            </li>


                            <li class=""list-group-item"">
                                <div class=""row align-items-center justify-content-center"">
                                    <strong>Description:</strong>
                                </div>
                                <div class=""row align-items-center justify-content-center"">
                                    ");
#nullable restore
#line 84 "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml"
                               Write(Html.DisplayFor(model => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                </div>
                                <div class=""card-footer"" style=""width:220px"">
                                    <div class=""row align-items-center justify-content-center"">

                                        <div class=""col"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f26b84da0451726d95b8770519299f8fc8162cd9051", async() => {
                WriteLiteral("\r\n\r\n                                                ");
#nullable restore
#line 93 "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml"
                                           Write(Html.Hidden("id", @item.TaskId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                <button type=\"submit\" class=\"btn btn-dark\" value=\"Solve\">Solve</button>\r\n                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        </div>
                                    </div>
                                </div>
                            </li>


                        </ul>


                    </section>
                </div>
            </div>
");
#nullable restore
#line 108 "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <div class=\"row align-items-center justify-content-center mt-2\">\r\n        <ul id=\"pageListul\" style=\"list-style:none;\">\r\n            <li id=\"pageListLI\">\r\n                ");
#nullable restore
#line 114 "C:\Users\user\source\repos\Artist\Artist\Views\Tasks\New1.cshtml"
           Write(Html.PagedListPager(Model, page => Url.Action("New1", new { page })));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </li>\r\n        </ul>\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<Artist.Models.Tasks>> Html { get; private set; }
    }
}
#pragma warning restore 1591
