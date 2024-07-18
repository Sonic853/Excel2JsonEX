using System;
using System.IO;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace excel2json
{
    /// <summary>
    /// 根据表头，生成C#类定义数据结构
    /// 表头使用三行定义：字段名称、字段类型、注释
    /// </summary>
    class CSDefineGenerator
    {
        struct FieldDef
        {
            public string name;
            public string type;
            public string comment;
        }

        string mCode;

        public string code {
            get {
                return mCode;
            }
        }

        public CSDefineGenerator(string excelName, ExcelLoader excel, string excludePrefix)
        {
            //-- 创建代码字符串
            var sb = new StringBuilder();
            sb.AppendLine("//");
            sb.AppendLine("// Auto Generated Code By excel2json");
            sb.AppendLine("// https://neil3d.gitee.io/coding/excel2json.html");
            sb.AppendLine("// 1. 每个 Sheet 形成一个 Struct 定义, Sheet 的名称作为 Struct 的名称");
            sb.AppendLine("// 2. 表格约定：第一行是变量名称，第二行是变量类型");
            sb.AppendLine($"// Generate From {excelName}.xlsx");
            sb.AppendLine();

            for (var i = 0; i < excel.Sheets.Count; i++)
            {
                var sheet = excel.Sheets[i];
                sb.Append(_exportSheet(sheet, excludePrefix));
            }

            sb.AppendLine();
            sb.AppendLine("// End of Auto Generated Code");

            mCode = sb.ToString();
        }

        private string _exportSheet(DataTable sheet, string excludePrefix)
        {
            if (sheet.Columns.Count < 0 || sheet.Rows.Count < 2)
                return "";

            var sheetName = sheet.TableName;
            if (excludePrefix.Length > 0 && sheetName.StartsWith(excludePrefix))
                return "";

            // get field list
            var fieldList = new List<FieldDef>();
            var typeRow = sheet.Rows[0];
            var commentRow = sheet.Rows[1];

            foreach (DataColumn column in sheet.Columns)
            {
                // 过滤掉包含指定前缀的列
                var columnName = column.ToString();
                if (excludePrefix.Length > 0 && columnName.StartsWith(excludePrefix))
                    continue;

                FieldDef field;
                field.name = column.ToString();
                field.type = typeRow[column].ToString();
                field.comment = commentRow[column].ToString();

                fieldList.Add(field);
            }

            // export as string
            var sb = new StringBuilder();
            sb.AppendLine($"public class {sheet.TableName}\r\n{{");
            sb.AppendLine();

            foreach (var field in fieldList)
            {
                sb.AppendLine("\t/// <summary>");
                sb.AppendLine($"\t/// {field.comment}");
                sb.AppendLine("\t/// </summary>");
                sb.AppendLine($"\tpublic {field.type} {field.name};");
            }

            sb.Append('}');
            sb.AppendLine();
            sb.AppendLine();
            return sb.ToString();
        }

        public void SaveToFile(string filePath, Encoding encoding)
        {
            //-- 保存文件
            using var file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var writer = new StreamWriter(file, encoding);
            writer.Write(mCode);
        }
    }
}
