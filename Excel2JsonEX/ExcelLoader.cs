using MiniExcelLibs;
using System.Data;

namespace Excel2JsonEX
{
    /// <summary>
    /// 将 Excel 文件(*.xls 或者 *.xlsx)加载到内存 DataSet
    /// </summary>
    public class ExcelLoader
    {
        private DataSet mData;

        // TODO: add Sheet Struct Define

        public ExcelLoader(string filePath, int headerRow)
        {
            var result = new DataSet();

            using var stream = File.OpenRead(filePath);
            // 使用 MiniExcel 读取 Excel 文件
            var sheets = MiniExcel.GetSheetNames(stream);
            foreach (var sheet in sheets)
            {
                var excelData = MiniExcel.QueryAsDataTable(stream, sheetName: sheet, useHeaderRow: true);
                // 将读取的 DataTable 添加到 DataSet 中
                result.Tables.Add(excelData);
            }


            mData = result;

            if (Sheets.Count < 1)
            {
                throw new Exception("Excel file is empty: " + filePath);
            }
        }

        public DataTableCollection Sheets
        {
            get
            {
                return mData.Tables;
            }
        }
    }
}
