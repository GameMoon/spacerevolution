using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileMapEditor
{
    public partial class Form_editorWindow : Form
    {
        public static int tileGridWidth = 32;
        public static int tileGridHeigth = 24;

        public static int loadedLevel = 0;
        public static int selectedtileindex = 0;
        public static int selectedtilemodifier = 0;

        public Form_editorWindow()
        {
            InitializeComponent();
        }

        private void Form_editorWindow_Load(object sender, EventArgs e)
        {
            loadSavePopper.mapFilePath = "";
            loadSavePopper.tileFilePath = "";
            setUpInterface();
        }

        public void setUpInterface()
        {
            setUpEdit();
            label_levelCountNumber.Text = "";
            addLevelConditionTrue();
            loadSavePopper.savedSinceLastedit = true;
        }

        private void setUpEdit()
        {
            TileData.tileSetTiles.Clear();
            for (int j = 0; j < tileGridHeigth; j++)
            {
                for (int i = 0; i < tileGridWidth; i++)
                {
                    InterFaceElements.editarea[i, j] = new PictureBox();
                    InterFaceElements.editarea[i, j].Parent = splitContainer_Main.Panel2;
                    InterFaceElements.editarea[i, j].Width = 32;
                    InterFaceElements.editarea[i, j].Height = 32;
                    InterFaceElements.editarea[i, j].Location = new Point((i * 32) + i + 1, (j * 32) + j + 1);
                    InterFaceElements.editarea[i, j].BackColor = Color.Black;
                    InterFaceElements.editarea[i, j].Click += new EventHandler(MapSelectClick);
                    InterFaceElements.editarea[i, j].Tag = i + ";" + j;
                }
            }
        }


        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(loadSavePopper.SaveFileAsDialog()) FileIO.WriteFile();
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileIO.WriteFile();
        }

        private void saveMapAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(loadSavePopper.SaveFileAsDialog()) FileIO.WriteFile();
        }

        private void loadMapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(loadSavePopper.LoadMapFileDialog()) FileIO.ReadMapFile();
            reloadView();
        }

        private void loadTilesetFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadTileFile();
            reloadView();
        }

        private void ReadTileFile()
        {
            if (loadSavePopper.LoadTilesetDialog())
            {
                selectedtileindex = 0;
                Bitmap tilefile = new Bitmap(loadSavePopper.tileFilePath);
                if ((tilefile.Width % 32 == 0) && (tilefile.Height % 32 == 0))
                {
                    TileData.tileSetTiles.Clear();
                    for (int j = 0; j < tilefile.Height; j += 32)
                    {
                        for (int i = 0; i < tilefile.Width; i += 32)
                        {
                            Rectangle cutframe = new Rectangle(i, j, 32, 32);
                            TileData.tileSetTiles.Add((Bitmap)tilefile.Clone(cutframe, tilefile.PixelFormat));
                        }
                    }
                    displayTileselectBoxes();
                    pictureBox_previewTile.Image = TileData.tileSetTiles[selectedtileindex];
                }
                else MessageBox.Show("Bad Tilesize");
            }
        }

        public void displayTileselectBoxes()
        {
            InterFaceElements.tileSelectTiles.Clear();
            int darab = TileData.tileSetTiles.Count();
            for (int i = 0; i < darab; i++)
            {
                PictureBox pictbox = new PictureBox();
                pictbox.Parent = splitContainer_TileSelector.Panel2;
                pictbox.Width = 32;
                pictbox.Height = 32;
                pictbox.Location = new Point((i % 4 * 32) + i % 4 + 1, (i / 4 * 32) + i / 4 + 1);
                pictbox.BackColor = Color.Black;
                pictbox.Click += new EventHandler(SelectTileClick);
                pictbox.Tag = i;
                pictbox.Image = TileData.tileSetTiles[i];
                InterFaceElements.tileSelectTiles.Add(pictbox);
            }

        }

        private void reloadView()
        {
            if((MapData.LevelList.Count()>0) &&(MapData.LevelList.Count()>selectedtileindex))
            {
                label_levelCountNumber.Text = (loadedLevel + 1).ToString();
                textBox_LevelName.Text = MapData.LevelList[loadedLevel].name;
                for (int i = 0; i < tileGridHeigth; i++)
                {
                    for (int j = 0; j < tileGridWidth; j++)
                    {
                        if (TileData.tileSetTiles.Count() != 0)
                        {
                            /*FURCSA FOS*/
                            InterFaceElements.editarea[j, i].Image = TileData.tileSetTiles[(MapData.LevelList[loadedLevel].tiledata[j, i]) / 12];
                            int transformid= MapData.LevelList[loadedLevel].tiledata[j, i] % 12;
                            int sanitycheck = transformid;
                            if (sanitycheck < 4)
                            {
                                for (int l = 0; l < transformid; l++)
                                {
                                    InterFaceElements.editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                }
                            }
                            else if ((sanitycheck >= 4) && (transformid < 8))
                            {
                                transformid -= 4;
                                InterFaceElements.editarea[j, i].Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                for (int l = 0; l < transformid; l++)
                                {
                                    InterFaceElements.editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                }
                            }
                            else if ((sanitycheck >= 8) && (transformid < 12))
                            {
                                transformid -= 8;
                                InterFaceElements.editarea[j, i].Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                for (int l = 0; l < transformid; l++)
                                {
                                    InterFaceElements.editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                }
                            }
                            else MessageBox.Show("Error? TransformId: "+transformid);
                            InterFaceElements.editarea[j, i].Refresh();
                        }
                    }
                }
            }
        }
        
        private void SelectTileClick(object sender, EventArgs e)
        {
            selectedtilemodifier = 0;
            PictureBox item = (PictureBox)sender;
            selectedtileindex=int.Parse(item.Tag.ToString());
            pictureBox_previewTile.Image = TileData.tileSetTiles[selectedtileindex];
            /*IDE IS KELL*/
            
        }

        private void MapSelectClick(object sender, EventArgs e)
        {
            PictureBox item = (PictureBox)sender;
            string[] itemtag = item.Tag.ToString().Split(';');
            //MessageBox.Show(itemtag[0].ToString() + itemtag[1].ToString());
            InterFaceElements.editarea[int.Parse(itemtag[0]), int.Parse(itemtag[1])].Image=pictureBox_previewTile.Image;
            MapData.LevelList[loadedLevel].tiledata[int.Parse(itemtag[0]), int.Parse(itemtag[1])] = selectedtileindex * 12 + selectedtilemodifier;
            loadSavePopper.savedSinceLastedit = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadSavePopper.progEnd();
        }

        private void button_rotateLeft_Click(object sender, EventArgs e)
        {
            //dgsgsdgsd
            refPreview();
        }
        private void refPreview()
        {
            int transformid = selectedtilemodifier;
            int sanitycheck = transformid;
            if (sanitycheck < 4)
            {
                for (int l = 0; l < transformid; l++)
                {
                    pictureBox_previewTile.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            else if ((sanitycheck >= 4) && (transformid < 8))
            {
                transformid -= 4;
                pictureBox_previewTile.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                for (int l = 0; l < transformid; l++)
                {
                    pictureBox_previewTile.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            else if ((sanitycheck >= 8) && (transformid < 12))
            {
                transformid -= 8;
                pictureBox_previewTile.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                for (int l = 0; l < transformid; l++)
                {
                    pictureBox_previewTile.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            else MessageBox.Show("Error? TransformId: " + transformid);
            pictureBox_previewTile.Refresh();
        }

        private void button_rotateRight_Click(object sender, EventArgs e)
        {
            //dgsgsdgsdsel
            selectedtilemodifier++;
            if (selectedtilemodifier < 3) selectedtilemodifier -= 4;
            refPreview();
        }

        private void button_verticalMirror_Click(object sender, EventArgs e)
        {
            //dgsgsdgsd
            refPreview();
        }

        private void button_horizontalMirror_Click(object sender, EventArgs e)
        {
            //dgsgsdgsd
            refPreview();
        }

        private void button_nextLevel_Click(object sender, EventArgs e)
        {
            if (MapData.LevelList.Count() != 0)
            {
                if (loadedLevel < MapData.LevelList.Count() - 1) loadedLevel++;
            }
            reloadView();
        }

        private void button_prevLevel_Click(object sender, EventArgs e)
        {

            if (MapData.LevelList.Count() != 0)
            {
                if (loadedLevel > 0) loadedLevel--;
            }

            reloadView();
        }

        private void button_addLevel_Click(object sender, EventArgs e)
        {
            int levelCount = MapData.LevelList.Count();
            if ((levelCount == 0))
            {
                if(loadSavePopper.SaveFileAsDialog()) addLevelConditionTrue();
            }
            else addLevelConditionTrue();
            loadSavePopper.savedSinceLastedit = false;
        }

        private void addLevelConditionTrue()
        {
            int levelCount = MapData.LevelList.Count();
            MapData.LevelList.Add(new LevelData());
            MapData.LevelList[levelCount].name = "newlevel";
            for (int i = 0; i < tileGridWidth; i++)
            {
                for (int j = 0; j < tileGridHeigth; j++)
                {
                    MapData.LevelList[levelCount].tiledata[i, j] = 1;
                }
            }
            loadedLevel = levelCount;
            reloadView();
        }

        private void button_deleteLevel_Click(object sender, EventArgs e)
        {
            if (MapData.LevelList.Count > 1)
            {
                MapData.LevelList.RemoveAt(loadedLevel);
                if (loadedLevel > 0) loadedLevel--;
                reloadView();
                loadSavePopper.savedSinceLastedit = false;
            }
            else MessageBox.Show("You cannot delete the last level");
        }

        private void textBox_LevelName_TextChanged(object sender, EventArgs e)
        {
            if(MapData.LevelList.Count()!=0) MapData.LevelList[loadedLevel].name = textBox_LevelName.Text;
            loadSavePopper.savedSinceLastedit = false;
            reloadView();
        }

        private void Form_editorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel= !loadSavePopper.progEnd();
        }

    }
}
