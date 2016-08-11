using BizTalkDeploymentTool.Global;
using Microsoft.BizTalk.ExplorerOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BizTalkDeploymentTool.Extensions;
using System.Collections;

namespace BizTalkDeploymentTool.ArtifactView
{
    public class PipelineInfo
    {
        public Pipeline _pipeline;
        private string _AssemblyQualifiedName;
        private string _Description;
        private string _FullName;
        private PipelineTrackingTypes _Tracking;
        private PipelineType _Type;

        public PipelineInfo(Pipeline pipeline)
        {
            _pipeline = pipeline;
        }


        public string AssemblyQualifiedName
        {
            get
            {
                if (string.IsNullOrEmpty(_AssemblyQualifiedName))
                {
                    _AssemblyQualifiedName = this._pipeline.AssemblyQualifiedName;
                }
                return _AssemblyQualifiedName;
            }
        }

        public string Description
        {
            get
            {
                if (string.IsNullOrEmpty(_Description))
                {
                    _Description = this._pipeline.Description;
                }
                return _Description;
            }
        }
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(_FullName))
                {
                    _FullName = this._pipeline.FullName;
                }
                return _FullName;
            }
        }
        public PipelineTrackingTypes Tracking
        {
            get
            {
                _Tracking = this._pipeline.Tracking;
                return _Tracking;
            }
        }
        public PipelineType Type
        {
            get
            {
                _Type = this._pipeline.Type;
                return _Type;
            }
        }

        /*  public string XmlContent
          {
              get
              {
                  if (string.IsNullOrEmpty(_XmlContent))
                  {
                     //_XmlContent = GetXmlContent(this._pipeline);
                  }
                  return _XmlContent;
              }
          }*/


    }
}
