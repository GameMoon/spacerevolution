using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapeditorSpaceRevolution
{
    public partial class Form_editor : Form
    {
        public Form_editor()
        {
            InitializeComponent();
            dataGridView_mapdata.Width = splitContainer1.Panel2.Width;
            dataGridView_mapdata.Height = splitContainer1.Panel2.Height;
            /*loadsavepoopper.mapFilePath
            loadsavepoopper.tileFilePath;*/
            loadMapData();
        }

        private void Form_editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadsavepoopper.SavFileAs();
        }

        private void loadMapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadsavepoopper.LoaFile();
        }

        private void loadTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadsavepoopper.LoadTileDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadsavepoopper.progEnd();
        }

        private void loadMapData()
        {
            string path = loadsavepoopper.mapFilePath;
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();






                }
            }



        }

        private void splitContainer1_Panel1_SizeChanged(object sender, EventArgs e)
        {
            seteditwinsize();
        }

        private void Form_editor_Resize(object sender, EventArgs e)
        {
            seteditwinsize();
        }

        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            seteditwinsize();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            seteditwinsize();
        }

        private void seteditwinsize()
        {
            dataGridView_mapdata.Width = splitContainer1.Panel2.Width - 9;
            dataGridView_mapdata.Height = splitContainer1.Panel2.Height - 9;
            dataGridView_tiles.Width = splitContainer1.Panel1.Width - 9;
            dataGridView_tiles.Height = splitContainer1.Panel1.Height - 9;
        }
    }
}
