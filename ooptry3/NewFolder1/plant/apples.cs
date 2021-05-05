using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class apples: eat, foodpigs, fooddeer, foodbears, foodraccoons, foodmice, foodrabbits, foodhuman
    {
        public apples(point _spot, point _scale, int _heal) : base(_spot, _scale, _heal) { }
    }
}
