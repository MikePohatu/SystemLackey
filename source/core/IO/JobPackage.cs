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
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Xml.Linq;
using SystemLackey.Tasks;
using SystemLackey.Messaging;

namespace SystemLackey.IO
{
    public class JobPackage: MessageForwarder
    {
        private Job root;
        private string workingPath;
        private string tasksPath;
        private string defaultPath = IOConfiguration.WorkingPath;
        private string pathToZip;

        private Dictionary<string,ITask> taskDictionary = new Dictionary<string,ITask>();
        private Dictionary<string, ITask> jobDictionary = new Dictionary<string, ITask>();

        // Constructors
        public JobPackage(Job pJob)
        {
            this.root = pJob;
        }

        public JobPackage(string pPathToZip)
        {
            this.pathToZip = pPathToZip;
        }

        //save to the default location
        public bool Save()
        {
            if (this.defaultPath != null)
            { 
                string zipFilePath = this.defaultPath + @"\" + root.Name + @".zip";
                return this.Save(zipFilePath);
            }
            else
            { return false; }
            
        }

        //save to a specific path
        public bool Save(string pPathToZip)
        {
            this.SendMessage(this, new MessageEventArgs("Saving pacakge file: " + pPathToZip, 0));

            bool overwrite = false;
            this.workingPath = Path.GetDirectoryName(pPathToZip) + @"\" + this.root.ID;
            this.tasksPath = workingPath + @"\Tasks";

            this.SendMessage(this, new MessageEventArgs("Working path: " + this.workingPath, 0));
            this.SendMessage(this, new MessageEventArgs("Tasks path: " + this.tasksPath, 0));

            if (!(Directory.Exists(tasksPath))) 
            {
                Directory.CreateDirectory(tasksPath); 
            }

            //cleanup and existing file
            if (File.Exists(pPathToZip))
            { 
                overwrite = true;
                File.Delete(pPathToZip);
            }

            //write the root.xml
            XElement rootXml = new XElement("Root",new XElement("ID", this.root.ID));
            XmlHandler handler = new XmlHandler();
            handler.Write(this.workingPath + @"\root.xml", rootXml);

            foreach (KeyValuePair<string, ITask> pair in root.GetTasks())
            {
                handler.Write(this.tasksPath + @"\" + pair.Key + ".xml", pair.Value.GetXml());
                if (pair.Value is IContentTask)
                {
                    IContentTask contentTask = (IContentTask)pair.Value;
                    if (contentTask.ContentPath != null) { FolderOperations.Copy(contentTask.ContentPath, this.tasksPath + @"\" + contentTask.ID); }              
                }
            }

            ZipFile.CreateFromDirectory(this.workingPath, pPathToZip);
            Directory.Delete(this.workingPath,true);

            return overwrite;
        }


        public Job Open()
        {
            if (this.pathToZip != null)
            { return this.Open(this.pathToZip); }
            else
            { throw new FileNotFoundException("JobPackage has no pathToZip set"); }
            
        }



        //open a zip file and spit out the job
        public Job Open(string pZipPath)
        {
            this.SendMessage(this, new MessageEventArgs("Opening pacakge file: " + pZipPath, 0));

            this.workingPath = Path.GetDirectoryName(pZipPath) + @"\" + Path.GetFileNameWithoutExtension(pZipPath);
            this.tasksPath = workingPath + @"\Tasks";

            this.SendMessage(this, new MessageEventArgs("Working path: " + this.workingPath, 0));
            this.SendMessage(this, new MessageEventArgs("Tasks path: " + this.tasksPath, 0));

            if (!(File.Exists(pZipPath))) { throw new FileNotFoundException("File not found: " + pZipPath); }
            //if (!(Directory.Exists(this.parentPath))) { throw new DirectoryNotFoundException("Directory not found: " + parentPath); }

            Directory.CreateDirectory(this.workingPath);
            ZipFile.ExtractToDirectory(pZipPath, this.workingPath);  //extract the zip

            //package format checking
            if (!(File.Exists(this.workingPath + @"\root.xml"))) { throw new FileNotFoundException("Root.xml not found in archive"); }
            if (!(Directory.Exists(this.tasksPath))) { throw new DirectoryNotFoundException("Tasks folder not found in archive"); }

            Job root = new Job();
            XmlHandler handler = new XmlHandler();
            TaskFactory factory = new TaskFactory();
            
            XElement rootXml = handler.Read(this.workingPath + @"\root.xml");
            string rootID = rootXml.Element("ID").Value; 

            //root.BuildTreeFromXml(handler.Read(tempFolder + @"\root.xml"),false);

            factory.SendMessageEvent += this.ForwardMessage;

            //now enumerate all the xml files in the folder and import them
            foreach (string filePath in Directory.GetFiles(this.tasksPath,"*.xml"))
            {
                if (File.Exists(filePath))
                {
                    Debug.WriteLine("Loading filePath: " + filePath);
                    this.SendMessage(this, new MessageEventArgs("Loading file: " + filePath, 1));
                    ITask newTask = factory.Create(handler.Read(filePath), false);
                    taskDictionary.Add(newTask.ID, newTask);
                }

                else
                { throw new FileNotFoundException("File not found: " + filePath); }
                

                //If is a job, add it to the job dictionary as well
                //the jobs will be populated after all tasks are imported
                //if (newTask is Job) { jobDictionary.Add(newTask.ID, newTask); }
            }

            factory.SendMessageEvent -= this.ForwardMessage;

            ITask t;

            foreach (string key in this.taskDictionary.Keys)
            {
                Debug.WriteLine(key);
                if (this.jobDictionary.TryGetValue(key,out t))
                { Debug.WriteLine(t.ID); }
                
            }

            
            if (taskDictionary.TryGetValue(rootID,out t))
            { this.root = (Job)t; }
            else
            { throw new FileNotFoundException("Task not found in dictionary: " + rootID); }

            this.root.Populate(taskDictionary);

            //rename the folder to the guid of the root job
            //Directory.Move(tempFolder, defaultPath + @"\" + root.ID);
            //this.workingPath = defaultPath + @"\" + root.ID;

            return root;
        }


    }
}
