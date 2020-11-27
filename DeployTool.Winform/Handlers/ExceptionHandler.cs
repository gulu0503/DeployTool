using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DeployTool.SharedKernel.Exceptions;

namespace DeployTool.WinForm.Handlers
{
    public static class ExceptionHandler
    {
        public static void HandleException()
        {
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var ex = (Exception)e.ExceptionObject;
                WriteLog(ex);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show(
                        "Fatal Non-UI Error. Could not write the error to the event log. Reason: " + exc.Message,
                        "Fatal Non-UI Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var result = DialogResult.Cancel;
            try
            {
                WriteLog(e.Exception);
                result = ShowThreadExceptionDialog("系統訊息", e.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "Fatal Windows Forms Error",
                        MessageBoxButtons.AbortRetryIgnore,
                        MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            if (result == DialogResult.Abort)
                Application.Exit();
        }

        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            return e switch
            {
                CustomException _ => MessageBox.Show(e.Message, title),
                _ => MessageBox.Show($"發生錯誤，請查看Log。\r\n\r\n{e.Message}", title)
            };
        }

        private static void WriteLog(Exception e)
        {
            var folderPath = Path.Combine(Application.StartupPath, "Logs");
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory("Logs");
            var path = Path.Combine(folderPath, "Exception_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            File.AppendAllText(path, e.Message + "\r\n\r\nStack Trace:\r\n" + e.StackTrace);
        }
    }
}
