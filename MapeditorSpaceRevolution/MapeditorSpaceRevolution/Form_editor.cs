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
        public List<mapdata> terkepek = new List<mapdata>();
        public int selectedlevel = 0;
        public int selectedtileindex = 0;
        public PictureBox[,] editarea = new PictureBox[32,24];
        public List<Image> tileassets = new List<Image>();
        public List<PictureBox> tileselecttiles = new List<PictureBox>();
        


        public Form_editor()
        {
            InitializeComponent();
            initEditArea();
            seteditwinsize();
            label_levelname.Text = "";
            splitContainer2.Panel2.AutoScroll = true;
            drawimg();
        }

        private void Form_editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadsavepoopper.SavFileAs();
            saveMapData();
        }

        private void loadMapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadsavepoopper.LoaFile();
            loadMapData();
        }

        private void loadTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadsavepoopper.LoadTileDialog();
            loadTileData();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadsavepoopper.progEnd();
        }

        private void loadMapData()
        {
            terkepek.Clear();
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
                        int entitityindex = terkepek[mapindex].entities.Count();
                        if (sor == "--" || sr.EndOfStream) break;
                        else
                        {
                            string[] darabsor = sor.Split(';');

                            terkepek[mapindex].entities.Add(new entitydata());
                            terkepek[mapindex].entities[entitityindex].entid = int.Parse(darabsor[0]);
                            terkepek[mapindex].entities[entitityindex].xcoord = int.Parse(darabsor[1]);
                            terkepek[mapindex].entities[entitityindex].ycoord = int.Parse(darabsor[2]);
                        }
                    }
                }
                sr.Close();
                label_levelname.Text = (selectedlevel + 1) + ". Level: " + terkepek[selectedlevel].name;
                drawimg();
            }

        }

        private void saveMapData()
        {
            string path = loadsavepoopper.mapFilePath;
            if (File.Exists(path)) File.Delete(path);
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < terkepek.Count(); i++)
                {
                    sw.WriteLine(terkepek[i].name);
                    for (int j = 0; j < 24; j++)
                    {
                        for (int k = 0; k < 32; k++)
                        {
                            sw.Write(terkepek[i].tiledata[j, k]);
                            if (k != 31) sw.Write(";");
                            if(k==31) sw.WriteLine();
                        }
                    }
                    for (int l = 0; l < terkepek[i].entities.Count(); l++)
                    {
                        sw.WriteLine(terkepek[i].entities[l].entid + ";" + terkepek[i].entities[l].xcoord + ";" + terkepek[i].entities[l].ycoord);
                    }
                    sw.WriteLine("--");
                }
                sw.Close();
            }
        }

        private void loadTileData()
        {
            tileassets.Clear();
            Bitmap tilefile = new Bitmap(loadsavepoopper.tileFilePath);
            for (int j = 0; j < tilefile.Height; j += 32)
            {
                for (int i = 0; i < tilefile.Width; i+=32)
            {
                    Rectangle cutframe = new Rectangle(i, j, 32, 32);
                    tileassets.Add((Bitmap)tilefile.Clone(cutframe, tilefile.PixelFormat));
                }
            }
            displayEditorBoxes();
            drawimg();
        }

        private void displayEditorBoxes()
        {
            tileselecttiles.Clear();
            int darab = tileassets.Count();
            for (int i = 0; i < darab; i++)
            {
                PictureBox pictbox = new PictureBox();
                pictbox.Parent = splitContainer2.Panel2;
                pictbox.Width = 32;
                pictbox.Height = 32;
                pictbox.Location = new Point((i%4 * 32) + i % 4+ 1, (i/4 * 32) + i / 4  + 1);
                pictbox.BackColor = Color.Black;
                pictbox.Click += new EventHandler(editorwindowTileClick);
                pictbox.Tag = i;
                pictbox.Image = tileassets[i];
                tileselecttiles.Add(pictbox);
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
            splitContainer1.SplitterDistance = 32 * 4+20;
        }
        private void initEditArea()
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    editarea[j, i] = new PictureBox();
                    editarea[j, i].Parent = splitContainer1.Panel2;
                    editarea[j, i].Width = 32;
                    editarea[j, i].Height = 32;
                    editarea[j, i].Location = new Point((j * 32) + j + 1, (i * 32) + i + 1);
                    editarea[j, i].BackColor = Color.Black;
                    editarea[j, i].Click += new EventHandler(editTileClick);
                    editarea[j, i].Tag = i + ";" + j;
                }
            }
        }

        private void drawimg()
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (tileassets.Count!=0 && terkepek.Count!=0)
                    {
                        editarea[j, i].Image = (Image)tileassets[(terkepek[selectedlevel].tiledata[i, j]-1)];
                    }
                }
            }
        }

        private void editTileClick(object sender, EventArgs e)
        {
            PictureBox item = (PictureBox)sender;
            item.Image = (Image)tileassets[selectedtileindex];
            string[] itemtag = item.Tag.ToString().Split(';');
            terkepek[selectedlevel].tiledata[int.Parse(itemtag[0]), int.Parse(itemtag[1])] =selectedtileindex+1;
            drawimg();
        }

        private void editorwindowTileClick(object sender, EventArgs e)
        {
            PictureBox item = (PictureBox)sender;
            selectedtileindex = int.Parse(item.Tag.ToString());
            drawimg();
        }

        public class entitydata
        {
            public int entid;
            public int xcoord;
            public int ycoord;
        }

        public class mapdata
        {
            public string name;
            public int[,] tiledata = new int[24, 32];
            public List<entitydata> entities = new List<entitydata>();
        }
        

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveMapData();
        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            if (terkepek.Count != 0)
            {
                if (selectedlevel > 0) selectedlevel--;
                label_levelname.Text = (selectedlevel + 1) + ". Level: " + terkepek[selectedlevel].name;
            }
            drawimg();
        }

        private void button_nextmap_Click(object sender, EventArgs e)
        {
            if (terkepek.Count != 0)
            {
                if (selectedlevel < terkepek.Count()-1) selectedlevel++;
                label_levelname.Text = (selectedlevel + 1) + ". Level: " + terkepek[selectedlevel].name;
            }
            drawimg();
        }
    }
}
