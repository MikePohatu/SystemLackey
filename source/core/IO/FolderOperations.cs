//    FolderOperations.cs: Methods for manipulating folders
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

namespace SystemLackey.IO
{
    public static class FolderOperations
    {
        public static void Copy(string pSourcePath, string pDestPath)
        { 
            if (!Directory.Exists(pDestPath)) 
            {
                Directory.CreateDirectory(pDestPath);
            }

            CopyAll(pSourcePath, pDestPath);
        }

        private static void CopyAll(string pSourcePath, string pDestPath)
        { 
            foreach (string filePath in Directory.GetFiles(pSourcePath))
            {
                FileInfo fi = new FileInfo(filePath);
                File.Copy(filePath, pDestPath + @"\" + fi.Name,true);
            }

            foreach (string folderPath in Directory.GetDirectories(pSourcePath))
            {
                //recursively copy the subfolder
                DirectoryInfo di = new DirectoryInfo(folderPath);
                Copy(folderPath, pDestPath + @"\" + di.Name);
            }
        }
    }
}
