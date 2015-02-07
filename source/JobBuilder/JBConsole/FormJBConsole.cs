//    FormJbConsole.cs: The JobBuilder Console form for log viewing and diag tools
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using SystemLackey.Worker;
using SystemLackey.Messaging;

namespace SystemLackey.UI.Forms
{
    public partial class FormJBConsole : Form
    {
        private Logger _logger;
        private FormJobBuilder parent;

        private JBConsoleOptions options = new JBConsoleOptions();
        

        public FormJBConsole(Logger pLogger)
        {
            DateTime now = DateTime.Now;
            string time = now.ToString("u");

            _logger = pLogger;
            JBConsoleOptions startupOptions = new JBConsoleOptions();
            InitializeComponent();

            startupOptions.Debug = true;
            startupOptions.Info = true;
            startupOptions.Warning = true;
            startupOptions.Error = true;
            startupOptions.Danger = true;

            this.UpdateOptions(startupOptions);
            this.textOutput.Text = "Console started - " + time + Environment.NewLine;
        }

        // Properties
        public FormJobBuilder ParentJobBuilder
        {
            get { return this.parent; }
            set { this.parent = value; }
        }
        // /Properties

        private delegate void JbUpdateHandler(string s);

        //Method to deal with the events from the logger. Use invoke if running on 
        //another thread (which it should be)
        public void OutputMessage(Object sender, MessageEventArgs e)
        {
            if (textOutput.InvokeRequired)
            { textOutput.Invoke(new JbUpdateHandler(UpdateTextOutput), e.Text); }
            else
            { UpdateTextOutput(e.Text); }
            
        }

        //actually output the text to the screen
        private void UpdateTextOutput(string pText)
        { this.textOutput.Text += pText; }

        //Output the XML for the full job list
        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (parent.Root != null)
            {
                Job rootJob = (Job)parent.Root.Tag;
                this.textOutput.Text += rootJob.GetXml();
            }
            else
            {
                this.textOutput.Text += "There is currently no job" + Environment.NewLine;
            }
            
        }

        //Display console options form
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJBConsoleOptions consoleOptions = new FormJBConsoleOptions(this,options);
            consoleOptions.ShowDialog();
        }

        public void UpdateOptions(JBConsoleOptions pOptions)
        {
            string updateList = "";
            if ( options.Debug != pOptions.Debug )
            {
                updateList += "**Debug filter updated - Old: " + options.Debug + " New: " + pOptions.Debug + Environment.NewLine;
                if (pOptions.Debug)
                { _logger.EventDebug += new MessagingEventHandler(OutputMessage); }
                else
                { _logger.EventDebug -= new MessagingEventHandler(OutputMessage); }
            }

            if (options.Info != pOptions.Info)
            {
                updateList += "**Information filter updated - Old: " + options.Info + " New: " + pOptions.Info + Environment.NewLine;
                if (pOptions.Info)
                { _logger.EventInfo += new MessagingEventHandler(OutputMessage); }
                else
                { _logger.EventInfo -= new MessagingEventHandler(OutputMessage); }
            }

            if (options.Warning != pOptions.Warning)
            {
                updateList += "**Warning filter updated - Old: " + options.Warning + " New: " + pOptions.Warning + Environment.NewLine;
                if (pOptions.Warning)
                { _logger.EventWarning += new MessagingEventHandler(OutputMessage); }
                else
                { _logger.EventWarning -= new MessagingEventHandler(OutputMessage); }
            }

            if (options.Error != pOptions.Error)
            {
                updateList += "**Error filter updated - Old: " + options.Error + " New: " + pOptions.Error + Environment.NewLine;
                if (pOptions.Error)
                { _logger.EventError += new MessagingEventHandler(OutputMessage); }
                else
                { _logger.EventError -= new MessagingEventHandler(OutputMessage); }
            }

            if (options.Danger != pOptions.Danger)
            {
                updateList += "**Danger filter updated - Old: " + options.Danger + " New: " + pOptions.Danger + Environment.NewLine;
                if (pOptions.Danger)
                { _logger.EventDanger += new MessagingEventHandler(OutputMessage); }
                else
                { _logger.EventDanger -= new MessagingEventHandler(OutputMessage); }
            }

            //Output to the console that the filters have been updated. 
            this.textOutput.Text += updateList;
            options = pOptions;
        }

        //Console closing function
        private void FormJBConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            //deregister from any events. 
            if (options.Debug)
            { _logger.EventDebug -= new MessagingEventHandler(OutputMessage); }
            if (options.Info)
            { _logger.EventInfo -= new MessagingEventHandler(OutputMessage); }
            if (options.Warning)
            { _logger.EventWarning -= new MessagingEventHandler(OutputMessage); }
            if (options.Error)
            { _logger.EventError -= new MessagingEventHandler(OutputMessage); }
            if (options.Danger)
            { _logger.EventDanger -= new MessagingEventHandler(OutputMessage); }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textOutput.Text = "";
        }

        private void testForeachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Job j = (Job)parent.Root.Tag;
            this.textOutput.Text += "Job: " + j.Name + Environment.NewLine;

            foreach (Step s in j)
            {
                if (s == null) { Debug.WriteLine("Null value"); }
                Debug.WriteLine("Step: " + s.Task.Name + " " + s.Task.ID);
                this.textOutput.Text += "Step: " + s.Task.Name + " " + s.Task.ID +  Environment.NewLine;
            }
        }

        
    }
}
