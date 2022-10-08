using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.CSharp;
using System.Text.RegularExpressions;

namespace SUS.MvcFramework.ViewEngine
{
    public class SusViewEngine : IViewEngine
    {
        public string GetHtml(string templateCode, object viewModel, string user)
        {
            string csharpCode = GenerateCSharpFromTemplate(templateCode, viewModel);

            IView executableObject = GenerateExecutableCоde(csharpCode, viewModel);

            string html = executableObject.ExecuteTemplate(viewModel, user);

            return html;
        }
    }
}