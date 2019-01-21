using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileMapEditor
{
    class loadSavePopper
    {
        public static string mapFilePath;
        public static string tileFilePath;
        public static bool savedSinceLastedit = true;

        public static bool SaveFileAsDialog()
        {
            SaveFileDialog newMapFile = new SaveFileDialog();
            newMapFile.Filter = "SR Map|*.srm|All Files|*.*";
            newMapFile.Title = "Select SR mapfile...";
            if (newMapFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mapFilePath = newMapFile.FileName;
                savedSinceLastedit = true;
                return true;
            }
            else return false;
        }

        public static bool LoadTilesetDialog()
        {
            {
                OpenFileDialog openTileFile = new OpenFileDialog();
                openTileFile.Filter = "PNG Image|*.png|All Files|*.*";
                openTileFile.Title = "Select a Tileset File";

                if (openTileFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tileFilePath = openTileFile.FileName;
                    return true;
                }
                else return false;
            }
        }
        public static bool LoadMapFileDialog()
        {
            OpenFileDialog openMapFile = new OpenFileDialog();
            openMapFile.Filter = "SR Map|*.srm|All Files|*.*";
            openMapFile.Title = "Select a Map File";

            if (openMapFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mapFilePath = openMapFile.FileName;
                return true;
            }
            else return false;
        }
        
        public static bool progEnd()
        {
            if(savedSinceLastedit)
            {
                Environment.Exit(0);
                return true;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Exit without saving?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Environment.Exit(0);
                    return true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                    return false;
                }
                else return false;
            }
        }
    }
}
