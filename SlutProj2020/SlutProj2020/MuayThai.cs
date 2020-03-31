using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProj2020
{
    class MuayThai : Striker
    {
        //Konstruktor för MuayThai subklassen
        public MuayThai()
        {
            //Sätter ett namn
            name = "Rolf";
            //Sätter ett värde på pwr
            pwr = 3;
            //Sätter ett värde på hp
            hp = 18;
        }
        //public override för metoden Special. Här är fighterns specialattack
        public override int Special()
        {
            return (pwr * 3);
        }
    }
}
