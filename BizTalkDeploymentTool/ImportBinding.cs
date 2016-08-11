using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BizTalkDeploymentTool.Actions;
using System.Xml;

namespace BizTalkDeploymentTool
{
    public partial class ImportBinding : Form
    {
        private string ApplicaionName { get; set; }
        private string BindingFile { get; set; }

        public enum FormStateEnum
        {
            Initial,
            NotProcessing,
            Processing
        }

        private FormStateEnum _formState = FormStateEnum.Initial;
        private FormStateEnum FormState
        {
            get
            {
                return _formState;
            }

            set
            {
                if (_formState != value)
                {
                    UpdateFormState(value);
                }
                _formState = value;
            }
        }

        private void UpdateFormState(FormStateEnum formState)
        {
            switch (formState)
            {
                case FormStateEnum.Initial:
                    button1.Enabled = false;
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.NotProcessing:
                    button1.Enabled = true;
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.Processing:
                    button1.Enabled = false;
                    UpdateCursor(Cursors.WaitCursor);
                    break;

            }
        }

        private void UpdateCursor(Cursor cursor)
        {
            if (this.InvokeRequired)
            {
                // We're on a thread other than the GUI thread
                this.Invoke(new MethodInvoker(() => UpdateCursor(cursor)));
                return;
            }

            this.Cursor = cursor;
        }

        public ImportBinding()
        {
            InitializeComponent();
        }

        public ImportBinding(string applicationName)
        {
            InitializeComponent();
            this.ApplicaionName = applicationName;
            label1.Text = this.ApplicaionName;
        }

        private void btnBrowseMSI_Click(object sender, EventArgs e)
        {
            try
            {
                string fileToOpen = string.Empty;
                if (openMsiFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        richTextBox1.Text = string.Empty;
                        fileToOpen = openMsiFileDialog.FileName;
                        this.BindingFile = fileToOpen;
                        textBox1.Text = this.BindingFile;
                    }
                    finally
                    {
                        this.FormState = FormStateEnum.NotProcessing;
                    }

                }
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }
        private void DisplayError(Exception ex)
        {
            DisplayError(ex.Message);
        }

        private void DisplayError(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private DialogResult DisplayQuestion(string message)
        {
            return MessageBox.Show(message, "BTDT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        private DialogResult DisplayWarning(string message)
        {
            return MessageBox.Show(message, "BTDT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool appValidateResult = ValidateBindingFileForSelectedApplication(this.ApplicaionName, this.BindingFile);
            if (appValidateResult)
            {
                Import();
            }
            else
            {
                DialogResult dRes = DisplayWarning("The application name specified does not match the binding file. Do you wish to continue?");
                if(dRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Import();
                }
            }

        }

        private void Import()
        {
            try
            {
                this.FormState = FormStateEnum.Processing;
                string resultMessage = string.Empty;
                ImportApplicationBindingAction importBinding = new ImportApplicationBindingAction(this.ApplicaionName, this.BindingFile);
                importBinding.Execute(out resultMessage);
                richTextBox1.Text = resultMessage;
                this.FormState = FormStateEnum.NotProcessing;
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private bool ValidateBindingFileForSelectedApplication(string p1, string p2)
        {
            XmlDocument bindingXml = new XmlDocument();
            bindingXml.Load(p2);
            XmlNode appNode = bindingXml.SelectSingleNode("//BindingInfo//ModuleRefCollection//ModuleRef[1]/@Name");
            return string.Format("[Application:{0}]", p1) == appNode.Value;
        }
    }
}
