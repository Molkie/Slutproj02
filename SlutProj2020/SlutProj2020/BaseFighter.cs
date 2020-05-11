using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProj2020
{
    class Fighter
    {
        //Dessa värden på variablerna är enbart placeholders.
        //Namn
        protected string name;
        //Hälsa
        protected int hp = 10;
        //Power, kraft
        protected int pwr = 1;

        //Array för olika namn som fightern kan ha.
        protected string[] names = { "Max", "George", "Lasse", "Klara", "Holly" };

        //Metod som returnar fighterns namn
        public string GetName()
        {
            //Returnerar värdet av fighterns namn
            return (name);
        }

        //Metod som returnerar hp.
        public int GetHP()
        {
            //Returnerar värdet av fighterns hp
            return (hp);
        }

        //Metod för fighterns specialattack
        public virtual int Special()
        {
            //Returnerar värdet av fighters pwr
            return (pwr);
        }

        //Metod för att fightern ska ta skada. Använder int damage som parameter
        public void TakeDamage(int damage)
        {
            //Tar fighterns hp minus parametern damage och definerar detta som fighterns hp.
            hp = hp - damage;
        }
    }
}
