using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class hunter<Tfood> : organisms<foodhunt>, foodhuman
        where Tfood: foodhunt 
    {
        public int huntersteps = -1;
        public int typeforhunt = 0;

        public hunter(point _spot, point _scale, int _heal, int _gen, int _time, int _typ):base(_spot, _scale, _heal, _gen, _time, _typ) { }
       

 

        public void FindVictim()
        {
            this.closeX = this.spot.x + this.huntersteps;
            if (this.huntersteps % 2 == 0)
                this.closeY = this.spot.y + 10;
            else this.closeY = this.spot.y - 10;
            if (this.closeX < 0)
                this.closeX = this.closeX + 20;
            if (this.closeX >= scale.x)
                this.closeX = this.closeX - 20;
            if (this.closeY < 0)
                this.closeY = this.closeY + 20;
            if (this.closeY >= scale.y)
                this.closeY = this.closeY - 20;

        }

    }
}