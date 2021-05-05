using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class populationgroup
    {
        
        public int countofp = 30;
        public int progress = 1;
        public int deadradius = 15;
        public List<entity> popul = new List<entity>();
        public bool season;
        public int countfood = 80;
        public int counthuman = 100;
        public List<entity> newent = new List<entity>();
        public List<house> houses = new List<house>();
        public List<house> barns = new List<house>();
        // констуркотры 
        // 
       

        public void CreateDeer(point pscale, Random random)
        {
            point pspot = new point();

            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);
            deer test = new deer(pspot, pscale, random.Next(1000), random.Next(2), random.Next(100), 0);

                popul.Add(test);
            
        }
        public void CreateMice(point pscale, Random random)
        {
            point pspot = new point();

            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);
            mice test = new mice(pspot, pscale, random.Next(1000), random.Next(2), random.Next(100), 1);

                popul.Add(test);
            
        }

        public void CreateRabbit(point pscale, Random random)
        {

            point pspot = new point();

            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);
            rabbits test = new rabbits(pspot, pscale, random.Next(1000), random.Next(2), random.Next(100), 2);

                popul.Add(test);
            
        }
        public void CreateFox(point pscale, Random random)
        {

            point pspot = new point();

            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);
            fox test = new fox(pspot, pscale, random.Next(1000), random.Next(2), random.Next(100), 3);

                popul.Add(test);
            
        }
        public void CreateLion(point pscale, Random random)
        {

            point pspot = new point();

            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);
            lions test = new lions(pspot, pscale, random.Next(1000), random.Next(2), random.Next(100), 4);

                popul.Add(test);
            
        }
        public void CreateWolf(point pscale, Random random)
        {

            point pspot = new point();

            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);
            wolf test = new wolf(pspot, pscale, random.Next(1000), random.Next(2), random.Next(100), 5);

                popul.Add(test);
            
        }
        public void CreateBear(point pscale, Random random)
        {
            point pspot = new point();

            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);
            bears test = new bears(pspot, pscale, random.Next(1000), random.Next(2), random.Next(100), 6);

                popul.Add(test);
            
        }
        public void CreatePigs(point pscale, Random random)
        {
            point pspot = new point();

            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);
            pigs test = new pigs(pspot, pscale, random.Next(1000), random.Next(2), random.Next(100), 7);

                popul.Add(test);
            
        }
        public void CreateRaccoon(point pscale, Random random)
        {
            point pspot = new point();

            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);
            raccoons test = new raccoons(pspot, pscale, random.Next(1000), random.Next(2), random.Next(100), 8);

                popul.Add(test);
            
        }

        public void CreateHuman(point pscale, Random random)
        {
            point pspot = new point();

            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);
            human test = new human(pspot, pscale, random.Next(1000), random.Next(2), random.Next(100), 9);

            popul.Add(test);
        }
        public void CreateApple(point pscale, Random random)
        {

            point pspot = new point();
            
            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);
            
            apples test = new apples(pspot, pscale, 1000);
            test.typeoffood = 10;

                popul.Add(test);
        }

        public void CreateCarrot(point pscale, Random random)
        {

            point pspot = new point();

            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);


            carrots test = new carrots(pspot, pscale, 1000);
            test.typeoffood = 11;

            popul.Add(test);
        }
        public void CreateOats(point pscale, Random random)
        {

            point pspot = new point();

            pspot.x = random.Next(pscale.x);
            pspot.y = random.Next(pscale.y);

            oats test = new oats(pspot, pscale, 1000);
            test.typeoffood = 12;

            popul.Add(test);
        }


        public void CreateFirstFood(int col, int r)
        {
            point pscale = new point();
            pscale.x = col;
            pscale.y = r;
            Random random = new Random();
            for (int i = 0; i < countfood; i++)
            {
                CreateCarrot(pscale, random);
            }
            for (int i = 0; i < countfood; i++)
            {
                CreateApple(pscale, random);
            }
            for (int i = 0; i < countfood; i++)
            {
                CreateOats(pscale, random);
            }

        }



        public void Createfirstgen(int col, int r)
        {
            point pscale = new point();
            pscale.x = col;
            pscale.y = r;
            Random random = new Random();
            for (int i = 0; i < countofp; i++)
            {
                CreateDeer(pscale, random);
            }
            for (int i = 0; i < countofp; i++)
            {
                CreateMice(pscale, random);
            }
            for (int i = 0; i < countofp; i++)
            {
                CreateRabbit(pscale, random);
            }
            for (int i = 0; i < countofp; i++)
            {
                CreateFox(pscale, random);
            }
            for (int i = 0; i < countofp; i++)
            {
                CreateLion(pscale, random);
            }
            for (int i = 0; i < countofp; i++)
            {
                CreateWolf(pscale, random);
            }
            for (int i = 0; i < countofp; i++)
            {
                CreatePigs(pscale, random);
            }
            for (int i = 0; i < countofp; i++)
            {
                CreateRaccoon(pscale, random);
            }
            for (int i = 0; i < countofp; i++)
            {
                CreateBear(pscale, random);
            }
            for (int i=0;i < counthuman; i++)
            {
                CreateHuman(pscale, random);
            }
        }

        public void DeleteLocation(int x2, int y2)
        {
            for (int i = 0; i < popul.Count; i++)
            {
                if ((Math.Abs(popul[i].spot.x - x2) < 30) && (Math.Abs(popul[i].spot.y - y2) < 30))
                {
                    popul.RemoveAt(i);
                    i--;
                }
            }
        }

        

        
        public void NewStepPop(float [,] heights, double board)
        {
            
            progress++;
            if ((progress / 500) % 2 == 0)
                season = true;
            else season = false;
            Random rand = new Random();
            IEnumerable<organismwithouttfood> allorg = popul.OfType<organismwithouttfood>();

            foreach (organismwithouttfood el in allorg)
            {
                if (el.pair == false)
                {
                    if (el.CheckForCreatePair())
                    {
                        foreach(organismwithouttfood el2 in allorg)
                        {
                            if (el2.CheckForCreatePair() && el2.gender!= el.gender && el.typeofunit == el2.typeofunit)
                            {
                              
                                    el.makepair(el2, rand, houses);
                            }
                        }
                    }
                }
                if (heights[el.spot.x,el.spot.y] <= board - 0.05)
                {
                    if (el.slowmove % 2 == 1)
                        el.WorkCycle(season, popul, rand.Next(4), newent, houses, barns);
                    el.slowmove++;
                }
                else
                el.WorkCycle(season, popul, rand.Next(4), newent, houses, barns); 
                
            }


            for (int i = 0; i < popul.Count; i++)
            {
                if (popul[i].health < 0)
                {
                    popul.RemoveAt(i);
                    i--;
                    if (i < 0)
                        i++;
                }
            }
            for(int i = 0; i < newent.Count; i++)
            {
                popul.Add(newent[i]);
            }
            newent.Clear();
           
        }
     
    }
}
