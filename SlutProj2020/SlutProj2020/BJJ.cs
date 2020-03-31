using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProj2020
{
    class BJJ : Grappler
    {
        //Konstruktor för BJJ subklassen
        public BJJ()
        {
            //Sätter ett namn
            name = "Gordon";
            //Sätter ett värde på pwr
            pwr = 2;
            //Sätter ett värde på hp
            hp = 20;
        }

        //public override för metoden Special. Här är fighterns specialattack
        public override int Special()
        {
            hp++;
            return (pwr * 2);
        }
    }
}
