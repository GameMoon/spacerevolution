using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace TileMapEditor
{
    public class FileIO
    {
        public static bool ReadMapFile()
        {
            if (loadSavePopper.mapFilePath=="")
            {
                MessageBox.Show("Cannot Read from path: " + loadSavePopper.mapFilePath);
                return false;
            }
            else
            {
                MapData.LevelList.Clear();
                string path = loadSavePopper.mapFilePath;
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        int mapindex = MapData.LevelList.Count();
                        MapData.LevelList.Add(new LevelData());
                        MapData.LevelList[mapindex].name = sr.ReadLine();
                        for (int i = 0; i < Form_editorWindow.tileGridHeigth; i++)
                        {
                            string[] besor = sr.ReadLine().Split(';');
                            for (int j = 0; j < Form_editorWindow.tileGridWidth; j++)
                            {
                                MapData.LevelList[mapindex].tiledata[j, i] = int.Parse(besor[j])-1;
                            }

                        }
                        while (true)
                        {
                            string sor = sr.ReadLine();
                            int entitityindex = MapData.LevelList[mapindex].entities.Count();
                            if (sor == "--" || sr.EndOfStream) break;
                            else
                            {
                                string[] darabsor = sor.Split(';');

                                MapData.LevelList[mapindex].entities.Add(new EntityData());
                                MapData.LevelList[mapindex].entities[entitityindex].entid = int.Parse(darabsor[0]);
                                MapData.LevelList[mapindex].entities[entitityindex].xcoord = int.Parse(darabsor[1]) - 1;
                                MapData.LevelList[mapindex].entities[entitityindex].ycoord = int.Parse(darabsor[2]) - 1;
                                MapData.LevelList[mapindex].entities[entitityindex].speechtext = darabsor[3];
                            }
                        }
                    }
                    sr.Close();
                    return true;
                }

            }
        }

        public static bool OpenMnemoFile()
        {
            string path = loadSavePopper.enMnemoFilePath;
            if (path == "")
            {
                MessageBox.Show("Cannot Load from path: " + loadSavePopper.mapFilePath);
                return false;
            }
            else
            {
                EntityMenmonics.EnMenmoList.Clear();
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] besor = sr.ReadLine().Split(';');
                        EntityMenmoData varaddMnemo = new EntityMenmoData();
                        varaddMnemo.id = int.Parse(besor[0]);
                        varaddMnemo.name = besor[1];
                        varaddMnemo.defaultText = besor[2];
                        EntityMenmonics.EnMenmoList.Add(varaddMnemo);
                    }
                    sr.Close();
                    return true;
                }
            }
        }

        public static bool WriteFile()
        {
            string path = loadSavePopper.mapFilePath;
            if (path == "")
            {
                MessageBox.Show("Cannot save to path: " + loadSavePopper.mapFilePath);
                return false;
            }
            else
            {
                if (File.Exists(path)) File.Delete(path);
                using (StreamWriter sw = new StreamWriter(path))
                {
                    for (int i = 0; i < MapData.LevelList.Count(); i++)
                    {
                        sw.WriteLine(MapData.LevelList[i].name);
                        for (int j = 0; j < Form_editorWindow.tileGridHeigth; j++)
                        {
                            for (int k = 0; k < Form_editorWindow.tileGridWidth; k++)
                            {
                                sw.Write(MapData.LevelList[i].tiledata[k, j] + 1);
                                if (k != 31) sw.Write(";");
                                if (k == 31) sw.WriteLine();
                            }
                        }
                        for (int l = 0; l < MapData.LevelList[i].entities.Count(); l++)
                        {
                            sw.WriteLine(MapData.LevelList[i].entities[l].entid + ";" + (MapData.LevelList[i].entities[l].xcoord+1) + ";" + (MapData.LevelList[i].entities[l].ycoord+1) + ";" + (MapData.LevelList[i].entities[l].speechtext));
                        }
                        sw.WriteLine("--");
                    }
                    sw.Close();
                }
                return true;
            }
        }

    }
}
