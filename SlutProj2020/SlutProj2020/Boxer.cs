using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProj2020
{
    class Boxer : Striker
    {
        //Konstruktor för MuayThai subklassen
        public Boxer()
        {
            //Sätter ett namn
            name = "Muhammed";
            //Sätter ett värde på pwr
            pwr = 3;
            //Sätter ett värde på hp
            hp = 24;
        }
        //public override för metoden Special. Här är fighterns specialattack
        public override int Special()
        {
            return (pwr * 4);
        }
    }
}
