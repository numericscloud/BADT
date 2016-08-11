using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace BizTalkDeploymentTool
{
    public partial class LocateMsi : Form
    {
        private string ApplicationGuid;
        List<string> appMsis = new List<string>();
        int backgroundWorkerIndex = 0;
        int filesCount = 0;
        public LocateMsi()
        {
            InitializeComponent();
        }

        public LocateMsi(string applicationGuid)
        {
            InitializeComponent();
            this.ApplicationGuid = applicationGuid;
        }

        private void LocateMsi_Load(object sender, EventArgs e)
        {
            /*int workerThread ;
            int iothread;
            ThreadPool.GetAvailableThreads(out workerThread, out iothread);*/
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 10;
            numericUpDown2.Minimum = 1;
            numericUpDown2.Maximum = 10;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                FileData[] fileData = FastDirectoryEnumerator.GetFiles(textBox1.Text, "*.msi", SearchOption.AllDirectories);
                filesCount = fileData.Count();
                ManualResetEvent[] doneEvents = new ManualResetEvent[filesCount];
                LocateMsiWorkerArea[] locateMsiWorkerAreaArray = new LocateMsiWorkerArea[filesCount];
                ThreadPool.SetMaxThreads(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));

                for (int i = 0; i < filesCount; i++)
                {
                    doneEvents[i] = new ManualResetEvent(false);
                    LocateMsiWorkerArea locateMsiWorkerArea = new LocateMsiWorkerArea(fileData[i].Path, doneEvents[i]);
                    locateMsiWorkerArea.InstallGuid = this.ApplicationGuid;
                    locateMsiWorkerAreaArray[i] = locateMsiWorkerArea;
                    ThreadPool.QueueUserWorkItem(locateMsiWorkerArea.ThreadPoolCallback, i);
                    locateMsiWorkerArea.Completed += locateMsiWorkerArea_Completed;
                }

                /*var res = from c in class1Array.AsParallel().WithDegreeOfParallelism(5)
                          where c.Result
                          select c.MSIPath;*/
                List<ManualResetEvent[]> listDoneEvent = new List<ManualResetEvent[]>();

                int lengthToSplit = 64; // 64 is maximun number of events allowed for Wait handle
                int arrayLength = doneEvents.Length;

                for (int i = 0; i < arrayLength; i = i + lengthToSplit)
                {
                    ManualResetEvent[] val = new ManualResetEvent[lengthToSplit];

                    if (arrayLength < i + lengthToSplit)
                    {
                        lengthToSplit = arrayLength - i;
                    }
                    Array.Copy(doneEvents, i, val, 0, lengthToSplit);
                    listDoneEvent.Add(val.Where(x => x != null).ToArray());
                }
                foreach (ManualResetEvent[] item in listDoneEvent)
                {
                    WaitHandle.WaitAll(item);
                }
                for (int i = 0; i < filesCount; i++)
                {
                    if (locateMsiWorkerAreaArray[i].Result)
                        appMsis.Add(fileData[i].Path);
                }

            }
            catch (Exception exe)
            {
                DisplayError(exe);
            }
            finally
            {

            }
        }

        void locateMsiWorkerArea_Completed(object sender, LocateMsiWorkerArea.CompletedEventArgs e)
        {
            try
            {
                backgroundWorkerIndex++;
                int p = backgroundWorkerIndex * 100 / filesCount;
                backgroundWorker1.ReportProgress(p);
            }
            catch (Exception ex)
            {
               // DisplayError(ex);
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

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            this.Text = String.Format("Locating packages...{0} %. Please wait.", e.ProgressPercentage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (appMsis.Count == 0)
            {
                DisplayError(string.Format("Can not locate msi for the seleted application at the specified location. \r\n"));
                return;
            }
            foreach (var item in appMsis)
            {
                Process.Start("explorer.exe", string.Format("/select, \"{0}\"", item));
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please select Msi repositiory.");
            }
            else
            {
                if (backgroundWorker1.IsBusy)
                {
                    return;
                }
                button1.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                appMsis = new List<string>();
                backgroundWorkerIndex = 0;
                this.Text = String.Format("Locating packages...{0} %. Please wait.", "0", appMsis.Count);
                progressBar1.Value = 1;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text = String.Format("Done locating packages. Found {0} package(s).", appMsis.Count);
            this.Cursor = Cursors.Default;
            button1.Enabled = true;
        }

        private void LocateMsi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                DialogResult result = DisplayQuestion("Search still executing. Do you want to close ?");
                e.Cancel = (result == DialogResult.Cancel);
            }
        }

        private DialogResult DisplayQuestion(string message)
        {
            return MessageBox.Show(message, "BTDT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



    }
}
