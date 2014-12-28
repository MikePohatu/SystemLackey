using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SystemLackey.Worker;
using SystemLackey.Logging;

namespace SystemLackey.UI.Forms
{
    public partial class jbConsole : Form
    {
        Logger _logger;
        FormJobBuilder parent;

        public jbConsole(Logger pLogger)
        {
            _logger = pLogger;
            _logger.NewEvent += new LoggerEventHandler(Update);
            InitializeComponent();
        }

        // Properties
        public FormJobBuilder Parent
        {
            get { return this.parent; }
            set { this.parent = value; }
        }
        // /Properties

        public void Update(Object o, LoggerEventArgs e)
        {
            this.textOutput.Text += e.Text;
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logger.Level = 0;
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logger.Level = 1;
        }

        private void warningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logger.Level = 2;
        }

        private void errorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logger.Level = 3;
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Job rootJob = (Job)parent.Root.Tag;
            this.textOutput.Text += rootJob.GetXml();
        }
        
    }
}
