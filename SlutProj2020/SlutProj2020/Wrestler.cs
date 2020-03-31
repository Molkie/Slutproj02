using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProj2020
{
    class Wrestler : Grappler
    {
        //Konstruktor för Wrestler subklassen
        public Wrestler()
        {
            //Sätter ett namn
            name = "Max";
            //Sätter ett värde på pwr
            pwr = 4;
            //Sätter ett värde på hp
            hp = 22;
        }
        //public override för metoden Special. Här är fighterns specialattack
        public override int Special()
        {
            hp--;
            return (pwr * 4);
        }
    }
}
