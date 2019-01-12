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
    public partial class Form_neworload : Form
    {

        public Form_neworload()
        {
            InitializeComponent();
        }

        private void button_newmap_Click(object sender, EventArgs e)
        {
            loadsavepoopper.SavFileAs();
            loadsavepoopper.LoadTileDialog();
            Form_editor editorWindow = new Form_editor();
            editorWindow.Show();
            this.Hide();
        }
       

        private void button_loadmap_Click(object sender, EventArgs e)
        {
            loadsavepoopper.LoaFile();
            loadsavepoopper.LoadTileDialog();
            Form_editor editorWindow = new Form_editor();
            editorWindow.Show();
            this.Hide();
        }

    }

}
