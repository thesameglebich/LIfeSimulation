using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public abstract class organismwithouttfood: entity
    {
        public int closeX, closeY;
        public bool found = false;
        public int gender;

        public int index;
        public int timer;


        public point tochka = new point();

        public int typeofunit;

        public organismwithouttfood(point _spot, point _scale, int _heal, int _gen, int _time, int _typ) : base(_spot, _scale, _heal)
        {
            gender = _gen;
            timer = _time;
            typeofunit = _typ;
        }



        public virtual void WorkCycle(bool check, List<entity> popul, int g, List<entity> entnew, List<house> houses, List<house> barns)
        {
            Changeattributes(check);
            CheckForFood(popul);

            if (this.pair == true)
            {
                
                Iwantachild(popul, entnew, houses);
            }
            else DecidToMove(g, popul);


        }


        //this
        public abstract void CheckForFood(List<entity> popul);


        public override void DieFood(List<entity> popul)
        {
            //popul.Remove(popul.Find(entity => entity is TFood && entity.x == this.x && entity.y == this.y));
            this.health = -1;
        }

        public void Changeattributes(bool check)
        {
            if (check)
            {
                this.health--;
                this.timer++;
            }
            else
            {
                this.health -= 2;
                this.timer++;
            }
        }

        public string Information()
        {
            string info = $" gender:{this.gender} \n timer:{this.timer} \n typeofunit:{this.typeofunit} \n health:{this.health}";
            return info;
        }
        public void Move(int num)
        {



            if (num == 0)
                Move0();
            if (num == 1)
                Move1();
            if (num == 2)
                Move2();
            if (num == 3)
                Move3();
        }

        public void Move0()
        {
            if (this.spot.y - 1 >= 0)
            {
                this.spot.y = this.spot.y - 1;
            }

        }

        public void Move1()
        {
            if (this.spot.y + 1 < scale.y)
                this.spot.y = this.spot.y + 1;
        }

        public void Move2()
        {
            if (this.spot.x - 1 > 0)
                this.spot.x = this.spot.x - 1;
        }

        public void Move3()
        {
            if (this.spot.x + 1 < scale.x)
                this.spot.x = this.spot.x + 1;
        }


        //this
        public abstract void FindCloseFood(List<entity> popul);

        public void DecidToMove(int g, List<entity> popul)
        {
            if (this.health < 200)
            {
                if (this.found == false)
                {
                    this.FindCloseFood(popul);
                    this.found = true;
                }

                this.Idontwannadie();
            }
            else
            {

                this.Move(g);
            }
        }
        // public abstract void DecidToMove(int g, List<entity> popul);


        public bool CheckForCreatePair()
        {
            if (this.health > 600 && this.pair == false && this.timer >= 100)
                return true;
            else return false;
        }





        public void Idontwannadie()
        {
            int nstepX = this.closeX - this.spot.x;
            int nstepY = this.closeY - this.spot.y;
            if (nstepX == 0 && nstepY == 0)
                this.found = false;
            else
            {
                if (Math.Abs(nstepY) >= Math.Abs(nstepX))
                {
                    if (nstepY > 0)
                        this.spot.y++;
                    else this.spot.y--;
                }
                else
                {
                    if (nstepX > 0)
                        this.spot.x++;
                    else this.spot.x--;
                }
            }

        }


        public virtual void makepair(organismwithouttfood el2, Random rand, List<house> houses)
        {
            this.pair = el2.pair = true;
            this.tochka.x = el2.tochka.x = (this.spot.x + el2.spot.x) / 2;
            this.tochka.y = el2.tochka.y = (this.spot.y + el2.spot.y) / 2;
            this.index = el2.index = rand.Next(1000);
        }

       

        public virtual void MakeChild(List<entity> popul, List<entity> entnew, List<house> houses)
        {

            IEnumerable<organismwithouttfood> allorganisms = popul.OfType<organismwithouttfood>();
            foreach (organismwithouttfood el2 in allorganisms)
            {
                if (el2.index == this.index)
                {
                    if (this.spot.x == el2.spot.x && this.spot.y == el2.spot.y)
                    {

                        this.timer = 0;
                        el2.timer = 0;
                      
                            this.pair = false;
                            el2.pair = false;
                        
                     
                        int typeunit = this.typeofunit;
                        CreateChildren(typeunit, entnew);


                    }
                }
            }

        }


        public void Iwantachild(List<entity> popul, List<entity> entnew, List<house> houses)
        {
            int nstepX = this.tochka.x - this.spot.x;
            int nstepY = this.tochka.y - this.spot.y;
            if (nstepX == 0 && nstepY == 0)
            {
                
                this.MakeChild(popul, entnew, houses);
              
            }
            else
            {
                if (Math.Abs(nstepY) >= Math.Abs(nstepX))
                {
                    if (nstepY > 0)
                        this.spot.y++;
                    else this.spot.y--;
                }
                else
                {
                    if (nstepX > 0)
                        this.spot.x++;
                    else this.spot.x--;
                }
            }

        }




        public bool Dead()
        {
            if (this.health < 0)
                return true;
            else return false;

        }

        //tut abstrc
        public virtual void CreateChildren(int typeunit, List<entity> entnew) { }
        
    }
}
