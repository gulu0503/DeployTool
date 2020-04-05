using System;
using System.Windows.Forms;

namespace DeployTool.Ui.Controls
{
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
}