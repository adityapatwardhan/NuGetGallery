#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuGetGallery.Views.Pages
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Microsoft.Web.Helpers;
    using NuGetGallery;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Pages/Home.cshtml")]
    public class Home : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Home()
        {
        }
        public override void Execute()
        {

            
            #line 1 "..\..\Views\Pages\Home.cshtml"
  
    ViewBag.Tab = "Home";


            
            #line default
            #line hidden
WriteLiteral(@"<section class=""featured"">
    <div>
        <h1>Jump Start Your Projects with NuGet</h1>
        <p >NuGet is a Visual Studio extension that makes it easy to install and update open source libraries and tools in Visual Studio.</p>
        <p class=""sub""><em>So <a href=""http://visualstudiogallery.msdn.microsoft.com/en-us/27077b70-9dad-4c64-adcf-c7cf6bc9970c/file/37502/5/NuGet.Tools.signed.vsix"">install NuGet</a> and get a jump on your next project!</em></p>
        <a class=""install"" href=""http://visualstudiogallery.msdn.microsoft.com/en-us/27077b70-9dad-4c64-adcf-c7cf6bc9970c/fil/37502/5/NuGet.Tools.signed.vsix"">Install NuGet</a>
    </div>
    <img src=""");


            
            #line 11 "..\..\Views\Pages\Home.cshtml"
         Write(Url.Content("~/content/images/hero.png"));

            
            #line default
            #line hidden
WriteLiteral(@""" alt=""NuGet GUI Window"" />
</section> 

<section class=""release"">
    <h2>NuGet 1.6 Released</h2>
    <p>Take 5 minutes and UPGRADE NOW using the Visual Studio Extension Manager. Why? Because there's a pile of new features and it will 
    make your life easier! All these details and <a href=""http://docs.nuget.org/docs/release-notes/nuget-1.6"">more here...</a></p>
</section>

<section class=""info"">
    <h3>About</h3>
    <p>When you use NuGet to install a package, it copies the library files to your solution and automatically updates your project 
    (add references, change config files, etc.). If you remove a package, NuGet reverses whatever changes it made so that no clutter is left.</p>

    <h3>Important Notice</h3>
    <p>You can develop your own package and share it via the NuGet Gallery. Read the documentation for more details on 
    <a title=""Creating and submitting a package"" href=""http://docs.nuget.org/docs/creating-packages/creating-and-publishing-a-package"">how to 
    create and publish a package</a>. If you don&rsquo;t plan on submitting a package, there&rsquo;s no need to register.</p>
</section>
");


        }
    }
}
#pragma warning restore 1591
