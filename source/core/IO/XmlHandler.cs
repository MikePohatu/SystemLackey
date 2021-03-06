﻿//    XmlHandler.cs: Handles reading and writing of XML documents
//    Copyright (C) 2015 Mike Pohatu

//    This program is free software; you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation; version 2 of the License.

//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License along
//    with this program; if not, write to the Free Software Foundation, Inc.,
//    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

using System;
using System.IO;
using System.Xml.Linq;

namespace SystemLackey.Core.IO
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
