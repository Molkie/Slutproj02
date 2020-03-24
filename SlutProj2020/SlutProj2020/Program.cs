using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProj2020
{
    class Program
    {
        //Lista för lag A
        static List<Fighter> TeamA = new List<Fighter>();
        //Lista för lag B
        static List<Fighter> TeamB = new List<Fighter>();
        //Kö för lag A
        static Queue<Fighter> NextFighterA = new Queue<Fighter>();
        //Kö för lag B
        static Queue<Fighter> NextFighterB = new Queue<Fighter>();

        //Main Metod
        static void Main(string[] args)
        {
            //Kallar metoden för startmenyn
            StartMenu();
            //Köar alla fighters
            QueueFighters();
            //Kallar på metoden för fight så länge som det finns fighters vid liv
            Fight();

            
            Console.ReadLine();
        }

        //Metod för startmeny
        static void StartMenu()
        {
            //Instruktioner till användaren
            Console.WriteLine("How many fighters do you want for each team?");
            //Kallar metoden Check Answer för att få ett godkänt svar i form av en int med ett värde över 0. Sparar detta nummer i int x.
            int x = CheckAnswer(10);

            //For Loop som genererar det önskade antalet fighters av olika sorter.
            for (int t = 0; t < 2; t++)
            {
                for (int i = 0; i < x; i++)
                {
                    Console.WriteLine("Team " + t);
                    //Skriver ut vilken fighter som ska väljas
                    Console.WriteLine("Fighter " + (i + 1));
                    //Kallar metoden chooseFighter som skriver ut instruktioner till användaren.
                    chooseFighter();
                    //Kallar metoden CheckAnswer med parametern maxAmount = 4.
                    int ans = 1 + CheckAnswer(4);
                    if (ans == 1)
                    {
                        Boxer newFighter = new Boxer();
                        AddFighterToTeam(newFighter, t);
                    }
                    else if (ans == 2)
                    {
                        MuayThai newFighter = new MuayThai();
                        AddFighterToTeam(newFighter, t);
                    }
                    else if (ans == 3)
                    {
                        Wrestler newFighter = new Wrestler();
                        AddFighterToTeam(newFighter, t);
                    }
                    else if (ans == 4)
                    {
                        BJJ newFighter = new BJJ();
                        AddFighterToTeam(newFighter, t);
                    }
                }        
            }
        }

        static void AddFighterToTeam(Fighter fighter, int team)
        {
            if(team == 0)
            {
                TeamA.Add(fighter);
            }
            else if(team == 1)
            {
                TeamB.Add(fighter);
            }
        }

        static void chooseFighter()
        {
            Console.WriteLine("What type of fighter do you want?");
            Console.WriteLine("Strikers:");
            Console.WriteLine("1. Boxer");
            Console.WriteLine("2. Muay Thai");
            Console.WriteLine("Grappler:");
            Console.WriteLine("3. Wrestler");
            Console.WriteLine("4. Brazilian Jiu Jitsu");
        }

        //Metod för att dubbelkolla svaret
        private static int CheckAnswer(int maxAmount)
        {
            //Låter användaren skriva in ett svar
            string ans = Console.ReadLine();
            //Kollar om svaret går att tryparsa.
            bool succes = int.TryParse(ans, out int output);
            //Kollar om succes är true och om output är över maxAmount.
            while (succes != true || output < 0 || output > maxAmount)
            { 
                //Ger ett felmedelande
                Console.WriteLine("Thats not a valid answer.");
                ans = Console.ReadLine();
                //Kollar om svaret går att tryparsa.
                succes = int.TryParse(ans, out output);
            }
            Console.Clear();
            //Returnar output
            return (output);
        }

        //Metod för att köa alla fighters i korrekt kö.
        static void QueueFighters()
        {
            //For loop som körs för varje fighter.
            //Lag A
            for (int i = 0; i < TeamA.Count; i++)
            {
                //Köar lag A
                NextFighterA.Enqueue(TeamA[i]);

            }
            //Lag B
            for (int j = 0; j < TeamB.Count; j++)
            {
                //Köar lag B
                NextFighterB.Enqueue(TeamB[j]);
            }
        }

        static void Fight()
        {
            Fighter fighter1 = NextFighterA.Dequeue();
            Fighter fighter2 = NextFighterB.Dequeue();

            while(fighter1.hp > 1 && fighter2.hp > 1)
            {
                //Fighters attackerar varandra
                fighter1.TakeDamage(fighter2.Special());
                fighter2.TakeDamage(fighter1.Special());
                Console.WriteLine(fighter2 + " attacks " + fighter1 + " for " + fighter2.Special() + "damage!" + fighter1 + " has " + fighter1.hp + "hp!");
                Console.WriteLine(fighter1 + " attacks " + fighter2 + " for " + fighter1.Special() + "damage!" + fighter2 + " has " + fighter2.hp + "hp!");
                Console.ReadLine();
            }
        }
    }
}
