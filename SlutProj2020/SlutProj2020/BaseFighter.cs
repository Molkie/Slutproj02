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
        //Level
        protected int lvl;
        //Power, kraft
        protected int pwr = 1;
        //Defense, försvar
        protected int dfn;
        //Typ
        protected int type;

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

        //Metod för att levla upp
        void LevelUp()
        {
            lvl++;
        }

        //Metod för att sätta fighterns namn
        public void SetName(string input)
        {
            name = input;
        }

        //Metod för att få fighterns namn
        string GetName()
        {
            return (name);
        }

        //Metod för fighterns död. Kallas om hp är under eller lika med 0.
        void Death()
        {
            //Skriver att fightern är död.
            Console.WriteLine(name + " has died!");
        }
    }
}
