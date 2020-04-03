using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProj2020
{
    class Fighter
    {
        //Namn
        public string name;
        //Hälsa
        public int hp = 10;
        //Power, kraft
        protected int pwr = 1;


        //Metod för fighterns specialattack
        public virtual int Special()
        {
            return (pwr);
        }

        //Metod för att fightern ska ta skada. Använder int damage som parameter
        public void TakeDamage(int damage)
        {
            //Tar fighterns hp minus parametern damage
            hp = hp - damage;
        }
    }
}
