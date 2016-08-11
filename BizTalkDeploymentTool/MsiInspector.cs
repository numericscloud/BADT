using BizTalkDeploymentTool.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace BizTalkDeploymentTool
{
    public partial class MsiInspector : Form
    {

        string appName;
        MsiPackage misPackage;
        public MsiInspector()
        {
            InitializeComponent();
        }

        private void BuildTreeView()
        {

            TreeNode appNameNode = new System.Windows.Forms.TreeNode("Name");
            appNameNode.Text = appName;
            TreeNode[] resourcesNodes = new TreeNode[misPackage.ResourcesCount];
            for (int i = 0; i < misPackage.Resources.Count; i++)
            {
                TreeNode treeNodeResource = new System.Windows.Forms.TreeNode(misPackage.Resources[i]);
                treeNodeResource.Text = misPackage.Resources[i];
                resourcesNodes[i] = treeNodeResource;
            }
            TreeNode resorcesNode = new System.Windows.Forms.TreeNode("Resources", resourcesNodes);
            TreeNode msiNode = new System.Windows.Forms.TreeNode("Msi", new TreeNode[] {
            appNameNode,
            resorcesNode});

            this.treeView1.Nodes.Add(msiNode);
            this.treeView1.ExpandAll();
            this.treeView1.SelectedNode = msiNode;
            this.treeView1.Focus();
        }

        private void btnBrowseMSI_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string msiToInspect = openFileDialog1.FileName;
                try
                {
                    LoadMsiPackage(msiToInspect);
                    BuildTreeView();
                }
                catch (Exception exe)
                {
                    DisplayError(exe);
                }
            }
        }

        private void LoadMsiPackage(string msiToInspect)
        {
            //listViewMsiInspector.Items.Clear();
            this.treeView1.Nodes.Clear();
            LoadMsi(msiToInspect);
        }
        private void LoadMsi(string msiToInspect)
        {
            misPackage = new MsiPackage(msiToInspect);

            txtMSILocation.Text = msiToInspect;
            appName = misPackage.DisplayName;
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null)
                {
                    string selectedNodeText = treeView1.SelectedNode.Text;

                    if (selectedNodeText == "Msi")
                    {
                        LoadMsiDBProperty();
                    }
                    else if (selectedNodeText == appName)
                    {
                        LoadMsiProperty();
                    }
                    else
                    {
                        LoadResourceProperties(selectedNodeText);
                    }

                }
            }
            catch (Exception exe)
            {

                DisplayError(exe);
            }
        }

        private void MsiInspector_Load(object sender, EventArgs e)
        {
            string msiToInspect = (string)this.Tag;
            if (!string.IsNullOrEmpty(msiToInspect))
            {
                LoadMsiPackage(msiToInspect);
                BuildTreeView();
            }
        }

        private void LoadMsiDBProperty()
        {
            PropertyClass myProp = new PropertyClass();

            CustomProperty myproperty = new CustomProperty("Installation Guid", misPackage.GetMsiProperty("ProductCode"), true, true);
            myProp.Add(myproperty);
            propertyGrid1.SelectedObject = myProp;
            //LoadListView("Installation Guid", misPackage.GetMsiProperty("ProductCode"));
        }
        private void LoadMsiProperty()
        {
            propertyGrid1.SelectedObject = misPackage;
        }

        private void LoadResourceProperties(string resource)
        {
            PropertyClass myProp = new PropertyClass();
            foreach (var item in misPackage.GetResourceProperties(resource))
            {
                CustomProperty myproperty = new CustomProperty(item.Key, item.Value, true, true);
                myProp.Add(myproperty);
            }
            propertyGrid1.SelectedObject = myProp;
        }

        private void LoadListView(string propertyName, string propertyValue)
        {
            ListViewItem listViewItem = new ListViewItem(new string[] { propertyName, propertyValue });
            listViewItem.SubItems[0].ForeColor = Color.SteelBlue;
            listViewItem.SubItems[0].Font = new Font(lblMsiLoc.Font.Name, lblMsiLoc.Font.Size, FontStyle.Bold);
            //listViewMsiInspector.Items.Add(listViewItem);
        }

        private void copyToClipBoard()
        {
            /* var selection = new StringBuilder();
             foreach (ListViewItem item in listViewMsiInspector.SelectedItems)
             {
                 selection.AppendLine(item.SubItems[1].Text);
             }
             Clipboard.SetText(selection.ToString());*/
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* if (sender != listViewMsiInspector) return;
             if (e.KeyChar == (char)3)
             {
                 copyToClipBoard();
             }*/
        }

        private void DisplayError(Exception ex)
        {
            DisplayError(ex.Message);
        }

        private void DisplayError(string message)
        {
            MessageBox.Show(message, "BTDT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MsiInspector_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}

