using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class eat:entity, foodherb, foodomni, foodhuman
    {
        public int typeoffood;
        public eat(point _spot, point _scale, int _heal):base(_spot, _scale, _heal) { }
        
        public override void DieFood(List<entity> popul)
        {
            IEnumerable<eat> food = popul.OfType<eat>();
            
            Random rand = new Random(); // никогда не выполнится поиск до сарая, никогда не найдёт пищу, изменить охоту, изменить фун в доме, 
            int g = rand.Next(200);
            int z = 0;
            int closex = 0;
            int closey = 0;
            
            foreach(eat el in food)
            {
                if (z == g)
                {
                    closex = el.spot.x;
                    closey = el.spot.y;
                }
                z++;
            }
          
            int way = rand.Next(4);
            int razbros = rand.Next(20);
            if (way == 0)
            {
                Variant0(closex,closey, razbros);
            }

            if (way == 1)
            {
                Variant1(closex, closey, razbros);
            }
            if (way == 2)
            {
                Variant2(closex, closey, razbros);
            }
            if (way == 3)
            {
                Variant3(closex, closey, razbros);
            }
        }

     
        private void Variant0(int closex, int closey, int razbros)
        {
            if (closex + razbros < scale.x)
            {
                this.spot.x = closex + razbros;
                this.spot.y = closey;
            }
            else Variant1(closex,closey,razbros );
        }
        private void Variant1(int closex, int closey, int razbros)
        {
            if (closex - razbros > 0)
            {
                this.spot.x = closex - razbros;
                this.spot.y = closey;
            }
            else Variant2(closex, closey,razbros );
        }

        private void Variant2(int closex, int closey, int razbros)
        {
            if (closey + razbros < scale.y)
            {
                this.spot.x = closex;
                this.spot.y = closey + razbros;
            }
            else Variant3(closex, closey, razbros);
        }
        private void Variant3(int closex, int closey, int razbros)
        {
            if (closey - razbros > 0)
            {
                this.spot.x = closex;
                this.spot.y = closey - razbros;
            }
        }

    }
}
