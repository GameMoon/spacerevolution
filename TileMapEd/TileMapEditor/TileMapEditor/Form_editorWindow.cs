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
        public static int tileSizeInPixels = 32;

        public bool vertMir = false;
        public bool HorMir = false;
        public bool removemode = false;
        public bool addmode = false;
        public static int loadedLevel = 0;
        public static int selectedtileindex = 0;
        public static int selectedtilemodifier = 0;
        public static Image picboxImage;

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
                    InterFaceElements.editarea[i, j].Width = tileSizeInPixels;
                    InterFaceElements.editarea[i, j].Height = tileSizeInPixels;
                    InterFaceElements.editarea[i, j].Location = new Point((i * tileSizeInPixels) + i + 1, (j * tileSizeInPixels) + j + 1);
                    InterFaceElements.editarea[i, j].BackColor = Color.Black;
                    InterFaceElements.editarea[i, j].Tag = i + ";" + j;
                    InterFaceElements.editAreaLabels[i, j] = new Label();
                    InterFaceElements.editAreaLabels[i, j].Parent = InterFaceElements.editarea[i, j];
                    InterFaceElements.editAreaLabels[i, j].Width = tileSizeInPixels;
                    InterFaceElements.editAreaLabels[i, j].Height = tileSizeInPixels;
                    InterFaceElements.editAreaLabels[i, j].Text = "";
                    InterFaceElements.editAreaLabels[i, j].BackColor = Color.Transparent;
                    InterFaceElements.editAreaLabels[i, j].ForeColor = Color.OrangeRed;
                    InterFaceElements.editAreaLabels[i, j].Click += new EventHandler(MapSelectClickLabel);
                    InterFaceElements.editAreaLabels[i, j].Tag = i + ";" + j;
                }
            }
        }
        
        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(loadSavePopper.SaveFileAsDialog()) FileIO.WriteFile();
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FileIO.WriteFile()) loadSavePopper.savedSinceLastedit=true;
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
                if ((tilefile.Width % tileSizeInPixels == 0) && (tilefile.Height % tileSizeInPixels == 0))
                {
                    TileData.tileSetTiles.Clear();
                    for (int j = 0; j < tilefile.Height; j += tileSizeInPixels)
                    {
                        for (int i = 0; i < tilefile.Width; i += tileSizeInPixels)
                        {
                            Rectangle cutframe = new Rectangle(i, j, tileSizeInPixels, tileSizeInPixels);
                            TileData.tileSetTiles.Add((Bitmap)tilefile.Clone(cutframe, tilefile.PixelFormat));
                        }
                    }
                    displayTileselectBoxes();
                    pictureBox_previewTile.Image = TileData.tileSetTiles[selectedtileindex];
                    picboxImage = TileData.tileSetTiles[selectedtileindex];
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
                pictbox.Width = tileSizeInPixels;
                pictbox.Height = tileSizeInPixels;
                pictbox.Location = new Point((i % 4 * tileSizeInPixels) + i % 4 + 1, (i / 4 * tileSizeInPixels) + i / 4 + 1);
                pictbox.BackColor = Color.Black;
                pictbox.Click += new EventHandler(SelectTileClick);
                pictbox.Tag = i;
                pictbox.Image = TileData.tileSetTiles[i];
                InterFaceElements.tileSelectTiles.Add(pictbox);
            }

        }

        private void reloadView()
        {
            this.Text = "TileMapEditor " + loadSavePopper.mapFilePath;
            if((MapData.LevelList.Count()>0) &&(MapData.LevelList.Count()>loadedLevel))
            {
                label_levelCountNumber.Text = (loadedLevel + 1).ToString();
                textBox_LevelName.Text = MapData.LevelList[loadedLevel].name;
                for (int i = 0; i < tileGridHeigth; i++)
                {
                    for (int j = 0; j < tileGridWidth; j++)
                    {
                        if (TileData.tileSetTiles.Count() != 0)
                        {
                            Image koztes = TileData.tileSetTiles[MapData.LevelList[loadedLevel].tiledata[j, i] / 12];
                            InterFaceElements.editarea[j, i].Image = (Image)koztes.Clone();
                            InterFaceElements.editAreaLabels[j, i].Text = "";
                            for (int k = 0; k < MapData.LevelList[loadedLevel].entities.Count(); k++)
                            {
                                if ((MapData.LevelList[loadedLevel].entities[k].xcoord == j) && (MapData.LevelList[loadedLevel].entities[k].ycoord == i))
                                {
                                    InterFaceElements.editAreaLabels[j, i].Text = "Id:" + MapData.LevelList[loadedLevel].entities[k].entid.ToString() + "\nx" + (MapData.LevelList[loadedLevel].entities[k].xcoord + 1).ToString() + "y" + (MapData.LevelList[loadedLevel].entities[k].ycoord + 1).ToString();
                                }
                            }

                            int transformid= MapData.LevelList[loadedLevel].tiledata[j, i] % 12;
                            int sanitycheck = transformid;
                            if (sanitycheck < 4)
                            {
                                for (int l = 0; l < transformid; l++)
                                {
                                    InterFaceElements.editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                }
                            }
                            else if ((sanitycheck >= 4) && (sanitycheck < 8))
                            {
                                transformid -= 4;
                                InterFaceElements.editarea[j, i].Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                for (int l = 0; l < transformid; l++)
                                {
                                    InterFaceElements.editarea[j, i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                }
                            }
                            else if ((sanitycheck >= 8) && (sanitycheck < 12))
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
            HorMir = false;
            vertMir = false;
            PictureBox item = (PictureBox)sender;
            selectedtileindex=int.Parse(item.Tag.ToString());
            pictureBox_previewTile.Image = TileData.tileSetTiles[selectedtileindex];
            picboxImage= TileData.tileSetTiles[selectedtileindex];
        }

        private void MapSelectClickLabel(object sender, EventArgs e)
        {
            Label item = (Label)sender;
            string[] itemtag = item.Tag.ToString().Split(';');
            MouseEventArgs myArgs = (MouseEventArgs)e;
            if (myArgs.Button == MouseButtons.Right)
            {
                editEntitySpeechText(itemtag);
            }
            else doTheSwap(itemtag);
        }
        private void editEntitySpeechText(string[] itemtag)
        {
            //itemtag[0] xcoord
            //itemtag[1] ycoord
            for (int i = 0; i < MapData.LevelList[loadedLevel].entities.Count(); i++)
            {
                if ((MapData.LevelList[loadedLevel].entities[i].xcoord == int.Parse(itemtag[0])) && (MapData.LevelList[loadedLevel].entities[i].ycoord == int.Parse(itemtag[1])))
                {
                    string inputValue = MapData.LevelList[loadedLevel].entities[i].speechtext;
                    //---------------------------------------------------------------------------------------------
                    if (loadSavePopper.InputBox("Entity SpeechText", "Entity SpeechTex:", ref inputValue) == DialogResult.OK)
                    {
                        MapData.LevelList[loadedLevel].entities[i].speechtext = inputValue;
                        loadSavePopper.savedSinceLastedit = false;
                    }
                }
            }
            reloadView();
        }

        private void doTheSwap(string[] itemtag)
        {
            if (addmode)
            {
                if (removemode)
                {
                    removeEntity(itemtag);
                }
                else
                {
                    addEntity(itemtag);
                }
                addmode = false;
            }
            else
            {
                InterFaceElements.editarea[int.Parse(itemtag[0]), int.Parse(itemtag[1])].Image = pictureBox_previewTile.Image;
                MapData.LevelList[loadedLevel].tiledata[int.Parse(itemtag[0]), int.Parse(itemtag[1])] = selectedtileindex * 12 + selectedtilemodifier;
                loadSavePopper.savedSinceLastedit = false;
            }

        }

        private void removeEntity(string[] itemtag)
        {
            //itemtag[0] xcoord
            //itemtag[1] ycoord
            for (int i = 0; i < MapData.LevelList[loadedLevel].entities.Count(); i++)
            {
                if ((MapData.LevelList[loadedLevel].entities[i].xcoord == int.Parse(itemtag[0])) && (MapData.LevelList[loadedLevel].entities[i].ycoord == int.Parse(itemtag[1])))
                {
                    MapData.LevelList[loadedLevel].entities.RemoveAt(i);
                }
            }
            loadSavePopper.savedSinceLastedit = false;
            this.Cursor = Cursors.Default;
            reloadView();
        }

        private void addEntity(string[] itemtag)
        {
            //itemtag[0] xcoord
            //itemtag[1] ycoord
            if (EntityMenmonics.EnMenmoList.Count() == 0)
            {
                string inputValue = "";
                if (loadSavePopper.InputBox("Entity Id", "Enter Entity ID:", ref inputValue) == DialogResult.OK)
                {
                    if (szamEVagyNem(inputValue))
                    {
                        EntityData attolt = new EntityData();
                        attolt.xcoord = int.Parse(itemtag[0]);
                        attolt.ycoord = int.Parse(itemtag[1]);
                        attolt.entid = int.Parse(inputValue);
                        inputValue = "";
                        loadSavePopper.InputBox("Entity SpeechText", "Entity SpeechTex:", ref inputValue);
                        attolt.speechtext = inputValue;
                        MapData.LevelList[loadedLevel].entities.Add(attolt);
                        loadSavePopper.savedSinceLastedit = false;
                    }
                    else MessageBox.Show("Input data is incorrect");
                }
            }
            else
            {
                int entid = 0;
                if (loadSavePopper.enMnemoSelectorWindow(ref entid) == DialogResult.OK)
                {
                    EntityData attolt = new EntityData();
                    attolt.xcoord = int.Parse(itemtag[0]);
                    attolt.ycoord = int.Parse(itemtag[1]);
                    attolt.entid = EntityMenmonics.EnMenmoList[entid].id;
                    attolt.speechtext = EntityMenmonics.EnMenmoList[entid].defaultText;
                    MapData.LevelList[loadedLevel].entities.Add(attolt);
                }
            }
            this.Cursor = Cursors.Default;
            reloadView();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadSavePopper.progEnd();
        }

        private void button_rotateLeft_Click(object sender, EventArgs e)
        {
            int lowlimit=0;
            if (selectedtilemodifier < 4)
            {
                lowlimit = 0;
            }
            else if ((selectedtilemodifier >= 4) && (selectedtilemodifier < 8))
            {
                lowlimit = 4;
            }
            else if ((selectedtilemodifier >= 8) && (selectedtilemodifier < 12))
            {
                lowlimit = 8;
            }
            else MessageBox.Show("Error? TransformId: " + selectedtilemodifier);

            selectedtilemodifier--;
            if (selectedtilemodifier < lowlimit) selectedtilemodifier += 4;
            refPreview();
        }

        private void button_rotateRight_Click(object sender, EventArgs e)
        {
            int highlimit = 0;
            if (selectedtilemodifier < 4)
            {
                highlimit = 3;
            }
            else if ((selectedtilemodifier >= 4) && (selectedtilemodifier < 8))
            {
                highlimit = 7;
            }
            else if ((selectedtilemodifier >= 8) && (selectedtilemodifier < 12))
            {
                highlimit = 11;
            }
            else MessageBox.Show("Error? TransformId: " + selectedtilemodifier);

            selectedtilemodifier++;
            if (selectedtilemodifier > highlimit) selectedtilemodifier -= 4;
            refPreview();
        }

        private void button_horizontalMirror_Click(object sender, EventArgs e)
        {
            if ((HorMir == false) && (vertMir == false))
            {
                vertMir = true;
                selectedtilemodifier += 8;
            }
            else if ((HorMir == false) && (vertMir == true))
            {
                vertMir = false;
                selectedtilemodifier -= 8;
            }
            else if ((HorMir == true) && (vertMir == false))
            {
                HorMir = false;
                vertMir = true;
                selectedtilemodifier -= 4;
                selectedtilemodifier += 8;
            }
            refPreview();
        }

        private void button_verticalMirror_Click(object sender, EventArgs e)
        {
            if ((vertMir == false) && (HorMir == false))
            {
                HorMir = true;
                selectedtilemodifier += 4;
            }
            else if ((vertMir == false) && (HorMir == true))
            {
                HorMir = false;
                selectedtilemodifier -= 4;
            }
            else if ((vertMir == true) && (HorMir == false))
            {
                vertMir = false;
                HorMir = true;
                selectedtilemodifier -= 8;
                selectedtilemodifier += 4;
            }
            refPreview();
        }

        private void refPreview()
        {
            int transformid = selectedtilemodifier;
            Image koztes = picboxImage;
            pictureBox_previewTile.Image = (Image)koztes.Clone();
            int sanitycheck = transformid;
            if (sanitycheck < 4)
            {
                for (int l = 0; l < transformid; l++)
                {
                    pictureBox_previewTile.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            else if ((sanitycheck >= 4) && (sanitycheck < 8))
            {
                transformid -= 4;
                pictureBox_previewTile.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                for (int l = 0; l < transformid; l++)
                {
                    pictureBox_previewTile.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            else if ((sanitycheck >= 8) && (sanitycheck < 12))
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
                    MapData.LevelList[levelCount].tiledata[i, j] = 0;
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

        private void button_addEntity_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            addmode = true;
            removemode = false;
        }

        public static bool szamEVagyNem(string inString)
        {
            int i = 0;
            bool result = int.TryParse(inString, out i);
            return result;
        }

        private void button_removeentity_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            addmode = true;
            removemode = true;
        }

        private void toolStripMenuItem_loadentMnemo_Click(object sender, EventArgs e)
        {
            if (loadSavePopper.LoadEntityMnemo()) if (!FileIO.OpenMnemoFile()) MessageBox.Show("Bad Entity Mnemonic File");
                else;
        }
    }
}
