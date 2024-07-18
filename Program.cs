using System;
using System.IO;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommandLine;


namespace excel2json
{
    /// <summary>
    /// 应用程序
    /// </summary>
    sealed partial class Program
    {
        /// <summary>
        /// 应用程序入口
        /// </summary>
        /// <param name="args">命令行参数</param>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                //-- GUI MODE ----------------------------------------------------------
                Console.WriteLine("Launch excel2json GUI Mode...");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GUI.MainForm());
            }
            else
            {
                //-- COMMAND LINE MODE -------------------------------------------------

                //-- 分析命令行参数
                var parser = new Parser(with => with.HelpWriter = Console.Error);

                parser.ParseArguments<Options>(args)
                    .WithParsed(options =>
                    {
                        //-- 执行导出操作
                        try
                        {
                            var startTime = DateTime.Now;
                            Run(options);
                            //-- 程序计时
                            var endTime = DateTime.Now;
                            var dur = endTime - startTime;
                            Console.WriteLine($"[{Path.GetFileName(options.ExcelPath)}]：\tConversion complete in [{dur.TotalMilliseconds}ms].");
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine($"Error: {exp.Message}");
                        }
                    })
                    .WithNotParsed(errors =>
                    {
                        // 处理解析错误
                        Environment.Exit(-1);
                    });

            }// end of else
        }

        /// <summary>
        /// 根据命令行参数，执行Excel数据导出工作
        /// </summary>
        /// <param name="options">命令行参数</param>
        private static void Run(Options options)
        {

            //-- Excel File 
            var excelPath = options.ExcelPath;
            var excelName = Path.GetFileNameWithoutExtension(options.ExcelPath);

            //-- Header
            var header = options.HeaderRows;

            //-- Encoding
            Encoding cd = new UTF8Encoding(false);
            if (options.Encoding != "utf8-nobom")
            {
                foreach (var ei in Encoding.GetEncodings())
                {
                    var e = ei.GetEncoding();
                    if (e.HeaderName == options.Encoding)
                    {
                        cd = e;
                        break;
                    }
                }
            }

            //-- Date Format
            var dateFormat = options.DateFormat;

            //-- Export path
            string exportPath;
            if (options.JsonPath != null && options.JsonPath.Length > 0)
            {
                exportPath = options.JsonPath;
            }
            else
            {
                exportPath = Path.ChangeExtension(excelPath, ".json");
            }

            //-- Load Excel
            var excel = new ExcelLoader(excelPath, header);

            //-- export
            var exporter = new JsonExporter(excel, options.Lowcase, options.ExportArray, dateFormat, options.ForceSheetName, header, options.ExcludePrefix, options.CellJson, options.AllString);
            exporter.SaveToFile(exportPath, cd);

            //-- 生成C#定义文件
            if (options.CSharpPath != null && options.CSharpPath.Length > 0)
            {
                var generator = new CSDefineGenerator(excelName, excel, options.ExcludePrefix);
                generator.SaveToFile(options.CSharpPath, cd);
            }
        }
    }
}
