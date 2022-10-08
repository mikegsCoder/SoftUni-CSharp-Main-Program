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

        private string GenerateCSharpFromTemplate(string templateCode, object viewModel)
        {
            string typeOfModel = "object";

            if (viewModel != null)
            {
                if (viewModel.GetType().IsGenericType)
                {
                    var modelName = viewModel.GetType().FullName;

                    var genericArguments = viewModel.GetType().GenericTypeArguments;

                    typeOfModel = modelName
                        .Substring(0, modelName.IndexOf('`'))
                        + "<" + string.Join(",", genericArguments.Select(x => x.FullName)) + ">";
                }
                else
                {
                    typeOfModel = viewModel.GetType().FullName;
                }
            }

            string csharpCode = @"
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using SUS.MvcFramework.ViewEngine;

namespace ViewNamespace
{
    public class ViewClass : IView
    {
        public string ExecuteTemplate(object viewModel, string user)
        {
            var User = user;

            var Model = viewModel as " + typeOfModel + @";

            var html = new StringBuilder();

            " + GetMethodBody(templateCode) + @"

            return html.ToString();
        }
    }
}
";
            return csharpCode;
        }

        private string GetMethodBody(string templateCode)
        {
            Regex csharpCodeRegex = new Regex(@"[^\""\s&\'\<]+");

            var supportedOperators = new List<string> { "for", "while", "if", "else", "foreach" };

            StringBuilder csharpCode = new StringBuilder();

            StringReader sr = new StringReader(templateCode);

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (supportedOperators.Any(x => line.TrimStart().StartsWith("@" + x)))
                {
                    var atSignLocation = line.IndexOf("@");

                    line = line.Remove(atSignLocation, 1);

                    csharpCode.AppendLine(line);
                }
                else if (line.TrimStart().StartsWith("{") ||
                         line.TrimStart().StartsWith("}"))
                {
                    csharpCode.AppendLine(line);
                }
                else
                {
                    csharpCode.Append($"html.AppendLine(@\"");

                    while (line.Contains("@"))
                    {
                        var atSignLocation = line.IndexOf("@");

                        var htmlBeforeAtSign = line.Substring(0, atSignLocation);

                        csharpCode.Append(htmlBeforeAtSign.Replace("\"", "\"\"") + "\" + ");

                        var lineAfterAtSign = line.Substring(atSignLocation + 1);

                        var code = csharpCodeRegex.Match(lineAfterAtSign).Value;

                        csharpCode.Append(code + " + @\"");

                        line = lineAfterAtSign.Substring(code.Length);
                    }

                    csharpCode.AppendLine(line.Replace("\"", "\"\"") + "\");");
                }
            }

            return csharpCode.ToString();
        }
    }
}