using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using BizTalkDeploymentTool.Extensions;
using BizTalkDeploymentTool.Actions;
using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.Wmi;
using BizTalkDeploymentTool.Report;
using BizTalkDeploymentTool.Global;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BizTalkDeploymentTool
{
    public partial class UserControl1 : UserControl
    {
        TreeNode _node = new TreeNode();
        public UserControl1()
        {
            InitializeComponent();
        }
        public UserControl1(TreeNode node)
        {
            _node = node;
            InitializeComponent();
            this.Dock = DockStyle.Fill;
           // propertyGridArtifacts.DoubleBuffered(true);
           // richTextBoxArtifactProperties.DoubleBuffered(true);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            ApplicationLoad appLoad = _node.Tag as ApplicationLoad;
            if (appLoad != null)
            {
                PopulatePropertyGrid(appLoad.Application);
            }
            else
            {
                PopulatePropertyGrid(_node.Tag);
            }
        }

         private void PopulatePropertyGrid(object obj)
        {
            if (obj != null)
            {
                TypeDescriptor.AddAttributes(obj, new Attribute[] { new ReadOnlyAttribute(true) });
            }
            propertyGridArtifacts.SelectedObject = obj;
        }

         private void propertyGridArtifacts_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
         {
             string text = "";//treeView1.SelectedNode.Text;
             if (e.OldSelection != null)
             {
                 GridItem selectedItem = propertyGridArtifacts.SelectedGridItem;
                 if (selectedItem != null && selectedItem.GridItemType == GridItemType.Property && selectedItem.Value != null)
                 {
                     text = selectedItem.Value.ToString();
                 }
             }

             richTextBoxArtifactProperties.Text = text;
             HighlightColors.HighlightRTF(richTextBoxArtifactProperties);
         }
    }
}
