#pragma checksum "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7b03a6786802ce1c8515e24aed9d8c0fe2225ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Carts_Delivered), @"mvc.1.0.view", @"/Views/Carts/Delivered.cshtml")]
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
#line 1 "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml"
using X.PagedList.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7b03a6786802ce1c8515e24aed9d8c0fe2225ff", @"/Views/Carts/Delivered.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3477f256996594b7730369f85f52d8c17a130a58", @"/Views/_ViewImports.cshtml")]
    public class Views_Carts_Delivered : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<Artist.Models.Cart>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml"
  
    ViewData["Title"] = "Delivered";
    Layout = "~/Views/Shared/Admin2.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"



<div class=""breadcrumbs"">
    <div class=""col-sm-4"">
        <div class=""page-header float-left"">
            <div class=""page-title"">
                <h1>Carts</h1>
            </div>
        </div>
    </div>
    <div class=""col-sm-8"">
        <div class=""page-header float-right"">
            <div class=""page-title"">
                <ol class=""breadcrumb text-right"">
                    <li class=""active"">Delivered</li>
                </ol>
            </div>
        </div>
    </div>
</div>
<div class=""content mt-3"">


    <div class=""row"">
");
#nullable restore
#line 36 "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""col-md-4"">
                <aside class=""profile-nav alt"">
                    <section class=""card"">
                        <div class=""card-header user-header alt bg-dark"">
                            <div class=""media"">
                                <div class=""media-body"">
                                    <h2 class=""text-light display-6"">");
#nullable restore
#line 44 "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml"
                                                                Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                                </div>
                            </div>
                        </div>


                        <ul class=""list-group list-group-flush"">
                            <li class=""list-group-item"">
                                <strong>Location:</strong> ");
#nullable restore
#line 52 "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml"
                                                      Write(item.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </li>\r\n                            <li class=\"list-group-item\">\r\n                                <strong>Number:</strong> ");
#nullable restore
#line 55 "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml"
                                                    Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </li>\r\n                            <li class=\"list-group-item\">\r\n                                <strong>Total orders:</strong> ");
#nullable restore
#line 58 "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml"
                                                          Write(item.TotalOrders);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </li>\r\n                            <li class=\"list-group-item\">\r\n                                <strong>Total price:</strong> &euro; ");
#nullable restore
#line 61 "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml"
                                                                Write(item.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </li>\r\n                           \r\n                            <li class=\"list-group-item\">\r\n                                <span>Status:</span>");
#nullable restore
#line 65 "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml"
                                               Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </li>\r\n\r\n\r\n\r\n                        </ul>\r\n\r\n                    </section>\r\n                </aside>\r\n            </div>\r\n");
#nullable restore
#line 75 "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"row align-items-center justify-content-center mt-2\">\r\n        <ul id=\"pageListul\" style=\"list-style:none;\">\r\n            <li id=\"pageListLI\">\r\n                ");
#nullable restore
#line 80 "C:\Users\user\source\repos\Artist\Artist\Views\Carts\Delivered.cshtml"
           Write(Html.PagedListPager(Model, page => Url.Action("Delivered", new { page })));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </li>\r\n        </ul>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<Artist.Models.Cart>> Html { get; private set; }
    }
}
#pragma warning restore 1591
