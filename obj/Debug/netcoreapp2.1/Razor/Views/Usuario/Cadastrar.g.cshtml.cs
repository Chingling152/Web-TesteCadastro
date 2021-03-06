#pragma checksum "F:\o\Jogos\Outros\Meus Projetos\Sites\Web-TesteCadastroMVC\Views\Usuario\Cadastrar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5bf65875c455b9ab3d555353ef8ba631140dbc54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Cadastrar), @"mvc.1.0.view", @"/Views/Usuario/Cadastrar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Usuario/Cadastrar.cshtml", typeof(AspNetCore.Views_Usuario_Cadastrar))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bf65875c455b9ab3d555353ef8ba631140dbc54", @"/Views/Usuario/Cadastrar.cshtml")]
    public class Views_Usuario_Cadastrar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("flex-column"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 38, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"PT-BR\">\r\n");
            EndContext();
            BeginContext(38, 139, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a3eb460520874a60b742a3b5c66da6eb", async() => {
                BeginContext(44, 70, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <title>Cadastrar Usuario</title>\r\n");
                EndContext();
#line 6 "F:\o\Jogos\Outros\Meus Projetos\Sites\Web-TesteCadastroMVC\Views\Usuario\Cadastrar.cshtml"
      
        Layout = "MasterPageDeslogado";
    

#line default
#line hidden
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
            EndContext();
            BeginContext(177, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(179, 1291, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "386a232f5c39497dac7b1a65ee3e4a1a", async() => {
                BeginContext(205, 69, true);
                WriteLiteral("    \r\n    <section>\r\n        <h1>Cadastrar Usuario</h1>\r\n        <h2>");
                EndContext();
                BeginContext(275, 16, false);
#line 13 "F:\o\Jogos\Outros\Meus Projetos\Sites\Web-TesteCadastroMVC\Views\Usuario\Cadastrar.cshtml"
       Write(ViewBag.Mensagem);

#line default
#line hidden
                EndContext();
                BeginContext(291, 1172, true);
                WriteLiteral(@"</h2>
        <form action = ""/Usuario/Cadastrar"" method=""POST"" class=""flex-column"">
            <label>Nome
                <input type=""text"" minlength=""2"" maxlength=""50"" name = ""Nome"" placeholder=""Ex :João da Silva"" required>
            </label>
            <label>Email
                <input type=""email"" name=""Email"" placeholder=""Ex : joaodasilva@hotmail.com"" required>
            </label>
            <label>Senha
                <input type=""text"" minlength=""8"" name = ""Senha"" required placeholder=""Ex : A6ef28R4f "">
            </label>
            <label>Data De Nascimento
                <input type=""date"" name=""DataNascimento"" required>
            </label>
            <label> Privilegios</label>
            <div id=""radio-group"">
                <label>
                    <input type=""radio"" name=""Tipo"" value=""Usuario"" checked> Usuario normal
                </label>    
                <label>
                    <input type=""radio"" name=""Tipo"" value=""Administrador"" disabled> Ad");
                WriteLiteral("ministrador\r\n                </label>\r\n            </div>\r\n            <input type=\"submit\" value=\"Cadastrar-se\">\r\n        </form>\r\n    </section>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1470, 9, true);
            WriteLiteral("\r\n</html>");
            EndContext();
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
