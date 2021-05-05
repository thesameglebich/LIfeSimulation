using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class carrots:eat, foodpigs, fooddeer, foodbears, foodraccoons, foodmice, foodrabbits, foodhuman
    {
        public carrots(point _spot, point _scale, int _heal) : base(_spot, _scale, _heal) { }
    }
}
