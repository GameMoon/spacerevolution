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
    public class mapdata
    {
        public string name;
        public int[,] tiledata;
        public int[,] entitydata;
    }

    public partial class Form_editor : Form
    {
        public List<mapdata> terkepek = new List<mapdata>();

        public Form_editor()
        {
            InitializeComponent();
            seteditwinsize();


            //dataGridView_mapdata.i
            /*loadsavepoopper.mapFilePath;
            loadsavepoopper.tileFilePath;*/
            //loadMapData();
            drawimg();
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
                while (!sr.EndOfStream)
                {
                    int mapindex = terkepek.Count();
                    terkepek.Add(new mapdata());
                    terkepek[mapindex].name = sr.ReadLine();
                    for (int i = 0; i < 24; i++)
                    {
                        string[] besor = sr.ReadLine().Split(';');
                        for (int j = 0; j < 32; j++)
                        {
                            terkepek[mapindex].tiledata[i, j] = int.Parse(besor[j]);
                        }

                    }
                    while (true)
                    {
                        string sor = sr.ReadLine();
                        int entitityindex = 0;
                        if (sor == "--") break;
                        else
                        {
                            string[] darabsor = sor.Split(';');
                            for (int i = 0; i < 3; i++)
                            {
                                terkepek[mapindex].entitydata[entitityindex, i] = int.Parse(darabsor[i]);
                            }
                        }
                    }
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
           /* dataGridView_mapdata.Width = splitContainer1.Panel2.Width - 9;
            dataGridView_mapdata.Height = splitContainer1.Panel2.Height - 9;
            dataGridView_tiles.Width = splitContainer1.Panel1.Width - 9;
            dataGridView_tiles.Height = splitContainer1.Panel1.Height - 9;*/
        }
        private void drawimg()
        {
            //System.Drawing.Image.FromFile(loadsavepoopper.tileFilePath);
        }
    }
}
