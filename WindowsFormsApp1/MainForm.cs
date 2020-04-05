using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeployTool.WinForm
{
    public partial class MainForm : Form
    {

        public class ProjectConfig 
        {
            public string ProjectPath { get; set; }
            public string TargetPath { get; set; }
            public bool Selected { get; set; }
            public string IgnoreRules { get; set; }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void SetProjectGrid(DataGridView dgv)
        {
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.Columns["IgnoreRules"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.Columns["IgnoreRules"].CellTemplate = new CustomDataGridViewTextBoxCell();
            dgv.DataSource = new List<ProjectConfig> { new ProjectConfig() { Selected = true }, new ProjectConfig() };
        }

        /// <summary>
        /// 執行複製
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CopyExecute_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 打開設定檔
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void openIniFile_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 打開專案資料夾
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OpenWorkflowConfig_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 打開專案資料夾
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OpenTargetPathFolder_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 打開目標資料夾
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OpenOriginalPathFolder_Click(object sender, EventArgs e)
        {
        }


        private void OpenCatalogFolder_Click(object sender, EventArgs e)
        {
        }

        private void ExecuteDeploy_Click(object sender, EventArgs e)
        {

        }
        private void CboWorkflow_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void OpenExecuteFolder_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {

        }
    }
    public class CustomDataGridViewTextBoxEditingControl : DataGridViewTextBoxEditingControl
    {
        public override bool EditingControlWantsInputKey(
            Keys keyData,
            bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Enter:
                    // Don't let the DataGridView handle the Enter key.
                    return true;
                default:
                    break;
            }
            return base.EditingControlWantsInputKey(keyData, dataGridViewWantsInputKey);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode & Keys.KeyCode)
            {
                case Keys.Enter:
                    int oldSelectionStart = this.SelectionStart;
                    string currentText = this.Text;

                    this.Text = String.Format("{0}{1}{2}",
                        currentText.Substring(0, this.SelectionStart),
                        Environment.NewLine,
                        currentText.Substring(this.SelectionStart + this.SelectionLength));

                    this.SelectionStart = oldSelectionStart + Environment.NewLine.Length;
                    break;
                default:
                    break;
            }

            base.OnKeyDown(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
    class CustomDataGridViewTextBoxCell : DataGridViewTextBoxCell
    {
        public override Type EditType => typeof(CustomDataGridViewTextBoxEditingControl);
    }
}
