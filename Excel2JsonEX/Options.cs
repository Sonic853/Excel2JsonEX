using CommandLine;

namespace Excel2JsonEX;

/// <summary>
/// 命令行参数定义
/// </summary>
public sealed class Options
{
    public Options()
    {
        ExcelPath = string.Empty;
        HeaderRows = 3;
        Encoding = "utf8-nobom";
        Lowcase = false;
        ExportArray = false;
        DateFormat = "yyyy/MM/dd";
        ForceSheetName = false;
        ExcludePrefix = "";
    }

    /// <summary>
    /// input excel file path.
    /// </summary>
    [Option('e', "excel", Required = true, HelpText = "input excel file path.")]
    public string ExcelPath
    {
        get;
        set;
    }

    /// <summary>
    /// export json file path.
    /// </summary>
    [Option('j', "json", Required = false, HelpText = "export json file path.")]
    public string? JsonPath
    {
        get;
        set;
    }

    /// <summary>
    /// export C# data struct code file path.
    /// </summary>
    [Option('p', "csharp", Required = false, HelpText = "export C# data struct code file path.")]
    public string? CSharpPath
    {
        get;
        set;
    }

    /// <summary>
    /// number lines in sheet as header.
    /// </summary>
    [Option('h', "header", Required = false, Default = 3, HelpText = "number lines in sheet as header.")]
    public int HeaderRows
    {
        get;
        set;
    }

    /// <summary>
    /// export file encoding.
    /// </summary>
    [Option('c', "encoding", Required = false, Default = "utf8-nobom", HelpText = "export file encoding.")]
    public string Encoding
    {
        get;
        set;
    }

    /// <summary>
    /// convert filed name to lowcase.
    /// </summary>
    [Option('l', "lowcase", Required = false, Default = false, HelpText = "convert filed name to lowcase.")]
    public bool Lowcase
    {
        get;
        set;
    }

    /// <summary>
    /// export as array, otherwise as dict object.
    /// </summary>
    [Option('a', "array", Required = false, Default = false, HelpText = "export as array, otherwise as dict object.")]
    public bool ExportArray
    {
        get;
        set;
    }

    /// <summary>
    /// Date Format String, example: dd / MM / yyy hh: mm:ss.
    /// </summary>
    [Option('d', "date", Required = false, Default = "yyyy/MM/dd", HelpText = "Date Format String, example: dd / MM / yyy hh: mm:ss.")]
    public string DateFormat
    {
        get;
        set;
    }

    /// <summary>
    /// export with sheet name, even there's only one sheet.
    /// </summary>
    [Option('s', "sheet", Required = false, Default = false, HelpText = "export with sheet name, even there's only one sheet.")]
    public bool ForceSheetName
    {
        get;
        set;
    }

    /// <summary>
    /// exclude sheet or column start with specified prefix.
    /// </summary>
    [Option('x', "exclude_prefix", Required = false, Default = "", HelpText = "exclude sheet or column start with specified prefix.")]
    public string ExcludePrefix
    {
        get;
        set;
    }

    /// <summary>
    /// convert json string in cell
    /// </summary>
    [Option('j', "cell_json", Required = false, Default = false, HelpText = "convert json string in cell")]
    public bool CellJson
    {
        get;
        set;
    }

    /// <summary>
    /// all string
    /// </summary>
    [Option('r', "all_string", Required = false, Default = false, HelpText = "all string")]
    public bool AllString
    {
        get;
        set;
    }
}