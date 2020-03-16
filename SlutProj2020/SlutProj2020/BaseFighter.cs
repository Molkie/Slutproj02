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
        protected int hp;
        //Level
        protected int lvl;
        //Power, kraft
        protected int pwr;
        //Defense, försvar
        protected int dfn;
        //Typ
        protected int type;

        //Metod för fighterns specialattack
        protected virtual int Special()
        {
            Console.WriteLine("Special Attack!");
            return (pwr * 5);
        }

        //Metod för att fightern ska ta skada. Använder int damage som parameter
        void TakeDamage(int damage)
        {
            //Tar fighterns hp minus parametern damage
            hp -= damage;
            //Kollar om hp är under eller lika med 0, om true kallas metoden Death();
            if(damage <= 0)
            {
                Death();
            }
        }

        //Metod för att levla upp
        void LevelUp()
        {
            lvl++;
        }

        //Metod för att sätta fighterns namn
        void SetName(string input)
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
