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
        public int selectedlevel = 0;
        public int selectedtileindex = 0;
        public int selectedtiletransferindex = 0;
        public int transformkephozza = 0;
        public bool hortuk = false;
        public bool vertuk = false;
        public PictureBox[,] editarea = new PictureBox[32,24];
        public List<Image> tileassets = new List<Image>();
        public List<PictureBox> tileselecttiles = new List<PictureBox>();
        


        public Form_editor()
        {
            InitializeComponent();
            initEditArea();
            seteditwinsize();
            textBox_levelname.Text = "";
            label_levelcounter.Text = "";
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
<<<<<<< HEAD
                sr.Close();
                textBox_levelname.Text = terkepek[selectedlevel].name;
                label_levelcounter.Text = (selectedlevel + 1).ToString();
                drawimg();
=======

>>>>>>> parent of eed9584... Merge branch 'developement' of https://github.com/GameMoon/spacerevolution into developement
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
            Bitmap tilefile = new Bitmap(loadsavepoopper.tileFilePath);
            if ((tilefile.Width % 32 == 0) && (tilefile.Height % 32 == 0))
            {
                tileassets.Clear();
                for (int j = 0; j < tilefile.Height; j += 32)
                {
                    for (int i = 0; i < tilefile.Width; i += 32)
                    {
                        Rectangle cutframe = new Rectangle(i, j, 32, 32);
                        tileassets.Add((Bitmap)tilefile.Clone(cutframe, tilefile.PixelFormat));
                    }
                }
                displayEditorBoxes();
                drawimg();
            }
            else MessageBox.Show("Bad Tilesize");
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
        

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            seteditwinsize();
        }
  

        private void seteditwinsize()
        {
            splitContainer1.SplitterDistance = 148;
            splitContainer2.SplitterDistance = 100;
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
                        int transformid = (terkepek[selectedlevel].tiledata[i, j] % 12) - 1;
                        int tileid = ((terkepek[selectedlevel].tiledata[i, j] - (terkepek[selectedlevel].tiledata[i, j] % 12)) / 12);
                        editarea[j, i].Image = (Image)tileassets[tileid];
                        editarea[j, i].Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                        if (transformid == 0) editarea[j, i].Image.RotateFlip(RotateFlipType.RotateNoneFlipNone); 
                        else if (transformid == 1) editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        else if (transformid == 2) editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        else if (transformid == 3) editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        else if (transformid == 4) editarea[j, i].Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        else if (transformid == 5) editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                        else if (transformid == 6) editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                        else if (transformid == 7) editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate270FlipX);
                        else if (transformid == 8) editarea[j, i].Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        else if (transformid == 9) editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                        else if (transformid == 10) editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                        else if (transformid == 11) editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate270FlipY);
                        else MessageBox.Show("Whathappend"+transformid);
                        editarea[j, i].Refresh();
                    }
                }
            }
        }
<<<<<<< HEAD

        private void editTileClick(object sender, EventArgs e)
        {
            if ((terkepek.Count() != 0) && (tileassets.Count()!=0) )
            {
                PictureBox item = (PictureBox)sender;
                string[] itemtag = item.Tag.ToString().Split(';');
                selectedtiletransferindex = (selectedtileindex*12)+1+transformkephozza;
                terkepek[selectedlevel].tiledata[int.Parse(itemtag[0]), int.Parse(itemtag[1])] = selectedtiletransferindex;
                drawimg();
            }
        }

        private void editorwindowTileClick(object sender, EventArgs e)
        {
            PictureBox item = (PictureBox)sender;
            selectedtileindex = int.Parse(item.Tag.ToString());
            pictureBox_selectedtiletransfer.Image = (Image)tileassets[selectedtileindex];
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
                textBox_levelname.Text =terkepek[selectedlevel].name;
                label_levelcounter.Text = (selectedlevel + 1).ToString();
            }
            drawimg();
        }

        private void button_nextmap_Click(object sender, EventArgs e)
        {
            if (terkepek.Count != 0)
            {
                if (selectedlevel < terkepek.Count()-1) selectedlevel++;
                textBox_levelname.Text =terkepek[selectedlevel].name;
                label_levelcounter.Text = (selectedlevel+1).ToString();
            }
            drawimg();
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            seteditwinsize();
        }

        private void button_addlevel_Click(object sender, EventArgs e)
        {
            if (terkepek.Count() == 0)
            {
                loadsavepoopper.SavFileAs();
            }
            {
                int mapindex = terkepek.Count();
                terkepek.Add(new mapdata());
                terkepek[mapindex].name = "newlevel"+textBox_levelname.Text;
                for (int i = 0; i < 24; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        terkepek[mapindex].tiledata[i, j] = 1;
                    }

                }
                if (terkepek.Count != 0)
                {
                    if (selectedlevel < terkepek.Count() - 1) selectedlevel++;
                    textBox_levelname.Text = terkepek[selectedlevel].name;
                    label_levelcounter.Text = (selectedlevel + 1).ToString();
                }
                drawimg();
            }
            saveMapData();
        }

        private void textBox_levelname_TextChanged(object sender, EventArgs e)
        {
           terkepek[selectedlevel].name = textBox_levelname.Text;
        }

        private void korrigaltransosszeg()
        {
            int offset=0;
            if ((hortuk == false) && (vertuk == false)) offset = 4;
            else if ((hortuk == true) && (vertuk == false)) offset = 8;
            else if ((hortuk == false) && (vertuk == true)) offset = 12;




            if (transformkephozza>(offset-1)) transformkephozza -= 4;
            if (transformkephozza<(offset-4)) transformkephozza += 4;
        }

        private void transformpreview()
        {
            pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
            if (transformkephozza == 0) pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
            else if (transformkephozza == 1) pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            else if (transformkephozza == 2) pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            else if (transformkephozza == 3) pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            else if (transformkephozza == 4) pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            else if (transformkephozza == 5) pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
            else if (transformkephozza == 6) pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            else if (transformkephozza == 7) pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.Rotate270FlipX);
            else if (transformkephozza == 8) pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            else if (transformkephozza == 9) pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            else if (transformkephozza == 10) pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            else if (transformkephozza == 11) pictureBox_selectedtiletransfer.Image.RotateFlip(RotateFlipType.Rotate270FlipY);
            else MessageBox.Show("Whathappend"+transformkephozza);
            pictureBox_selectedtiletransfer.Refresh();
        }

        private void button_rotleft_Click(object sender, EventArgs e)
        {
            transformkephozza -= 1;
            korrigaltransosszeg();
            transformpreview();
            MessageBox.Show(transformkephozza.ToString());
        }

        private void button_rotright_Click(object sender, EventArgs e)
        {
            transformkephozza += 1;
            korrigaltransosszeg();
            transformpreview();
            MessageBox.Show(transformkephozza.ToString());
        }

        private void button_vertinvert_Click(object sender, EventArgs e)
        {
            if ((hortuk == false) && (vertuk == false)) vertuk=true;
            else if ((hortuk == false) && (vertuk == true)) vertuk=false;
            else if ((hortuk == true) && (vertuk == false))
            {
                hortuk = false;
                vertuk = true;
            }
            else if ((hortuk == true) && (vertuk == true))
            {
                hortuk = false;
                vertuk = false;
            }
            transformkephozza += 8;
            korrigaltransosszeg();
            transformpreview();
            MessageBox.Show(transformkephozza.ToString());
        }

        private void button_horinvert_Click(object sender, EventArgs e)
        {

            if ((vertuk == false) && (hortuk == false)) hortuk = true;
            else if ((vertuk == false) && (hortuk == true)) hortuk = false;
            else if ((vertuk == true) && (hortuk == false))
            {
                vertuk = false;
                hortuk = true;
            }
            else if ((vertuk == true) && (hortuk == true))
            {
                vertuk = false;
                hortuk = false;
            }
            transformkephozza += 4;
            korrigaltransosszeg();
            transformpreview();
            MessageBox.Show(transformkephozza.ToString());
        }
=======
>>>>>>> parent of eed9584... Merge branch 'developement' of https://github.com/GameMoon/spacerevolution into developement
    }
}
