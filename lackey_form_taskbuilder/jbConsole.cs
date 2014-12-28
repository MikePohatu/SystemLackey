using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SystemLackey.Logging;

namespace SystemLackey.UI.Forms
{
    public partial class jbConsole : Form
    {
        Logger _logger;

        public jbConsole(Logger pLogger)
        {
            _logger = pLogger;
            _logger.NewEvent += new LoggerEventHandler(Update);
            InitializeComponent();
        }

        public void Update(Object o, LoggerEventArgs e)
        {
            this.textOutput.Text += e.Text;
        }
        
    }
}
