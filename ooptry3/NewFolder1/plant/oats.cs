using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class oats: eat, fooddeer, foodrabbits, foodraccoons, foodhuman
    {
        public oats(point _spot, point _scale, int _heal) : base(_spot, _scale, _heal) { }
    }
}
