using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using System.ComponentModel;
using System.Text;

namespace Excel2JsonEX.GUI
{
    /// <summary>
    /// 主窗口
    /// </summary>
    public partial class MainForm : Form
    {
        // Excel导入数据管理
        private DataManager mDataMgr;
        private string mCurrentXlsx = string.Empty;

        // 支持语法高亮的文本框
        private TextEditorControlEx mJsonTextBox;
        private TextEditorControlEx mCSharpTextBox;

        // 导出数据相关的按钮，方便整体Enable/Disable
        private List<ToolStripButton> mExportButtonList;

        // 打开的excel文件名，不包含后缀xlsx。。。
        private string FileName = string.Empty;

        /// <summary>
        /// 构造函数，初始化控件初值；创建文本框
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            var synDir = Path.Combine(Application.StartupPath, "Highlighting");

            // check if directory exists to prevent throwing an exception
            if (Directory.Exists(synDir))
            {
                // create new provider with the highlighting directory
                var fsmProvider = new FileSyntaxModeProvider(synDir);
                // attach to the text editor
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmProvider);
            }
            //-- syntax highlight text box
            mJsonTextBox = createTextBoxInTab(tabPageJSON);
            mJsonTextBox.SetFoldingStrategy("JSON");
            mJsonTextBox.SetHighlighting("JSON");
            // mJsonTextBox.TextChanged += jsonTextChanged;

            mCSharpTextBox = createTextBoxInTab(tabCSharp);
            mCSharpTextBox.SetFoldingStrategy("C#");
            mCSharpTextBox.SetHighlighting("C#");

            //-- componet init states
            comboBoxType.SelectedIndex = 0;
            comboBoxLowcase.SelectedIndex = 1;
            comboBoxHeader.SelectedIndex = 1;
            comboBoxDateFormat.SelectedIndex = 0;
            comboBoxSheetName.SelectedIndex = 1;

            comboBoxEncoding.Items.Clear();
            comboBoxEncoding.Items.Add("utf8-nobom");
            foreach (var ei in Encoding.GetEncodings())
            {
                var e = ei.GetEncoding();
                comboBoxEncoding.Items.Add(e.HeaderName);
            }
            comboBoxEncoding.SelectedIndex = 0;

            //-- button list
            mExportButtonList =
            [
                btnCopyJSON,
                btnSaveJson,
                btnCopyCSharp,
                btnSaveCSharp,
            ];
            enableExportButtons(false);

            //-- data manager
            mDataMgr = new();
            btnReimport.Enabled = false;
        }

        /// <summary>
        /// 设置导出相关的按钮是否可用
        /// </summary>
        /// <param name="enable">是否可用</param>
        private void enableExportButtons(bool enable)
        {
            foreach (var btn in mExportButtonList)
                btn.Enabled = enable;
        }

        /// <summary>
        /// 在一个TabPage中创建Text Box
        /// </summary>
        /// <param name="tab">TabPage容器控件</param>
        /// <returns>新建的Text Box控件</returns>
        private TextEditorControlEx createTextBoxInTab(TabPage tab)
        {
            var textBox = new TextEditorControlEx()
            {
                Dock = DockStyle.Fill,
                Font = new("Microsoft YaHei", 11F)
            };
            tab.Controls.Add(textBox);
            return textBox;
        }

        /// <summary>
        /// 使用BackgroundWorker加载Excel文件，使用UI中的Options设置
        /// </summary>
        /// <param name="path">Excel文件路径</param>
        private void loadExcelAsync(string path)
        {

            mCurrentXlsx = path;
            FileName = System.IO.Path.GetFileNameWithoutExtension(path);

            //-- update ui
            btnReimport.Enabled = true;
            labelExcelFile.Text = path;
            enableExportButtons(false);

            statusLabel.IsLink = false;
            statusLabel.Text = "Loading Excel ...";

            //-- load options from ui
            var options = new Options()
            {
                ExcelPath = path,
                ExportArray = comboBoxType.SelectedIndex == 0,
                Encoding = comboBoxEncoding.SelectedText,
                Lowcase = comboBoxLowcase.SelectedIndex == 0,
                HeaderRows = int.Parse(comboBoxHeader.Text),
                DateFormat = comboBoxDateFormat.Text,
                ForceSheetName = comboBoxSheetName.SelectedIndex == 0,
                ExcludePrefix = textBoxExculdePrefix.Text,
                CellJson = checkBoxCellJson.Checked,
                AllString = checkBoxAllString.Checked
            };

            //-- start import
            backgroundWorker.RunWorkerAsync(options);
        }

        /// <summary>
        /// 接受Excel拖放事件
        /// </summary>
        private void panelExcelDropBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null) { return; }
            var dropData = (string[]?)e.Data.GetData(DataFormats.FileDrop, false);
            if (dropData != null)
            {
                loadExcelAsync(dropData[0]);
            }
        }

        /// <summary>
        /// 显示Help文档
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://neil3d.github.io/coding/excel2json.html");
        }

        /// <summary>
        /// 判断拖放对象是否是一个.xlsx文件
        /// </summary>
        private void panelExcelDropBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data == null) { return; }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var dropData = (string[]?)e.Data.GetData(DataFormats.FileDrop, false);
                if (dropData != null && dropData.Length > 0)
                {
                    var szPath = dropData[0];
                    var szExt = System.IO.Path.GetExtension(szPath);
                    FileName = System.IO.Path.GetFileNameWithoutExtension(szPath);
                    szExt = szExt.ToLower();
                    if (szExt == ".xlsx")
                    {
                        e.Effect = DragDropEffects.All;
                        return;
                    }
                }
            }//end of if(file)
            e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// 执行实际的Excel加载
        /// </summary>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null) { return; }
            lock (mDataMgr)
            {
                mDataMgr.loadExcel((Options)e.Argument);
            }
        }

        /// <summary>
        /// Excel加载完成
        /// </summary>
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            // 判断错误信息
            if (e.Error != null)
            {
                showStatus(e.Error.Message, Color.Red);
                return;
            }

            // 更新UI
            lock (mDataMgr)
            {
                statusLabel.IsLink = false;
                statusLabel.Text = "Load completed.";

                mJsonTextBox.Text = mDataMgr.JsonContext;
                mCSharpTextBox.Text = mDataMgr.CSharpCode;

                enableExportButtons(true);
            }
        }

        /// <summary>
        /// 工具栏按钮：Import Excel
        /// </summary>
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                RestoreDirectory = true,
                Filter = "Excel File(*.xlsx)|*.xlsx"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                loadExcelAsync(dlg.FileName);
            }
        }

        /// <summary>
        /// 点击状态栏链接
        /// </summary>
        private void statusLabel_Click(object sender, EventArgs e)
        {
            if (statusLabel.IsLink)
            {
                System.Diagnostics.Process.Start("explorer.exe", statusLabel.Text!);
            }
        }
        /// <summary>
        /// 点击状态栏链接
        /// </summary>
        private void statusLabel1_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.IsLink)
            {
                System.Diagnostics.Process.Start("explorer.exe", toolStripStatusLabel1.Text!);
            }
        }

        /// <summary>
        /// 保存导出文件
        /// </summary>
        private void saveToFile(int type, string filter)
        {

            try
            {
                var dlg = new SaveFileDialog
                {
                    RestoreDirectory = true,
                    Filter = filter,
                    FileName = FileName
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    lock (mDataMgr)
                    {
                        switch (type)
                        {
                            case 1:
                                mDataMgr.saveJson(dlg.FileName);
                                break;
                            case 2:
                                mDataMgr.saveCSharp(dlg.FileName);
                                break;
                        }
                    }
                    showStatus($"{dlg.FileName} saved!", Color.Black);
                }// end of if
            }
            catch (Exception ex)
            {
                showStatus(ex.Message, Color.Red);
            }
        }

        /// <summary>
        /// 工具栏按钮：Save Json
        /// </summary>
        private void btnSaveJson_Click(object sender, EventArgs e)
        {
            saveToFile(1, "Json File(*.json)|*.json");
        }

        /// <summary>
        /// 工具栏按钮：Copy Json
        /// </summary>
        private void btnCopyJSON_Click(object sender, EventArgs e)
        {
            lock (mDataMgr)
            {
                Clipboard.SetText(mDataMgr.JsonContext);
                showStatus("Json text copyed to clipboard.", Color.Black);
            }
        }

        /// <summary>
        /// 设置状态栏信息
        /// </summary>
        /// <param name="szMessage">信息文字</param>
        /// <param name="color">信息颜色</param>
        private void showStatus(string szMessage, Color color)
        {
            statusLabel.Text = szMessage;
            statusLabel.ForeColor = color;
            statusLabel.IsLink = false;
        }

        /// <summary>
        /// 配置项变更之后，手动重新导入xlsx文件
        /// </summary>
        private void btnReimport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mCurrentXlsx))
            {
                loadExcelAsync(mCurrentXlsx);
            }
        }

        private void btnCopyCSharp_Click(object sender, EventArgs e)
        {
            lock (mDataMgr)
            {
                Clipboard.SetText(mDataMgr.CSharpCode);
                showStatus("C# code copyed to clipboard.", Color.Black);
            }
        }

        private void btnSaveCSharp_Click(object sender, EventArgs e)
        {
            saveToFile(2, "C# code file(*.cs)|*.cs");
        }
    }
}
