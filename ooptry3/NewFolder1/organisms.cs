using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class point
    {
        public int x, y;
    }
    public abstract class organisms<TFood>:organismwithouttfood
        where TFood: foodmain
    {
        
       
        public organisms(point _spot, point _scale, int _heal,int _gen, int _time,int _typ):base( _spot,  _scale,  _heal,  _gen,  _time, _typ)
        {
            
        }
        

    
       
        public override void CheckForFood(List<entity> popul)
        {
            for (int i = 0; i < popul.Count; i++)
            {
                if (this.spot.x == popul[i].spot.x && this.spot.y == popul[i].spot.y && (popul[i] is TFood))
                {
                    this.health = 1000;
                    this.found = false;
                    popul[i].DieFood(popul);
                    break;
                }
            }
        }

       

       

        public override void FindCloseFood(List<entity> popul)
        {
            int min = 10000000;
            for (int i = 0; i < popul.Count; i++)
            {
                if (popul[i] is TFood)
                {
                    if ((Math.Abs(this.spot.x - popul[i].spot.x) + Math.Abs(this.spot.y - popul[i].spot.y)) < min)
                    {
                        min = Math.Abs(this.spot.x - popul[i].spot.x) + Math.Abs(this.spot.y - popul[i].spot.y);
                        this.closeX = popul[i].spot.x;
                        this.closeY = popul[i].spot.y;
                    }
                   
                }
            }
        }

  
       

    }
}
