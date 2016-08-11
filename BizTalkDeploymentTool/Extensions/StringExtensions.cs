using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace BizTalkDeploymentTool
{
    public static class StringExtensions
    {
        public static string TrimLastCharacter(this String str)
        {
            return str.Remove(str.Length - 1, 1);
        }
        public static string Encode(this string parameter)
        {
            return string.Format("\"{0}\"", parameter.Replace("\"", "\"\""));
        }

        public static MemoryStream DocumentXml(this String str)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resource = "BizTalkDeploymentTool.Resources.Defaultss.xslt";

            Stream s = assembly.GetManifestResourceStream(resource);

            XmlReader xr = XmlReader.Create(s);
            XslCompiledTransform xct = new XslCompiledTransform();
            xct.Load(xr);

            //StringBuilder sb = new StringBuilder();
            StringReader sr = new StringReader(str);
            XmlReader xReader = XmlReader.Create(sr);
           // XmlWriter xw = XmlWriter.Create(sb);
            MemoryStream ms = new MemoryStream();
            xct.Transform(xReader,null, ms);
            ms.Position = 0;
            return ms;
            //return sb.ToString();
        }
        public static bool IsXml(this String str)
        {
            try
            {
                var doc = XDocument.Parse(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
