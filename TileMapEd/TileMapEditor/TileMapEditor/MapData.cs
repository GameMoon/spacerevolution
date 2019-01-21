using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMapEditor
{
    public  class LevelData
    {
        public string name;
        public int[,] tiledata = new int[Form_editorWindow.tileGridWidth, Form_editorWindow.tileGridHeigth];
        public List<EntityData> entities = new List<EntityData>();
    }

    public static class MapData
    {
        public static List<LevelData> LevelList = new List<LevelData>();
    }
}
