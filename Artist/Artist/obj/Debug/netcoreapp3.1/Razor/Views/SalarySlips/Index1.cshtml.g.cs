#pragma checksum "C:\Users\user\source\repos\Artist\Artist\Views\SalarySlips\Index1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d95fa20a3bd70ffe65305eef0323d16c3f4abc3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SalarySlips_Index1), @"mvc.1.0.view", @"/Views/SalarySlips/Index1.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d95fa20a3bd70ffe65305eef0323d16c3f4abc3", @"/Views/SalarySlips/Index1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3477f256996594b7730369f85f52d8c17a130a58", @"/Views/_ViewImports.cshtml")]
    public class Views_SalarySlips_Index1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Artist.Models.SalarySlip>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\user\source\repos\Artist\Artist\Views\SalarySlips\Index1.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/Employee.cshtml";
    int rowNo1 = 0;

    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""content mt-3"">
    <div class=""animated fadeIn"">
        <div class=""row  align-items-center justify-content-center"">

            <div class=""col-md-8"">
                <div class=""card"">
                    <div class=""card-header"">
                        <strong class=""card-title"">Salary Slips Table</strong>
                    </div>
                    <div class=""card-body"">
                        <table class=""table table-striped table-bordered"">
                            <thead>
                                <tr>
                                    <td>#</td>
                                    <th>Slip Date</th>
                                    <th>Link</th>
                                   

                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 32 "C:\Users\user\source\repos\Artist\Artist\Views\SalarySlips\Index1.cshtml"
                                 foreach (var item in Model)
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n\r\n                                    <td>\r\n                                      ");
#nullable restore
#line 38 "C:\Users\user\source\repos\Artist\Artist\Views\SalarySlips\Index1.cshtml"
                                  Write(rowNo1 += 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 41 "C:\Users\user\source\repos\Artist\Artist\Views\SalarySlips\Index1.cshtml"
                                   Write(item.SlipDate.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n\r\n                                    <td>");
#nullable restore
#line 44 "C:\Users\user\source\repos\Artist\Artist\Views\SalarySlips\Index1.cshtml"
                                   Write(Html.ActionLink("Download", "Download", new { SlipFile = item.FileName }, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n                                </tr>\r\n");
#nullable restore
#line 48 "C:\Users\user\source\repos\Artist\Artist\Views\SalarySlips\Index1.cshtml"


                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n\r\n        </div>\r\n    </div><!-- .animated -->\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Artist.Models.SalarySlip>> Html { get; private set; }
    }
}
#pragma warning restore 1591
