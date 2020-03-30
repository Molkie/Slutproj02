using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProj2020
{
    class Wrestler : Grappler
    {
        //public override för metoden Special. Här är fighterns specialattack
        public override int Special()
        {
            Console.WriteLine("Special Attack!");
            hp--;
            return (pwr * 4);
        }
    }
}
