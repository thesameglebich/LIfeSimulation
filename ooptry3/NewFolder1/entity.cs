using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    abstract public class entity
    {
        //public int x, y, rows, columns;
        public point spot;
        public point scale;
        public int health;
        public int maxhp = 1000;
        public int minhp = 200;
        public bool pair = false;
        public populationgroup popl2;
        public int slowmove = 0;
        public entity(point _spot, point _scale, int _heal)
        {
            spot = _spot;
            scale = _scale;
            health = _heal;
        }
        public abstract void DieFood(List<entity> popul);

    }
    
}
