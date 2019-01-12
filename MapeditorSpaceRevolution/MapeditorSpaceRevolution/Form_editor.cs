using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapeditorSpaceRevolution
{
    public partial class Form_editor : Form
    {
        public Form_editor()
        {
            InitializeComponent();
            /*Form_neworload.mapFilePath
            Form_neworload.tileFilePath;*/
        }

        private void Form_editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
