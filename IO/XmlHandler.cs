using System;
using System.IO;
using System.Xml.Linq;

namespace SystemLackey.IO
{
    public class XmlHandler
    {
        public void Write(string pPath, XElement pElement)
        {
            XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),pElement);
            xDoc.Save(pPath);
        }

        public void Write(Stream pStream, XElement pElement)
        {
            XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),pElement);
            xDoc.Save(pStream);
        }

        public XElement Read(string pPath)
        {
            //LoadOptions options = new LoadOptions;
            //LoadOptions.PreserveWhitespace = true;
            return XElement.Load(pPath);
        }

        public XElement Read(Stream pStream)
        {
            return XElement.Load(pStream);
        }
    }
}
