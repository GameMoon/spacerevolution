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
    public partial class Form_neworload : Form
    {
        public static string mapFilePath;
        public static string tileFilePath;

        public Form_neworload()
        {
            InitializeComponent();
        }

        private void button_newmap_Click(object sender, EventArgs e)
        {
            SaveFileDialog newMapFile = new SaveFileDialog();
            newMapFile.Filter = "SR Map|*.srm";
            newMapFile.Title = "Create new SR map...";
            if (newMapFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mapFilePath = newMapFile.FileName;
            }

            OpenFileDialog openTileFile = new OpenFileDialog();
            openTileFile.Filter = "All Files|*.*";
            openTileFile.Title = "Select a Tileset File";

            if (openTileFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tileFilePath = openTileFile.FileName;
            }

            Form_editor editorWindow = new Form_editor();
            editorWindow.Show();
            this.Hide();
        }

        private void button_loadmap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openMapFile = new OpenFileDialog();
            openMapFile.Filter = "SR Map|*.srm|All Files|*.*";
            openMapFile.Title = "Select a Map File";

            if (openMapFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mapFilePath = openMapFile.FileName;
            }

            OpenFileDialog openTileFile = new OpenFileDialog();
            openTileFile.Filter = "All Files|*.*";
            openTileFile.Title = "Select a Tileset File";

            if (openTileFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tileFilePath = openTileFile.FileName;
            }

            Form_editor editorWindow = new Form_editor();
            editorWindow.Show();
            this.Hide();
        }

        public void progEnd()
        {
            Environment.Exit(0);
        }
    }


}
