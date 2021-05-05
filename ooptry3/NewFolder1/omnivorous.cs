using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class omnivorous<Tfood>: organisms<foodomni>, foodhuman
        where Tfood: foodomni
    {
        public omnivorous(point _spot, point _scale, int _heal, int _gen, int _time, int _typ) : base(_spot, _scale, _heal, _gen, _time, _typ) { }

    }
}
