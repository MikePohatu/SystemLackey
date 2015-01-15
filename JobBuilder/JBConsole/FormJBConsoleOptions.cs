using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemLackey.UI.Forms
{
    public partial class FormJBConsoleOptions : Form
    {
        private FormJBConsole parentForm;


        public FormJBConsoleOptions(FormJBConsole pParent,JBConsoleOptions pOptions)
        {
            InitializeComponent();
            parentForm = pParent;
            checkFilterInfo.Checked = pOptions.Info;
            checkFilterWarning.Checked = pOptions.Warning;
            checkFilterError.Checked = pOptions.Error;
            checkFilterDebug.Checked = pOptions.Debug;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            JBConsoleOptions options = new JBConsoleOptions();
            options.Info = checkFilterInfo.Checked;
            options.Warning = checkFilterWarning.Checked;
            options.Error = checkFilterError.Checked;
            options.Debug = checkFilterDebug.Checked;
            this.parentForm.UpdateOptions(options);
            this.Close();
        }
    }
}
