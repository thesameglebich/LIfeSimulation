using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class house
    {
        public point place;
        public int maxsize = 2;
        public int cursize = 0;
        public bool cyclefood = false;
        public string Information()
        {
            string info = $" cursize:{this.cursize} \n cyclefood:{this.cyclefood} \n x:{place.x} \n y:{place.y}";
            return info;
        }

        public bool IsNotEmpty()
        {
            if (cursize != 0)
                return true;
            else return false;
        }

        public void MinusFood()
        {
            cursize--;
            if (cursize < 0)
                cursize = 0;
        }

        public void PlusFood(human myhuman, List<house> barns)
        {
            cursize++;
            if (cursize > maxsize)
            {
                cursize--;
                myhuman.GoToBarn(barns);
            }
        }

        public bool CheckStorage(human hum, List<entity> popul)
        {
            /*
            if (cursize == 0 && cyclefood == false)
            {
                cyclefood = true;
                hum.workstatus = true;
                return true;

            }
            if (cursize == maxsize && cyclefood == true)
            {
                hum.workstatus = false;
                cyclefood = false;
                return false;
            }
            if (cyclefood == false)
                return false;
            else return true;*/
            if (cursize != maxsize)
            {
                cyclefood = true;
                hum.workstatus = true;
                return true;
            }
            else
            {
                IEnumerable<human> humans = popul.OfType<human>();
                foreach(human hu in humans)
                {
                    if (hum.index == hu.index)
                        hu.goingtobarn = true;
                }
                hum.workstatus = false;
                cyclefood = false;
                return false;
            }
        }

        public bool trynewfun(human hum)
        {
            if (cursize != 0)
            {
                cyclefood = true;
                hum.workstatus = true;
                return true;
            }
            else
            {
               
                hum.workstatus = false;
                cyclefood = false;
                return false;
            }
        }
    }
}
