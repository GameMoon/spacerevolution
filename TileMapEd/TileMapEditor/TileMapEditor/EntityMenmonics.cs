using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMapEditor
{
    public static class EntityMenmonics
    {
        public static List<EntityMenmoData> EnMenmoList = new List<EntityMenmoData>();
    }

    public class EntityMenmoData
    {
        public int id;
        public string name;
        public string defaultText;
    }
}
