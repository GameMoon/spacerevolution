using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileMapEditor
{
    public class InterFaceElements
    {
        public static PictureBox[,] editarea = new PictureBox[Form_editorWindow.tileGridWidth, Form_editorWindow.tileGridHeigth];
        public static List<PictureBox> tileSelectTiles = new List<PictureBox>();
    }
}
