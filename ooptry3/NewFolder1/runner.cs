using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class Runner
    {
        Form1 form1;
        public populationgroup population;
        public Runner(Form1 form)
        {
            form1 = form;
            population = new populationgroup();
        }

        public void CreateMyWorld()
        {
            form1.InicializeValue();
            form1.NoiseFun();
            population.Createfirstgen(form1.columns, form1.rows);
            population.CreateFirstFood(form1.columns, form1.rows);
        }

        public void CreateNewWorld()
        {
            form1.DrawMap(population.popul, population.houses, population.barns);
            //test
            /*
            if (population.progress % 500 == 0)
            {
                for(int i = 0; i < population.popul.Count; i++)
                {
                        population.popul[i].health = 201;
                }
            }*/
            //тут фича, но надо людей отсюда убрать, а то дети не выживут никак
            population.NewStepPop(form1.heights, form1.board);
     
        }

      


    }
}
