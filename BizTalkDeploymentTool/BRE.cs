using BizTalkDeploymentTool.Actions;
using BizTalkDeploymentTool.Helpers;
using Microsoft.RuleEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BizTalkDeploymentTool
{
    public partial class BRE : Form
    {
        public BRE()
        {
            InitializeComponent();
        }

        private void BRE_Load(object sender, EventArgs e)
        {
            LoadPoliciesAndVocabularies();
        }

        private void LoadPoliciesAndVocabularies()
        {
            treeView1.Nodes.Clear();
            TreeNode parentNode = treeView1.Nodes.Add("BRE");
            TreeNode policiesNode = parentNode.Nodes.Add("Policies");
            TreeNode vocabulariesNode = parentNode.Nodes.Add("Vocabularies");
            TreeNode nodePublishedPolicy = policiesNode.Nodes.Add("Published");
            TreeNode nodeDeployedPolicy = policiesNode.Nodes.Add("Deployed");
            RuleSetInfoCollection ruleSetCollectionPublished = BizTalkDeploymentTool.Helpers.BreHelper.GetPublishedUndeployedRuleSets();
            RuleSetInfoCollection ruleSetCollectionDeployed = BizTalkDeploymentTool.Helpers.BreHelper.GetDeployedRuleSets();
            foreach (RuleSetInfo item in ruleSetCollectionPublished)
            {
                TreeNode node = nodePublishedPolicy.Nodes.Add(string.Format("{0} {1}.{2}", item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString()));
                node.Tag = BreActionFactory.CreateDeployActions(item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString());

            }

            foreach (RuleSetInfo item in ruleSetCollectionDeployed)
            {
                TreeNode node = nodeDeployedPolicy.Nodes.Add(string.Format("{0} {1}.{2}", item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString()));
                node.Tag = BreActionFactory.CreateUnDeployActions(item.Name, item.MajorRevision.ToString(), item.MinorRevision.ToString());               

            }

           /* foreach (var ruleSets in BreHelper.GetPublishedUndeployedRuleSets())
            {
                TreeNode node = treeView1.Nodes[0].Nodes.Add(ruleSets);
                node.ImageIndex = 4;
                node.SelectedImageIndex = 4;
                TreeNode appPool = node.Nodes.Add("Application Pools");
                appPool.ImageIndex = 1;
                appPool.SelectedImageIndex = 1;
                appPool.ContextMenuStrip = contextMenuStripServer;
                foreach (Microsoft.Web.Administration.ApplicationPool item in IISHelper.GetAppPools(server))
                {
                    TreeNode pool = appPool.Nodes.Add(item.Name);
                    pool.ImageIndex = 1;
                    pool.SelectedImageIndex = 1;
                    pool.Tag = item;
                }
                foreach (var item in IISHelper.GetSites(server))
                {
                    TreeNode nodeSites = node.Nodes.Add(item);
                    nodeSites.ImageIndex = 2;
                    nodeSites.SelectedImageIndex = 2;
                    nodeSites.ContextMenuStrip = contextMenuStripWebSite;
                    foreach (var application in IISHelper.GetSiteAppList(item))
                    {
                        TreeNode applicationNode = nodeSites.Nodes.Add(application);
                        applicationNode.ImageIndex = 3;
                        applicationNode.SelectedImageIndex = 3;
                        applicationNode.ContextMenuStrip = contextMenuStripDeletApp;
                    }
                }
            }*/
        }
    }
}
