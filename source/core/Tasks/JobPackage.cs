//    JobPackage.cs: Functionality for saving and opening a job and associated 
//                      files to a zip file package
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
using System.IO.Compression;
using System.Xml.Linq;
using SystemLackey.IO;

namespace SystemLackey.Tasks
{
    public class JobPackage
    {
        private Job parentJob;
        private string workingPath;
        private string parentPath;

        public JobPackage(Job pJob, string pParentPath)
        {
            this.parentJob = pJob;
            this.parentPath = pParentPath;
            this.workingPath = parentPath + @"\" + parentJob.ID;
        }

        public JobPackage(XElement pJobXml, string pParentPath)
        {
            this.parentJob = new Job();
            this.parentJob.OpenXml(pJobXml);

            this.parentPath = pParentPath;
            this.workingPath = parentPath + @"\" + parentJob.ID;
        }

        public JobPackage(string pJobPackageFile, string pParentPath)
        {
            this.parentPath = pParentPath;
            this.workingPath = parentPath + @"\" + parentJob.ID;
        }

        //save to the default location
        public bool Save()
        {
            string zipFilePath = this.parentPath + @"\" + parentJob.ID + @".zip";
            return this.Save(zipFilePath);
        }

        //save to a specific path
        public bool Save(string pPathToZip)
        {
            bool overwrite = false;

            if (!(Directory.Exists(this.workingPath))) 
            { 
                Directory.CreateDirectory(workingPath); 
            }

            //cleanup and existing file
            if (File.Exists(pPathToZip))
            { 
                overwrite = true;
                File.Delete(pPathToZip);
            }

            //write the root.xml
            XmlHandler handler = new XmlHandler();
            handler.Write(this.workingPath + @"\root.xml", this.parentJob.GetXml());

            ZipFile.CreateFromDirectory(this.workingPath, pPathToZip);
            return overwrite;
        }


        //open a zip file and spit out the job
        public Job Open(string pPath)
        {
            string tempGuid = new Guid().ToString();
            string tempFolder = this.parentPath + @"\" + tempGuid;

            if (!(File.Exists(pPath))) { throw new FileNotFoundException("File not found: " + pPath); }
            //if (!(Directory.Exists(this.parentPath))) { throw new DirectoryNotFoundException("Directory not found: " + parentPath); }

            Directory.CreateDirectory(tempFolder);
            ZipFile.ExtractToDirectory(pPath, tempFolder);

            if (!(File.Exists(tempFolder + @"\root.xml"))) { throw new FileNotFoundException("Root.xml not found in archive"); }

            Job root = new Job();
            XmlHandler handler = new XmlHandler();

            root.ImportXml(handler.Read(pPath));

            //rename the folder to the guid of the root job
            Directory.Move(tempFolder, parentPath + @"\" + parentJob.ID);
            this.workingPath = parentPath + @"\" + parentJob.ID;

            return root;
        }
    }
}
