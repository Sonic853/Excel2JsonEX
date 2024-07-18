using CommandLine;

namespace Excel2JsonEX;

/// <summary>
/// 命令行参数定义
/// </summary>
public sealed class Options
{
    public Options()
    {
        HeaderRows = 3;
        Encoding = "utf8-nobom";
        Lowcase = false;
        ExportArray = false;
        ForceSheetName = false;
    }

    [Option('e', "excel", Required = true, HelpText = "input excel file path.")]
    public string ExcelPath
    {
        get;
        set;
    }

    [Option('j', "json", Required = false, HelpText = "export json file path.")]
    public string? JsonPath
    {
        get;
        set;
    }

    [Option('p', "csharp", Required = false, HelpText = "export C# data struct code file path.")]
    public string? CSharpPath
    {
        get;
        set;
    }

    [Option('h', "header", Required = false, Default = 1, HelpText = "number lines in sheet as header.")]
    public int HeaderRows
    {
        get;
        set;
    }

    [Option('c', "encoding", Required = false, Default = "utf8-nobom", HelpText = "export file encoding.")]
    public string Encoding
    {
        get;
        set;
    }

    [Option('l', "lowcase", Required = false, Default = false, HelpText = "convert filed name to lowcase.")]
    public bool Lowcase
    {
        get;
        set;
    }

    [Option('a', "array", Required = false, Default = false, HelpText = "export as array, otherwise as dict object.")]
    public bool ExportArray
    {
        get;
        set;
    }

    [Option('d', "date", Required = false, Default = "yyyy/MM/dd", HelpText = "Date Format String, example: dd / MM / yyy hh: mm:ss.")]
    public string DateFormat
    {
        get;
        set;
    }

    [Option('s', "sheet", Required = false, Default = false, HelpText = "export with sheet name, even there's only one sheet.")]
    public bool ForceSheetName
    {
        get;
        set;
    }

    [Option('x', "exclude_prefix", Required = false, Default = "", HelpText = "exclude sheet or column start with specified prefix.")]
    public string ExcludePrefix
    {
        get;
        set;
    }

    [Option('j', "cell_json", Required = false, Default = false, HelpText = "convert json string in cell")]
    public bool CellJson
    {
        get;
        set;
    }

    [Option('r', "all_string", Required = false, Default = false, HelpText = "all string")]
    public bool AllString
    {
        get;
        set;
    }
}