using CommandLine;
using Excel2JsonEX;
using System.Text;

/// <summary>
/// 根据命令行参数，执行Excel数据导出工作
/// </summary>
/// <param name="options">命令行参数</param>
static void Run(Options options)
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

// See https://aka.ms/new-console-template for more information
if (args.Length <= 0)
{
    //-- GUI MODE ----------------------------------------------------------
    Console.WriteLine("Please use Excel2JsonEX.GUI.exe");
    Console.Read();
    // Application.EnableVisualStyles();
    // Application.SetCompatibleTextRenderingDefault(false);
    // Application.Run(new GUI.MainForm());
}
else
{
    //-- COMMAND LINE MODE -------------------------------------------------

    //-- 分析命令行参数
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
