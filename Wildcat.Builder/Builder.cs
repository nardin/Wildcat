using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using com.google.javascript.jscomp;
using dotless.Core;
using java.util;
using java.util.concurrent;

namespace Wildcat.Builder
{
    class Builder
    {
        private readonly string _pathSrc;
        private readonly string _pathBuild;

        public Builder(string pathSrc, string pathBuild)
        {
            _pathSrc = pathSrc;
            _pathBuild = pathBuild;
        }

        public void Do()
        {
            string[] modules =  Directory.GetDirectories(_pathSrc);
            foreach (string module in modules)
            {
                var partsName = module.Split('\\');
                var moduleName = partsName[partsName.Length - 1];
                Console.WriteLine("Найден модуль: "+ moduleName);
                DoJs(module, moduleName);
                DoCss(module, moduleName);
            }
        }

        protected void ScanDir(DirectoryInfo dir, string selector, ref List<string> fileList)
        {
            foreach (var file in dir.GetFiles(selector))
            {
                fileList.Add(file.FullName);
            }
            foreach (var subDir in dir.GetDirectories())
            {
                ScanDir(subDir, selector, ref fileList);
            }
        }

        protected void DoJs(string modulePath, string moduleName)
        {
            var jsFiles = new List<string>();
            ScanDir(new DirectoryInfo(modulePath),"*.js",ref jsFiles);
            FileStream file = new FileStream(_pathBuild+"/"+moduleName+".js",FileMode.Create);

            // Буфер для хранения принятых от клиента данных
            byte[] buffer = new byte[1024];
            // Переменная для хранения количества байт, принятых от клиента
            int Count;



            foreach (string jsFile in jsFiles )
            {
                Compiler compiler = new Compiler();
                CompilerOptions options = new CompilerOptions();
                //options.removeDeadCode = true;
                //options.removeUnusedLocalVars = true;
                //options.inlineFunctions = true;
                Set set = new HashSet();
                set.add("console");
                options.setStripTypes(set);


                var dummy = JSSourceFile.fromCode(_pathBuild+"/tmp" + ".wcjs", "");
                var source = JSSourceFile.fromFile(jsFile);
                var result = compiler.compile(dummy, source, options);
                String str = compiler.toSource();
                //totaljs += str;
                //Console.WriteLine(str);

                buffer = Encoding.UTF8.GetBytes(str);
                file.Write(buffer,0,buffer.Length);
                Console.WriteLine(jsFile);
            }
            file.Close();
        }
        

        protected void DoCss(string modulePath, string moduleName)
        {
            List<string> cssFiles = new List<string>();
            ScanDir(new DirectoryInfo(modulePath), "*.css", ref cssFiles);
            ScanDir(new DirectoryInfo(modulePath), "*.less", ref cssFiles);

            FileStream file = new FileStream(_pathBuild + "/" + moduleName + ".css", FileMode.Create);
            foreach (string cssFile in cssFiles)
            {
                if (cssFile.EndsWith(".less"))
                {
                    string fileText = "";
                    fileText = File.ReadAllText(cssFile);
                    fileText = Less.Parse(fileText);
                    byte[] b1 = Encoding.UTF8.GetBytes(fileText);
                    file.Write(b1,0,b1.Length);
                }
                else
                {
                    int Count = 0;
                    byte[] buffer = new byte[1024];
                    FileStream FS = new FileStream(cssFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    while (FS.Position < FS.Length)
                    {
                        
                        // Читаем данные из файла
                        Count = FS.Read(buffer, 0, buffer.Length);
                        // И передаем их клиенту
                        file.Write(buffer, 0, Count);
                    }
                    FS.Close();
                }
            }
            file.Close();
        }
    }
}
