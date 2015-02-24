//    ContentPack.cs: Class to deal with files and folders for tasks
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
using SystemLackey.Messaging;

namespace SystemLackey.Tasks
{
    public class ContentPack: MessageSender
    {
        public string WorkingPath { get; set; }
        private string tempPath;
        private bool inEdit = false; //is the contentpack being edited

        public string ID { get; set; }

        public ContentPack(string pWorkingPath)
        {
            this.WorkingPath = pWorkingPath;
            this.ID = Guid.NewGuid().ToString();
            this.tempPath = Path.GetDirectoryName(this.WorkingPath) + @"\" + this.ID;           
        }

        public string StartEdit()
        {
            if (this.inEdit == true) { throw new InvalidOperationException("ContentPack already being edited"); }
            if (Directory.Exists(this.tempPath)) { throw new InvalidOperationException("Temp directory already exists"); }

            SystemLackey.IO.FolderOperations.Copy(this.WorkingPath, this.tempPath);

            this.inEdit = true;
            return tempPath;
        }

        //Finish. apply temp directory as the new working directory
        public bool FinishedEdit()
        {
            bool success = true;

            if (Directory.Exists(tempPath))
            {
                //replace the working dir with the temp one
                try
                {
                    this.SendMessage(this, new MessageEventArgs("Applying changes for ContentPack: " + this.ID, 0));
                    if (Directory.Exists(WorkingPath)) { Directory.Delete(this.WorkingPath, true); }
                    Directory.Move(this.tempPath, this.WorkingPath);
                }
                catch 
                {
                    success = false;
                    this.SendMessage(this, new MessageEventArgs("Failed to apply content changes to ContentPack: " + this.ID, 3)); 
                }
                
            }

            if (success == true) { this.inEdit = false; }

            return success;
        }


        //cancel and throw out the temp directory
        public bool CancelEdit()
        {
            bool success = true;
            //cleanup temp dir
            if (Directory.Exists(tempPath))
            {
                try
                { Directory.Delete(tempPath, true); }
                catch
                {
                    success = false;
                    this.SendMessage(this, new MessageEventArgs("Failed to delete temp directory: " + tempPath, 3)); 
                }           
            }

            if (success == true) { this.inEdit = false; }
            
            return success;
        }
    }
}
