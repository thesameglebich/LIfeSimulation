using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class human : organisms<foodhuman>
    {

        int rangeforhouse = 100;
        public bool hashome = false;
        public bool hasbarn = false;
        int timehumanspawn = 100;
        public int numberofhouse;
        public int numberofbarn = -1;
        public bool workstatus = false;
        public bool amibaby = false;
        public bool goingtobarn = false;
        public int rangeforcreatebarn = 5;
        public int imnotbaby = 120;
        public int maxtimeforhunt = 40;
        public int curtimeforhunt = 0;
        public int humanbarnsize = 5;
        public human(point _spot, point _scale, int _heal, int _gen, int _time, int _typ) : base(_spot, _scale, _heal, _gen, _time, _typ) { }

        public void HumanWork(List<entity> popul, List<house> houses, List<house> barns) 
        {
            if (this.found == false) 
            {
                if (gender == 1)
                    FindGrassForStrorage(popul); //for women
                else
                    FindCloseFood(popul); //for men
                this.found = true;
            }
            Idontwannadie();
            if (found == false && goingtobarn == true)
            {
                goingtobarn = false;
                workstatus = false;
            }
            CheckForFood(popul);
            if (health == maxhp)
            {
                closeX = tochka.x;
                closeY = tochka.y;
                this.found = true;
                houses[this.numberofhouse].PlusFood(this, barns);
            }
            if (found == false && health < maxhp - 1 && closeX != tochka.x && closeY != tochka.y && gender == 1)
            {
                FindGrassForStrorage(popul);
                this.found = true;
            }
            if (gender == 0)
                ManHunt();
        }

        public void ManHunt() 
        {
            curtimeforhunt++;
            if (curtimeforhunt > maxtimeforhunt)
            {
                found = true;
                closeX = tochka.x;
                closeY = tochka.y;
            }

        }

        public void GoToBarn(List<house> barns) 
        {
            found = true;
            FindBarn(barns);
            if (numberofbarn == -1)
            {
                BuildBarn(barns);
                numberofbarn = barns.Count - 1;
            }
            barns[numberofbarn].PlusFood(this, barns); 
            this.goingtobarn = true;
        }

        public void ActionForLittleHP(List<entity> popul, List<house> houses, List<house> barns)
        {
            if (houses[this.numberofhouse].IsNotEmpty() && found == false) 
            {
                houses[this.numberofhouse].MinusFood();
                this.health = maxhp;
            }
            else
            {
                if (found == false)
                {
                    FindBarn(barns);
                    if (spot.x == closeX && spot.y == closeY && numberofbarn!=-1)  
                    {
                        barns[numberofbarn].MinusFood();
                        this.health = maxhp;
                    }
                }
                Idontwannadie();
            }
        }

        public void FindBarn(List<house> barns)
        {
            for (int i=0;i< barns.Count; i++)
            {
                if ((Math.Abs(this.spot.x - barns[i].place.x) + Math.Abs(this.spot.y - barns[i].place.y)) < rangeforhouse)
                {
                    this.closeX = barns[i].place.x;
                    this.closeY = barns[i].place.y;
                    this.numberofbarn = i;
                    this.found = true;
                }
            }
        }

        public void CycleForPair(List<entity> popul, List<house> houses, List<entity> entnew, List<house> barns)
        {
            if (timer > timehumanspawn && workstatus == false)
                Iwantachild(popul, entnew, houses);
            else
            {
                if (houses[this.numberofhouse].CheckStorage(this, popul) || goingtobarn == true) 
                {
                    HumanWork(popul, houses, barns);
                }
                else
                {
                    if (this.health < minhp)
                    {
                        ActionForLittleHP(popul, houses, barns);
                    }
                    if (health > 0 && (tochka.x != spot.x || tochka.y != spot.y)) 
                    {
                        closeX = tochka.x;
                        closeY = tochka.y;
                        found = true;
                        Idontwannadie();
                    }
                }
            }
        }

        public override void WorkCycle(bool check, List<entity> popul, int g, List<entity> entnew, List<house> houses, List<house> barns)
        {
            Changeattributes(check);
            if (amibaby == false)
            {
                CheckForFood(popul);
                if (this.pair == true)
                {
                    CycleForPair(popul, houses, entnew, barns);
                }
                else DecidToMove(g, popul);
            }
            else
            {
                if (health < minhp)
                    ActionForLittleHP(popul, houses, barns); 
                if (timer > imnotbaby) 
                    amibaby = false;
            }
        }

        public void FindGrassForStrorage(List<entity> popul)
        {
            int min = 10000000;
            for (int i = 0; i < popul.Count; i++)
            {
                if (popul[i] is eat)
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

     
 
        public override void MakeChild(List<entity> popul, List<entity> entnew,List<house> houses)
        {
            IEnumerable<human> allhumans = popul.OfType<human>();
            foreach (human el2 in allhumans)
            {
                if (el2.index == this.index)
                {
                    if (this.spot.x == el2.spot.x && this.spot.y == el2.spot.y)
                    {

                        this.timer = 0;
                        el2.timer = 0;
                        if (this.hashome == false)
                        {
                            this.hashome = el2.hashome = true;
                            BuildHouse(houses, popul);
                        }

                        CreateChildren(9, entnew);


                    }
                    else break;
                }
            }
        }
        public void BuildHouse(List<house> houses, List<entity> popul)
        {
            // add ind 
            house test = new house();
            test.place = this.tochka;
            houses.Add(test);
            //tut nomer
            this.numberofhouse = houses.Count - 1;
            IEnumerable<human> allhumans = popul.OfType<human>();
            foreach (human el2 in allhumans)
            {
                if (el2.index == this.index)
                {
                    el2.numberofhouse = this.numberofhouse;
                    break;
                }
            }
        }

        public void BuildBarn(List<house> barns)
        {
            house test = new house();
            test.place = this.tochka;
            Random rand = new Random();
            test.place.x += rand.Next(rangeforcreatebarn) + 1;
            test.place.y += rand.Next(rangeforcreatebarn) + 1;
            test.maxsize = humanbarnsize;
            barns.Add(test);

        }
        public override void makepair(organismwithouttfood el2, Random rand, List<house> houses)
        {
            this.pair = el2.pair = true;
            FindPlaceForHouse(houses);
            el2.tochka = this.tochka;
            this.index = el2.index = rand.Next(10000);
        }
        public void FindPlaceForHouse(List<house> houses)
        {
            bool flag = false;

            for(int i = 0; i < houses.Count; i++)
            {
                if ((Math.Abs(this.spot.x - houses[i].place.x) + Math.Abs(this.spot.y - houses[i].place.y)) < rangeforhouse)
                {
                    flag = true;
                    Random rand = new Random();
                    int way = rand.Next(4);
                    int razbros = rand.Next(20);
                    if (way == 0)
                    {
                        Variant0(houses[i].place.x, houses[i].place.y, razbros);
                    }

                    if (way == 1)
                    {
                        Variant1(houses[i].place.x, houses[i].place.y, razbros);
                    }
                    if (way == 2)
                    {
                        Variant2(houses[i].place.x, houses[i].place.y, razbros);
                    }
                    if (way == 3)
                    {
                        Variant3(houses[i].place.x, houses[i].place.y, razbros);
                    }

                }
                    
            }
            if (flag == false)
            {
                this.tochka.x = this.spot.x;
                this.tochka.y = this.spot.y;
            }
        }
        private void Variant0(int closex, int closey, int razbros)
        {
            if (closex + razbros < scale.x)
            {
                this.tochka.x = closex + razbros;
                this.tochka.y = closey;
            }
            else Variant1(closex, closey, razbros);
        }
        private void Variant1(int closex, int closey, int razbros)
        {
            if (closex - razbros > 0)
            {
                this.tochka.x = closex - razbros;
                this.tochka.y = closey;
            }
            else Variant2(closex, closey, razbros);
        }

        private void Variant2(int closex, int closey, int razbros)
        {
            if (closey + razbros < scale.y)
            {
                this.tochka.x = closex;
                this.tochka.y = closey + razbros;
            }
            else Variant3(closex, closey, razbros);
        }
        private void Variant3(int closex, int closey, int razbros)
        {
            if (closey - razbros > 0)
            {
                this.tochka.x = closex;
                this.tochka.y = closey - razbros;
            }
        }

        public override void CreateChildren(int typeunit, List<entity> entnew)
        {
            Random random = new Random();
            human test = new human(this.spot, this.scale, 1000, random.Next(2), random.Next(100), 9);//я тут 0 поставил вместо рандома, ну тип пусть все растут одианково
            test.amibaby = true;
            test.numberofhouse = this.numberofhouse;
            entnew.Add(test);
        }

    }
}
