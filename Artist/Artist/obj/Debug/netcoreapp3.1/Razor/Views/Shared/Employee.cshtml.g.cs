#pragma checksum "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73200a74b0041beb3e7667f36fafc986644aa6b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Employee), @"mvc.1.0.view", @"/Views/Shared/Employee.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73200a74b0041beb3e7667f36fafc986644aa6b3", @"/Views/Shared/Employee.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3477f256996594b7730369f85f52d8c17a130a58", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Employee : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!doctype html>\n\n<html class=\"no-js\" lang=\"en\">\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73200a74b0041beb3e7667f36fafc986644aa6b34021", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">

    <link rel=""apple-touch-icon"" href=""apple-icon.png"">
    <link rel=""shortcut icon"" href=""favicon.ico"">
    <title>Fine Arts</title>

    <link href=""//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css"" rel=""stylesheet"" id=""bootstrap-css"">
    <script src=""//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js""></script>
    <script src=""//code.jquery.com/jquery-1.11.1.min.js""></script>
    <link rel=""stylesheet""");
                BeginWriteAttribute("href", " href=", 652, "", 741, 1);
#nullable restore
#line 17 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 658, Url.Content("/MyStaticFiles/Admin/a/vendors/bootstrap/dist/css/bootstrap.min.css"), 658, 83, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 769, "", 833, 1);
#nullable restore
#line 18 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 775, Url.Content("/MyStaticFiles/Admin/addEmployee/style.css"), 775, 58, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 861, "", 918, 1);
#nullable restore
#line 19 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 867, Url.Content("/MyStaticFiles/Admin/a/css/card.css"), 867, 51, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 946, "", 1007, 1);
#nullable restore
#line 20 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 952, Url.Content("/MyStaticFiles/Admin/a/css/portfile.css"), 952, 55, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 1036, "", 1094, 1);
#nullable restore
#line 22 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 1042, Url.Content("/MyStaticFiles/Admin/a/css/formm.css"), 1042, 52, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 1122, "", 1179, 1);
#nullable restore
#line 23 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 1128, Url.Content("/MyStaticFiles/Admin/a/css/cart.css"), 1128, 51, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 1208, "", 1301, 1);
#nullable restore
#line 25 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 1214, Url.Content("/MyStaticFiles/Admin/a/vendors/owl.carousel/assets/owl.carousel.min.css"), 1214, 87, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n\n\n    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\">\n\n\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 1451, "", 1541, 1);
#nullable restore
#line 31 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 1457, Url.Content("/MyStaticFiles/Admin/a/vendors/font-awesome/css/font-awesome.min.css"), 1457, 84, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 1569, "", 1657, 1);
#nullable restore
#line 32 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 1575, Url.Content("/MyStaticFiles/Admin/a/vendors/themify-icons/css/themify-icons.css"), 1575, 82, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 1685, "", 1773, 1);
#nullable restore
#line 33 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 1691, Url.Content("/MyStaticFiles/Admin/a/vendors/flag-icon-css/css/flag-icon.min.css"), 1691, 82, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 1801, "", 1886, 1);
#nullable restore
#line 34 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 1807, Url.Content("/MyStaticFiles/Admin/a/vendors/selectFX/css/cs-skin-elastic.css"), 1807, 79, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 1914, "", 1993, 1);
#nullable restore
#line 35 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 1920, Url.Content("/MyStaticFiles/Admin/a/vendors/jqvmap/dist/jqvmap.min.css"), 1920, 73, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 2021, "", 2100, 1);
#nullable restore
#line 36 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 2027, Url.Content("/MyStaticFiles/Admin/a/css/data-table/bootstrap-table.css"), 2027, 73, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 2128, "", 2210, 1);
#nullable restore
#line 37 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 2134, Url.Content("/MyStaticFiles/Admin/a/css/data-table/bootstrap-editable.css"), 2134, 76, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n\n\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=", 2240, "", 2297, 1);
#nullable restore
#line 40 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 2246, Url.Content("/MyStaticFiles/Admin/a/css/dash.css"), 2246, 51, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n\n    <link href=\'https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800\' rel=\'stylesheet\' type=\'text/css\'>\n\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73200a74b0041beb3e7667f36fafc986644aa6b312572", async() => {
                WriteLiteral(@"


    <!-- Left Panel -->

    <aside id=""left-panel"" class=""left-panel"">
        <nav class=""navbar navbar-expand-sm navbar-default"">

            <div class=""navbar-header"">
                <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#main-menu"" aria-controls=""main-menu"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                    <i class=""fa fa-bars""></i>
                </button>
                <a class=""navbar-brand""><img src=""images/logo.png""");
                BeginWriteAttribute("alt", " alt=\"", 2938, "\"", 2944, 0);
                EndWriteAttribute();
                WriteLiteral("></a>\n                <a class=\"navbar-brand hidden\"><img src=\"images/logo2.png\"");
                BeginWriteAttribute("alt", " alt=\"", 3025, "\"", 3031, 0);
                EndWriteAttribute();
                WriteLiteral("></a>\n            </div>\n\n            <div id=\"main-menu\" class=\"main-menu collapse navbar-collapse\">\n                <ul class=\"nav navbar-nav\">\n                    <li class=\"active\">\n                        <a");
                BeginWriteAttribute("href", " href=\"", 3244, "\"", 3299, 1);
#nullable restore
#line 65 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 3251, Url.Action("EmployeeDashboard", "EmployeeDash"), 3251, 48, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> <i class=\"menu-icon fa fa-dashboard\"></i>Dashboard </a>\n                    </li>\n                    <h3 class=\"menu-title\">Work</h3><!-- /.menu-title -->\n                    <li>\n                        <a");
                BeginWriteAttribute("href", " href=\"", 3509, "\"", 3560, 1);
#nullable restore
#line 69 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 3516, Url.Action("UserAttendance", "Attendances"), 3516, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"> <i class=""menu-icon fa fa-user""></i>My Attendance</a>
                    </li>
                    <li class=""menu-item-has-children dropdown"">
                        <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""> <i class=""menu-icon fa fa-tasks""></i>My Tasks</a>
                        <ul class=""sub-menu children dropdown-menu"">
                            <li><i class=""menu-icon fa fa-info""></i><a");
                BeginWriteAttribute("href", " href=\"", 4024, "\"", 4059, 1);
#nullable restore
#line 74 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 4031, Url.Action("New1", "Tasks"), 4031, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">New Tasks</a></li>\n\n                            <li><i class=\"menu-icon fa fa-check-circle-o\"></i><a");
                BeginWriteAttribute("href", " href=\"", 4161, "\"", 4199, 1);
#nullable restore
#line 76 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 4168, Url.Action("Solved1", "Tasks"), 4168, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Solved Tasks</a></li>\n\n\n                        </ul>\n                    </li>\n                    <li>\n                        <a");
                BeginWriteAttribute("href", " href=\"", 4332, "\"", 4375, 1);
#nullable restore
#line 82 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 4339, Url.Action("Index1", "SalarySlips"), 4339, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"> <i class=""menu-icon fa fa-download""></i>Salary Slips</a>
                    </li>


                    <h3 class=""menu-title"">Pages</h3><!-- /.menu-title -->

                    <li class=""menu-item-has-children dropdown"">
                        <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""> <i class=""menu-icon fa fa-glass""></i>Pages</a>
                        <ul class=""sub-menu children dropdown-menu"">
                            <li><i class=""menu-icon fa fa-sign-in""></i><a");
                BeginWriteAttribute("href", " href=\"", 4920, "\"", 4954, 1);
#nullable restore
#line 91 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 4927, Url.Action("Home", "Home"), 4927, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Home</a></li>\n                            <li><i class=\"menu-icon fa fa-sign-in\"></i><a");
                BeginWriteAttribute("href", " href=\"", 5043, "\"", 5080, 1);
#nullable restore
#line 92 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 5050, Url.Action("Gallery", "Home"), 5050, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Gallery</a></li>\n                        </ul>\n                    </li>\n\n                    <li>\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73200a74b0041beb3e7667f36fafc986644aa6b318418", async() => {
                    WriteLiteral(" <i class=\"menu-icon fa fa-power-off\"></i> Logout");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </li>




                </ul>
            </div><!-- /.navbar-collapse -->
        </nav>
    </aside><!-- /#left-panel -->
    <!-- Left Panel -->
    <!-- Right Panel -->

    <div id=""right-panel"" class=""right-panel"">

        <!-- Header-->
        <header id=""header"" class=""header"">

            <div class=""header-menu"">

                <div class=""col-sm-7"">


                    <a id=""menuToggle"" class=""menutoggle pull-left""><i class=""fa fa fa-tasks""></i></a>
                    <div class=""header-left"">


                        <div class=""col-sm-4"">
                            <div class=""page-header "">
                                <div class=""page-title"">
                                    <a class=""nav-link""");
                BeginWriteAttribute("href", " href=\"", 6039, "\"", 6073, 1);
#nullable restore
#line 127 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 6046, Url.Action("Home", "Home"), 6046, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Home</a>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""page-header "">
                                <div class=""page-title"">
                                    <a class=""nav-link""");
                BeginWriteAttribute("href", " href=\"", 6403, "\"", 6440, 1);
#nullable restore
#line 134 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 6410, Url.Action("Gallery", "Home"), 6410, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Gallery</a>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div class=""col-sm-5"">
                    <div class=""user-area dropdown float-right"">
                        <a href=""#"" class=""dropdown-toggle fa fa-user"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                        </a>
                        <div class=""user-menu dropdown-menu"">
                            <a class=""nav-link""");
                BeginWriteAttribute("href", " href=\"", 6991, "\"", 7046, 1);
#nullable restore
#line 147 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 6998, Url.Action("EmployeeDashboard", "EmployeeDash"), 6998, 48, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("><i class=\"fa fa-user\"></i> My Profile</a>\n                            <a class=\"nav-link\"");
                BeginWriteAttribute("href", " href=\"", 7137, "\"", 7188, 1);
#nullable restore
#line 148 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 7144, Url.Action("UserAttendance", "Attendances"), 7144, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("><i class=\"fa fa-info\"></i> My Attendance</a>\n                            <a class=\"nav-link\"");
                BeginWriteAttribute("href", " href=\"", 7282, "\"", 7317, 1);
#nullable restore
#line 149 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 7289, Url.Action("New1", "Tasks"), 7289, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("><i class=\"fa fa-info\"></i> My Tasks</a>\n\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73200a74b0041beb3e7667f36fafc986644aa6b323587", async() => {
                    WriteLiteral("<i class=\"fa fa-power-off\"></i> Logout");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        </div>\n                    </div>\n\n\n\n                </div>\n            </div>\n\n        </header><!-- /header -->\n        <!-- Header-->\n\n\n\n        <div class=\"content mt-3\">\n\n            ");
#nullable restore
#line 167 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n\n\n        </div> <!-- .content -->\n    </div><!-- /#right-panel -->\n    <!-- Right Panel -->\n\n    <script");
                BeginWriteAttribute("src", " src=", 7803, "", 7880, 1);
#nullable restore
#line 175 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 7808, Url.Content("/MyStaticFiles/Admin/a/vendors/jquery/dist/jquery.min.js"), 7808, 72, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 7902, "", 7965, 1);
#nullable restore
#line 176 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 7907, Url.Content("/MyStaticFiles/Admin/addEmployee/script.js"), 7907, 58, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n\n    <script");
                BeginWriteAttribute("src", " src=", 7988, "", 8072, 1);
#nullable restore
#line 178 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 7993, Url.Content("/MyStaticFiles/Admin/a/vendors/popper.js/dist/umd/popper.min.js"), 7993, 79, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 8094, "", 8180, 1);
#nullable restore
#line 179 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 8099, Url.Content("/MyStaticFiles/Admin/a/vendors/bootstrap/dist/js/bootstrap.min.js"), 8099, 81, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 8202, "", 8256, 1);
#nullable restore
#line 180 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 8207, Url.Content("/MyStaticFiles/Admin/a/js/main.js"), 8207, 49, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script src=\"https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js\"></script>\n    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js\"></script>\n    <script");
                BeginWriteAttribute("src", " src=", 8478, "", 8554, 1);
#nullable restore
#line 183 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 8483, Url.Content("/MyStaticFiles/Admin/a/js/data-table/bootstrap-table.js"), 8483, 71, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 8576, "", 8648, 1);
#nullable restore
#line 184 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 8581, Url.Content("/MyStaticFiles/Admin/a/js/data-table/tableExport.js"), 8581, 67, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 8670, "", 8748, 1);
#nullable restore
#line 185 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 8675, Url.Content("/MyStaticFiles/Admin/a/js/data-table/data-table-active.js"), 8675, 73, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 8770, "", 8855, 1);
#nullable restore
#line 186 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 8775, Url.Content("/MyStaticFiles/Admin/a/js/data-table/bootstrap-table-editable.js"), 8775, 80, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 8877, "", 8956, 1);
#nullable restore
#line 187 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 8882, Url.Content("/MyStaticFiles/Admin/a/js/data-table/bootstrap-editable.js"), 8882, 74, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 8978, "", 9064, 1);
#nullable restore
#line 188 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 8983, Url.Content("/MyStaticFiles/Admin/a/js/data-table/bootstrap-table-resizable.js"), 8983, 81, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 9086, "", 9170, 1);
#nullable restore
#line 189 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 9091, Url.Content("/MyStaticFiles/Admin/a/js/data-table/colResizable-1.5.source.js"), 9091, 79, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 9192, "", 9275, 1);
#nullable restore
#line 190 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 9197, Url.Content("/MyStaticFiles/Admin/a/js/data-table/bootstrap-table-export.js"), 9197, 78, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 9297, "", 9351, 1);
#nullable restore
#line 191 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 9302, Url.Content("/MyStaticFiles/Admin/a/js/form.js"), 9302, 49, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n\n\n    <script");
                BeginWriteAttribute("src", " src=", 9375, "", 9460, 1);
#nullable restore
#line 194 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 9380, Url.Content("/MyStaticFiles/Admin/a/vendors/chart.js/dist/Chart.bundle.min.js"), 9380, 80, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 9482, "", 9541, 1);
#nullable restore
#line 195 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 9487, Url.Content("/MyStaticFiles/Admin/a/js/dashboard.js"), 9487, 54, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 9563, "", 9620, 1);
#nullable restore
#line 196 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 9568, Url.Content("/MyStaticFiles/Admin/a/js/widgets.js"), 9568, 52, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 9642, "", 9724, 1);
#nullable restore
#line 197 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 9647, Url.Content("/MyStaticFiles/Admin/a/vendors/jqvmap/dist/jquery.vmap.min.js"), 9647, 77, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 9746, "", 9842, 1);
#nullable restore
#line 198 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 9751, Url.Content("/MyStaticFiles/Admin/a/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js"), 9751, 91, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 9864, "", 9953, 1);
#nullable restore
#line 199 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 9869, Url.Content("/MyStaticFiles/Admin/a/vendors/jqvmap/dist/maps/jquery.vmap.world.js"), 9869, 84, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 9975, "", 10059, 1);
#nullable restore
#line 200 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 9980, Url.Content("/MyStaticFiles/Admin/a/vendors/owl.carousel/owl.carousel.min.js"), 9980, 79, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n    <script");
                BeginWriteAttribute("src", " src=", 10081, "", 10150, 1);
#nullable restore
#line 201 "C:\Users\user\source\repos\Artist\Artist\Views\Shared\Employee.cshtml"
WriteAttributeValue("", 10086, Url.Content("/MyStaticFiles/Admin/a/js/html2pdf.bundle.min.js"), 10086, 64, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"></script>
    <script>
    (function ($) {
            ""use strict"";

            jQuery('#vmap').vectorMap({
                map: 'world_en',
                backgroundColor: null,
                color: '#ffffff',
                hoverOpacity: 0.7,
                selectedColor: '#1de9b6',
                enableZoom: true,
                showTooltip: true,
                values: sample_data,
                scaleColors: ['#1de9b6', '#03a9f5'],
                normalizeFunction: 'polynomial'
            });
        })(jQuery);</script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n</html>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591