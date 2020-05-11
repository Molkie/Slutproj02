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
            //Slumpar ett värde mellan 0 och längden av arrayen names, definerar namnet till det namn med motsvarande indexvärdet i arrayen names i klassen Fighter.
            name = names[(generator.Next(0, names.Length))];
        }
        //public override för metoden Special. Här är fighterns specialattack.
        public override int Special()
        {
            //Skapar integern dmg och definerar den som värdet av pwr.
            int dmg = pwr;
            //Om hp är under eller lika med 10
            if (hp <= 10)
            {
                //For loop som körs för varge hp fightern  har kvar
                for (int i = 0; i < hp; i++)
                {
                    //Kollar om dmg är under summan av pwr + hp.
                    if(dmg > (pwr + hp))
                    {
                        //Lägger till ett slumpat tal mellan 0 - 2 till variabeln dmg.
                        dmg += generator.Next(0, 3);
                    }
                }
                //Returnerar värdet av dmg.
                return (dmg);
            }
            //Om fighterns hp är över 10
            else
            {
                return (dmg);
            }
        }
    }
}
