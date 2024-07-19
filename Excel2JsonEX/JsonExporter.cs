﻿using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace Excel2JsonEX;

/// <summary>
/// 将DataTable对象，转换成JSON string，并保存到文件中
/// </summary>
public class JsonExporter
{
    string mContext = "";
    int mHeaderRows = 0;

    public string context
    {
        get
        {
            return mContext;
        }
    }

    /// <summary>
    /// 构造函数：完成内部数据创建
    /// </summary>
    /// <param name="excel">ExcelLoader Object</param>
    public JsonExporter(ExcelLoader excel, Options options)
    {
        mHeaderRows = options.HeaderRows - 1;
        List<DataTable> validSheets = new List<DataTable>();
        for (int i = 0; i < excel.Sheets.Count; i++)
        {
            DataTable sheet = excel.Sheets[i];

            // 过滤掉包含特定前缀的表单
            string sheetName = sheet.TableName;
            if (options.ExcludePrefix.Length > 0 && sheetName.StartsWith(options.ExcludePrefix))
                continue;

            if (sheet.Columns.Count > 0 && sheet.Rows.Count > 0)
                validSheets.Add(sheet);
        }

        var jsonSettings = new JsonSerializerSettings
        {
            DateFormatString = options.DateFormat,
            Formatting = Formatting.Indented
        };

        if (!options.ForceSheetName && validSheets.Count == 1)
        {   // single sheet

            //-- convert to object
            object sheetValue = convertSheet(validSheets[0], options);
            //-- convert to json string
            mContext = JsonConvert.SerializeObject(sheetValue, jsonSettings);
        }
        else
        { // mutiple sheet

            Dictionary<string, object> data = new Dictionary<string, object>();
            foreach (var sheet in validSheets)
            {
                object sheetValue = convertSheet(sheet, options);
                data.Add(sheet.TableName, sheetValue);
            }

            //-- convert to json string
            mContext = JsonConvert.SerializeObject(data, jsonSettings);
        }
    }

    private object convertSheet(DataTable sheet, Options options)
    {
        if (options.ExportArray)
            return convertSheetToArray(sheet, options);
        else
            return convertSheetToDict(sheet, options);
    }

    private object convertSheetToArray(DataTable sheet, Options options)
    {
        List<object> values = new List<object>();

        int firstDataRow = mHeaderRows;
        for (int i = firstDataRow; i < sheet.Rows.Count; i++)
        {
            DataRow row = sheet.Rows[i];

            values.Add(
                convertRowToDict(sheet, row, options)
                );
        }

        return values;
    }

    /// <summary>
    /// 以第一列为ID，转换成ID->Object的字典对象
    /// </summary>
    private object convertSheetToDict(DataTable sheet, Options options)
    {
        var importData = new Dictionary<string, object>();

        int firstDataRow = mHeaderRows;
        for (var i = firstDataRow; i < sheet.Rows.Count; i++)
        {
            DataRow row = sheet.Rows[i];
            var ID = row[sheet.Columns[0]].ToString();
            if (string.IsNullOrEmpty(ID))
                ID = $"row_{i}";

            var rowObject = convertRowToDict(sheet, row, options);
            // 多余的字段
            // rowObject[ID] = ID;
            importData[ID] = rowObject;
        }

        return importData;
    }

    /// <summary>
    /// 把一行数据转换成一个对象，每一列是一个属性
    /// </summary>
    private Dictionary<string, object> convertRowToDict(DataTable sheet, DataRow row, Options options)
    {
        var rowData = new Dictionary<string, object>();
        int col = 0;
        foreach (DataColumn column in sheet.Columns)
        {
            // 过滤掉包含指定前缀的列
            string columnName = column.ToString();
            if (options.ExcludePrefix.Length > 0 && columnName.StartsWith(options.ExcludePrefix))
                continue;

            var value = row[column];

            // 尝试将单元格字符串转换成 Json Array 或者 Json Object
            if (options.CellJson)
            {
                var cellText = value.ToString()?.Trim();
                if (!string.IsNullOrEmpty(cellText) && (cellText.StartsWith('[') || cellText.StartsWith('{')))
                {
                    try
                    {
                        var cellJsonObj = JsonConvert.DeserializeObject(cellText);
                        if (cellJsonObj != null)
                            value = cellJsonObj;
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                }
            }

            if (value.GetType() == typeof(DBNull))
            {
                value = getColumnDefault(sheet, column, mHeaderRows);
            }
            else if (value.GetType() == typeof(double))
            { // 去掉数值字段的“.0”
                double num = (double)value;
                if ((int)num == num)
                    value = (int)num;
            }

            //全部转换为string
            //方便LitJson.JsonMapper.ToObject<List<Dictionary<string, string>>>(textAsset.text)等使用方式 之后根据自己的需求进行解析
            if (options.AllString && value is not string)
            {
                value = value?.ToString();
            }

            string fieldName = column.ToString();
            // 表头自动转换成小写
            if (options.Lowcase)
                fieldName = fieldName.ToLower();

            if (string.IsNullOrEmpty(fieldName))
                fieldName = string.Format("col_{0}", col);

            rowData[fieldName] = value!;
            col++;
        }

        return rowData;
    }

    /// <summary>
    /// 对于表格中的空值，找到一列中的非空值，并构造一个同类型的默认值
    /// </summary>
    private object? getColumnDefault(DataTable sheet, DataColumn column, int firstDataRow)
    {
        for (int i = firstDataRow; i < sheet.Rows.Count; i++)
        {
            object value = sheet.Rows[i][column];
            Type valueType = value.GetType();
            if (valueType == typeof(DBNull)) { continue; }
            if (valueType.IsValueType)
                return Activator.CreateInstance(valueType);
            break;
        }
        return "";
    }

    /// <summary>
    /// 将内部数据转换成Json文本，并保存至文件
    /// </summary>
    /// <param name="jsonPath">输出文件路径</param>
    public void SaveToFile(string filePath, Encoding encoding)
    {
        //-- 保存文件
        using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            using (TextWriter writer = new StreamWriter(file, encoding))
                writer.Write(mContext);
        }
    }
}