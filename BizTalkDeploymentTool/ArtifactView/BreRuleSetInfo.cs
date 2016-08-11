using BizTalkDeploymentTool.Helpers;
using Microsoft.RuleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkDeploymentTool.ArtifactView
{
    public class BreRuleSetInfo
    {
        //public RuleSetInfo ruleSetInfo { get; set; }

        private RuleSetInfo _ruleSetInfo;
        private string _Description;
        private int _MajorRevision;
        private int _MinorRevision;
        private string _ModifiedBy;
        private DateTime _ModifiedTime;
        private string _Name;
        private bool _Published;
        private string _XmlContent;

        public BreRuleSetInfo(RuleSetInfo ruleSetInfo)
        {
            this._ruleSetInfo = ruleSetInfo;
        }


        public string Description
        {
            get
            {
                if (_Description == null)
                {
                    _Description = this._ruleSetInfo.Description;
                }
                return _Description;
            }
        }
        public int MajorRevision
        {
            get
            {
                _MajorRevision = this._ruleSetInfo.MajorRevision;
                return _MajorRevision;
            }
        }
        public int MinorRevision
        {
            get
            {
                _MinorRevision = this._ruleSetInfo.MinorRevision;
                return _MinorRevision;
            }
        }
        public string ModifiedBy
        {
            get
            {
                if (_ModifiedBy == null)
                {
                    _ModifiedBy = this._ruleSetInfo.ModifiedBy;
                }
                return _ModifiedBy;
            }
        }
        public DateTime ModifiedTime
        {
            get
            {
                if (_ModifiedTime == null)
                {
                    _ModifiedTime = this._ruleSetInfo.ModifiedTime;
                }
                return _ModifiedTime;
            }
        }
        public string Name
        {
            get
            {
                if (_Name == null)
                {
                    _Name = this._ruleSetInfo.Name;
                }
                return _Name;
            }
        }
        public bool Published
        {
            get
            {
                _Published = this._ruleSetInfo.Published;
                return _Published;
            }
        }


        public string XmlContent
        {
            get
            {
                if (_XmlContent == null)
                {
                    _XmlContent = BreHelper.GetRules(this._ruleSetInfo);
                }
                return _XmlContent;
            }
        }
    }
}
