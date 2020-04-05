using System;
using System.Windows.Forms;

namespace DeployTool.Ui.Controls
{
    class CustomDataGridViewTextBoxCell : DataGridViewTextBoxCell
    {
        public override Type EditType => typeof(CustomDataGridViewTextBoxEditingControl);
    }
}