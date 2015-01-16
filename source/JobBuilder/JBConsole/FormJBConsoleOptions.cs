//    FormJBConsoleOptions.cs: JBConsole options window
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
