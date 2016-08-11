using BizTalkDeploymentTool.Global;
using BizTalkDeploymentTool.Helpers;
using Microsoft.BizTalk.ExplorerOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizTalkDeploymentTool
{
    public partial class SetHandlers : Form
    {
        string logpath = GenericHelper.WriteLog("");
       // string logPath = string.Format(@"C:\Temp\BTDT_ChangeHandlersLog_{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
       // StringBuilder sbLog = new StringBuilder();
        public enum FormStateEnum
        {
            Initial,
            NotProcessing,
            Processing
        }
        ExplorerOMHelper explorerHelper = new ExplorerOMHelper(GlobalProperties.MgmtDBServer, GlobalProperties.MgmtDBName);
        ProtocolTypeCollection adapterCollection = new ProtocolTypeCollection();

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
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.NotProcessing:
                    UpdateCursor(Cursors.Default);
                    break;

                case FormStateEnum.Processing:
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

        public SetHandlers()
        {
            InitializeComponent();
            adapterCollection = explorerHelper.GetAdapters();

        }

        private void SetHandlers_Load(object sender, EventArgs e)
        {
            LoadAllAdapters();
        }

        private void LoadAllAdapters()
        {
            List<string> adapList = new List<string>();
            foreach (ProtocolType item in adapterCollection)
            {
                adapList.Add(item.Name);
            }
            comboBoxAdapters.Items.AddRange(adapList.OrderBy(c => c).ToArray());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = DisplayQuestion("Are you sure you want to change the handlers for selected artifacts");
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    progressBar1.Value = 0;
                    if (CheckIfValidForm())
                    {
                        this.FormState = FormStateEnum.Processing;
                        if (checkBoxRcvPort.Checked && checkBoxSendPort.Checked)
                        {
                            progressBar1.Maximum = explorerHelper.CatalogExplorer.SendPorts.Count + explorerHelper.CatalogExplorer.ReceivePorts.Count;
                            SetForReceivePorts();
                            SetForSendPorts();
                        }
                        else if (checkBoxRcvPort.Checked)
                        {
                            progressBar1.Maximum = explorerHelper.CatalogExplorer.ReceivePorts.Count;
                            SetForReceivePorts();
                        }
                        else if (checkBoxSendPort.Checked)
                        {
                            progressBar1.Maximum = explorerHelper.CatalogExplorer.SendPorts.Count;
                            SetForSendPorts();
                        }
                        this.FormState = FormStateEnum.NotProcessing;
                        GenericHelper.WriteLog(string.Format("Done changing handlers --- {0}", DateTime.Now));
                        string logpath = GenericHelper.WriteLog("===========================================================================================");
                        DisplayMessage("Done changing handlers");
                    }
                    else
                    {
                        DisplayMessage("Please select valid values and/or check the port type");
                    }
                   // GenericHelper.WriteLog(sbLog.ToString());
                }

                catch (Exception ex)
                {
                    DisplayError(ex);
                }
                finally
                {
                    linkLabel1.Text = string.Format("Log file is saved at {0}",logpath);
                   // sbLog = new StringBuilder();
                }
            }


        }

        private bool CheckIfValidForm()
        {
            bool isValid = true;
            if (comboBoxAdapters.SelectedItem == null || string.IsNullOrEmpty(comboBoxAdapters.SelectedItem.ToString()))
            {
                isValid = false;
            }
            if (checkBoxRcvPort.Checked)
            {
                if (comboBoxReceiveHandlers.SelectedItem == null || string.IsNullOrEmpty(comboBoxReceiveHandlers.SelectedItem.ToString()))
                {
                    isValid = false;
                }
            }
            if (checkBoxSendPort.Checked)
            {
                if (comboBoxSendHandlers.SelectedItem == null || string.IsNullOrEmpty(comboBoxSendHandlers.SelectedItem.ToString()))
                {
                    isValid = false;
                }
            }
            return isValid;

        }

        private void SetForSendPorts()
        {
            foreach (SendPort sendPort in explorerHelper.CatalogExplorer.SendPorts)
            {
                if (sendPort.IsDynamic)
                {
                    foreach (DynamicSendHandler sendHandler in sendPort.DynamicSendHandlers)
                    {
                        if (sendHandler.SendHandler.TransportType.Name == comboBoxAdapters.SelectedItem.ToString())
                        {
                            sendPort.SetSendHandler(comboBoxAdapters.SelectedItem.ToString(), comboBoxSendHandlers.SelectedItem.ToString());
                            GenericHelper.WriteLog(string.Format("Changed dynamic send port {0} handler to {1}", sendPort.Name, comboBoxSendHandlers.SelectedItem.ToString()));
                            //sbLog.AppendLine( );
                            break;
                        }

                    }
                }
                else
                {
                    if (sendPort.PrimaryTransport.TransportType.Name == comboBoxAdapters.SelectedItem.ToString())
                    {
                        foreach (SendHandler sendHandler in explorerHelper.CatalogExplorer.SendHandlers)
                        {
                            if (sendHandler.TransportType.Name == sendPort.PrimaryTransport.TransportType.Name && sendHandler.Name == comboBoxSendHandlers.SelectedItem.ToString())
                            {
                                if (sendPort.PrimaryTransport.SendHandler != sendHandler)
                                {
                                    sendPort.PrimaryTransport.SendHandler = sendHandler;
                                    GenericHelper.WriteLog(string.Format("Changed send port {0} handler to {1}", sendPort.Name, comboBoxSendHandlers.SelectedItem.ToString()));
                                    break;
                                }
                            }
                        }
                    }
                }                
                progressBar1.Value++;
            }
            GenericHelper.WriteLog("===========================================================================================");
            explorerHelper.CatalogExplorer.SaveChanges();
        }

        private void SetForReceivePorts()
        {
            foreach (ReceivePort receivePort in explorerHelper.CatalogExplorer.ReceivePorts)
            {
                foreach (ReceiveLocation receiveLocation in receivePort.ReceiveLocations)
                {
                    if (receiveLocation.ReceiveHandler.TransportType.Name == comboBoxAdapters.SelectedItem.ToString())
                    {
                        foreach (ReceiveHandler receiveHandler in explorerHelper.CatalogExplorer.ReceiveHandlers)
                        {
                            if (receiveHandler.TransportType.Name == comboBoxAdapters.SelectedItem.ToString())
                            {
                                if (receiveHandler.Name == comboBoxReceiveHandlers.SelectedItem.ToString())
                                {
                                    if (receiveLocation.ReceiveHandler != receiveHandler)
                                    {
                                        receiveLocation.ReceiveHandler = receiveHandler;
                                        GenericHelper.WriteLog(string.Format("Changed receive port {0} handler to {1}", receiveLocation.Name, comboBoxReceiveHandlers.SelectedItem.ToString()));
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                progressBar1.Value++;
            }
            GenericHelper.WriteLog("===========================================================================================");
            explorerHelper.CatalogExplorer.SaveChanges();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxReceiveHandlers.Items.Clear();
            comboBoxSendHandlers.Items.Clear();
            string adapter = comboBoxAdapters.SelectedItem.ToString();

            foreach (ReceiveHandler item in explorerHelper.CatalogExplorer.ReceiveHandlers)
            {
                if (item.TransportType.Name == adapter)
                {
                    comboBoxReceiveHandlers.Items.Add(item.Name);
                }
            }
            foreach (SendHandler item in explorerHelper.CatalogExplorer.SendHandlers)
            {
                if (item.TransportType.Name == adapter)
                {
                    comboBoxSendHandlers.Items.Add(item.Name);
                }
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
        private void DisplayMessage(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private DialogResult DisplayQuestion(string message)
        {
            return MessageBox.Show(message, "BTDT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(logpath);
        }
    }
}
