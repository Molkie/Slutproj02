using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProj2020
{
    class Wrestler : Grappler
    {
        //Random generator
        Random generator = new Random();
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
        //public override för metoden Special. Här är fighterns specialattack.
        public override int Special()
        {
            //Om hp är under 10
            if(hp < 10)
            {
                //Skapar integern dmg och definerar den som värdet av pwr.
                int dmg = pwr;
                //Lägger till ett slumpat tal mellan 0 - 2 per hp som fightern har kvar till variabeln dmg.
                for (int i = 0; i < hp; i++)
                {
                    //Lägger till ett slumpat tal mellan 0 - 2 till variabeln dmg.
                     dmg += generator.Next(0, 3);
                }
                //Returnerar värdet av dmg.
                return (dmg);
            }
            //Om fighterns hp är över 10 returneras fighterns variabel pwr gånger 4.
            else
            {
                //Returnerar värdet av pwr * 4
                return (pwr * 4);
            }
        }
    }
}
