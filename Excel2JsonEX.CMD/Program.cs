using CommandLine;
using Excel2JsonEX;
using System.Diagnostics;
using System.Text;

/// <summary>
/// 根据命令行参数，执行Excel数据导出工作
/// </summary>
/// <param name="options">命令行参数</param>
static void Run(Options options)
{
    //-- Excel File 
    var excelPath = options.ExcelPath;
    if (string.IsNullOrEmpty(excelPath))
    {
        Console.WriteLine("excel is Required");
        return;
    }
    var excelNameExt = Path.GetFileName(options.ExcelPath);
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
    if (!string.IsNullOrEmpty(options.JsonPath))
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
    var exporter = new JsonExporter(excel, options);
    exporter.SaveToFile(exportPath, cd);

    //-- 生成C#定义文件
    if (options.CSharpPath != null && options.CSharpPath.Length > 0)
    {
        var generator = new CSDefineGenerator(excelNameExt, excel, options);
        generator.SaveToFile(options.CSharpPath, cd);
    }
}

// See https://aka.ms/new-console-template for more information
if (args.Length <= 0)
{
    //-- GUI MODE ----------------------------------------------------------
    Console.WriteLine("Please use Excel2JsonEX.GUI.exe");
    if (File.Exists("Excel2JsonEX.GUI.exe"))
    {
        Process.Start("Excel2JsonEX.GUI.exe");
    }
    else
    {
        Console.Read();
    }
    return;
}

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
