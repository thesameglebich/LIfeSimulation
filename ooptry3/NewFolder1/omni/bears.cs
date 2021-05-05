using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class bears : omnivorous<foodbears>, foodhuman
    {
        //tut pat constr
        public bears(point _spot, point _scale, int _heal, int _gen, int _time, int _typ) : base(_spot, _scale, _heal, _gen, _time, _typ) { }
        public override void CreateChildren(int typeunit, List<entity> entnew)
        {
            Random random = new Random();
            bears test = new bears(this.spot, this.scale, 1000, random.Next(2), random.Next(100), 6);
            entnew.Add(test);
        }
    }
}
