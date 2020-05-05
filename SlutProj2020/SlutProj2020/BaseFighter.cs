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
        protected string name;
        //Hälsa
        protected int hp = 10;
        //Power, kraft
        protected int pwr = 1;

        //Metod som returnar fighterns namn
        public string GetName()
        {
            return (name);
        }

        //Metod som returnerar hp.
        public int GetHP()
        {
            return (hp);
        }

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
