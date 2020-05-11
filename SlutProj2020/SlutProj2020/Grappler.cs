using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProj2020
{
    class Grappler : Fighter
    {
        //Random generator
        Random generator = new Random();
        //Konstruktor för subklassen Grappler. Denna subklass påverkar alltså klasserna Wrestler & BJJ.
        public Grappler()
        {
            //Slumpar olika värden för hp och pwr.
            //Genererar ett värde för hp mellan 20 och 30
            hp = generator.Next(20, 31);
            //Genererar ett värde för pwr mellan 5 och 10
            pwr = generator.Next(5, 10);
            //Kollar om hp är över 24, om detta är sant sänks värdet på pwr för att fightern inte ska bli för kraftfull.
            if(hp < 24)
            {
                //Tar värdet för pwr och sänker detta med differensen mellan värdet av hp och 25.
                pwr -= hp - 25;
                //Kollar om pwr är mindre än eller lika med 0, om detta är true blir fightern värdelös, och får därför en liten boost.
                if(pwr <= 0)
                {
                    //For loop som körs antalet gånger som differensen mellan hp och 25.
                    for (int i = 0; i < hp-25; i++)
                    {
                        //Lägger till 1 på variabeln pwr.
                        pwr++;
                    }
                }
            }
        }
    }
}
