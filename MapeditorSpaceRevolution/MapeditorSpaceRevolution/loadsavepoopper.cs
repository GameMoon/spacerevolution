using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapeditorSpaceRevolution
{
    public class loadsavepoopper
    {
        public static string mapFilePath;
        public static string tileFilePath;

        public static void SavFileAs()
        {
            SaveFileDialog newMapFile = new SaveFileDialog();
            newMapFile.Filter = "SR Map|*.srm";
            newMapFile.Title = "Create new SR map...";
            if (newMapFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mapFilePath = newMapFile.FileName;
            }
        }

        public static void LoadTileDialog()
            {
            {
                OpenFileDialog openTileFile = new OpenFileDialog();
                openTileFile.Filter = "PNG Image|*.png|All Files|*.*";
                openTileFile.Title = "Select a Tileset File";

                if (openTileFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tileFilePath = openTileFile.FileName;
                }
            }
        }
            public static void LoaFile()
            {
                OpenFileDialog openMapFile = new OpenFileDialog();
                openMapFile.Filter = "SR Map|*.srm|All Files|*.*";
                openMapFile.Title = "Select a Map File";

                if (openMapFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                mapFilePath = openMapFile.FileName;
                }
            }


        public static void progEnd()
        {
            Environment.Exit(0);
        }
    }
}
