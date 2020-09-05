using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;
namespace Nero.Common.Helpers
{
    public class CompilerHelper
    {

        public string FileName { get; set; }

        public string OutputLocation { get; set; }


        public Boolean GenerateExecutable { get; set; }



        public CompilerResults GenerateAssemblyFromString(string code)
        {

            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            //ICodeCompiler icc = CSharpCodeProvider.CreateProvider("")//codeProvider.CreateCompiler();
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = GenerateExecutable;
            parameters.IncludeDebugInformation = true;
            if (GenerateExecutable)
            {
                parameters.OutputAssembly = FileName + ".exe";
            }

            else
            {

                parameters.OutputAssembly = FileName + ".dll";
            }

            CompilerResults results = CodeDomProvider.CreateProvider("CSharp").CompileAssemblyFromSource(parameters, code);

            return results;

        }

        public CompilerResults GenerateAssemblyFromFiles(List<string> fileNames)
        {

            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
           
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = GenerateExecutable;
            parameters.IncludeDebugInformation = true;
            if (GenerateExecutable)
            {
                parameters.OutputAssembly = FileName + ".exe";
            }

            else
            {

                parameters.OutputAssembly = FileName + ".dll";
            }

            CompilerResults results = CodeDomProvider.CreateProvider("CSharp").CompileAssemblyFromFile(parameters, fileNames.ToArray());

            return results;

        }

    }
}
