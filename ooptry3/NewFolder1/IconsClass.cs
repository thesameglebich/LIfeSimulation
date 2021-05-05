using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptry3
{
    public class IconsClass
    {
        //private Graphics graphics;
        private static Image deer = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\deer.png");
        private static Image mouse = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\mouse.png");
        private static Image rabbit = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\rabbit.png");
        private static Image fox = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\fox.png");
        private static Image lion = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\lion.png");
        private static Image wolf = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\wolf.png");
        private static Image bear = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\bear.png");
        private static Image pig = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\pig.png");
        private static Image raccoon = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\raccoon.png");
        private static Image apple = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\apple.png");
        private static Image oats = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\oats.png");
        private static Image carrot = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\carrot.png");
        private static Image home = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\home.png");
        private static Image human = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\human.png");

        public Image GetIcon(int type)
        {
            if (type == 0)
                return deer;
            if (type == 1)
                return mouse;
            if (type == 2)
                return rabbit;
            if (type == 3)
                return fox;
            if (type == 4)
                return lion;
            if (type == 5)
                return wolf;
            if (type == 6)
                return bear;
            if (type == 7)
                return pig;
            if (type == 8)
                return raccoon;
            if (type == 9)
                return human;
            if (type == 10)
                return apple;
            if (type == 11)
                return carrot;
            if (type == 12)
                return oats;
            if (type == 13)
                return home;
            return human;
        }
    }
}
