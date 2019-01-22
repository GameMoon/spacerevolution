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
        public string mapFilePath;
        public string tileFilePath;

        public void SavFileAs()
        {
            SaveFileDialog newMapFile = new SaveFileDialog();
            newMapFile.Filter = "SR Map|*.srm";
            newMapFile.Title = "Create new SR map...";
            if (newMapFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mapFilePath = newMapFile.FileName;
            }
        }

        public void LoadTileDialog()
            {
            {
                OpenFileDialog openTileFile = new OpenFileDialog();
                openTileFile.Filter = "All Files|*.*";
                openTileFile.Title = "Select a Tileset File";

                if (openTileFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tileFilePath = openTileFile.FileName;
                }
            }
        }
            public void LoaFile()
            {
                OpenFileDialog openMapFile = new OpenFileDialog();
                openMapFile.Filter = "SR Map|*.srm|All Files|*.*";
                openMapFile.Title = "Select a Map File";

                if (openMapFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                mapFilePath = openMapFile.FileName;
                }
            }


        public void progEnd()
        {
            Environment.Exit(0);
        }
    }
}
