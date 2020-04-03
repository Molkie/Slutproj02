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
        //Stack som fungerar som "graveyard" där alla döda fighters läggs på varandra
        static Stack<Fighter> graveyard = new Stack<Fighter>();

        //Main Metod
        static void Main(string[] args)
        {
            //Kallar metoden för startmenyn
            StartMenu();
            //Köar alla fighters
            QueueFighters();
            //Kallar på metoden för fight så länge som det finns fighters vid liv
            Fight();
            //Hindrar programet från att avslutas abrupt
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
            //Körs för varge lag
            for (int t = 0; t < 2; t++)
            {
                //Körs för varge fighter i laget
                for (int i = 0; i < x; i++)
                {
                    //Skriver ut vilket lag som är aktuellt
                    Console.WriteLine("Team " + (1 + t));
                    //Skriver ut vilken fighter som ska väljas
                    Console.WriteLine("Fighter " + (i + 1));
                    //Kallar metoden chooseFighter som skriver ut instruktioner till användaren.
                    chooseFighter();
                    //Kallar metoden CheckAnswer med parametern maxAmount = 4.
                    int ans = CheckAnswer(4);
                    //Kollar vilket svar användaren skrev och lägger till en typ av fighter som motsvarar den siffran.
                    //Svaret 1. Lägger till en boxare.
                    if (ans == 1)
                    {
                        Boxer newFighter = new Boxer();
                        AddFighterToTeam(newFighter, t);
                    }
                    //Svaret 2. Lägger till en Thaiboxare.
                    else if (ans == 2)
                    {
                        MuayThai newFighter = new MuayThai();
                        AddFighterToTeam(newFighter, t);
                    }
                    //Svaret 3. Lägger till en brottare.
                    else if (ans == 3)
                    {
                        Wrestler newFighter = new Wrestler();
                        AddFighterToTeam(newFighter, t);
                    }
                    //Svaret 4. Lägger till en BJJ utövare.
                    else if (ans == 4)
                    {
                        BJJ newFighter = new BJJ();
                        AddFighterToTeam(newFighter, t);
                    }
                }        
            }
        }

        //Metod vars syfte är att lägga till fighters i rätt lag. Har fighter och team som parametrar.
        static void AddFighterToTeam(Fighter fighter, int team)
        {
            //Kollar vilket lag fighern ska vara och lägger till den i rätt lag (team 0 = teamA, team 1 == teamB)
            if(team == 0)
            {
                TeamA.Add(fighter);
            }
            else if(team == 1)
            {
                TeamB.Add(fighter);
            }
        }

        //Metod som skriver ut vilka typer av fighters man kan välja mellan
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

        //Metod för själva fighterna
        static void Fight()
        {
            //Loopen körs så länge det finns fighters i båda lagen
            while (NextFighterB.Count != 0 && NextFighterA.Count != 0)
            {
                //Variabel för vilken runda som är aktuell
                int round = 1;
                //Skapar två instanser av klassen fighter och definerar dessa som den fighter först i kön i vardera lag.
                Fighter fighter1 = NextFighterA.Dequeue();
                Fighter fighter2 = NextFighterB.Dequeue();

                while (fighter1.hp > 1 && fighter2.hp > 1)
                {
                    //Skriver ut vilken runda det är och vilka fighters som slåss
                    Console.WriteLine(fighter1.name + " vs " + fighter2.name);
                    Console.WriteLine("Round: " + round);
                    //Fighters attackerar varandra genom att kalla metoden TakeDamage med parametern från fighterns specialattack
                    fighter1.TakeDamage(fighter2.Special());
                    fighter2.TakeDamage(fighter1.Special());
                    //Skriver ut skadan så att användaren vet vad som händer
                    Console.WriteLine(fighter2.name + " attacks " + fighter1.name + " for " + fighter2.Special() + " damage! " + fighter1.name + " has " + fighter1.hp + " hp!");
                    Console.WriteLine(fighter1.name + " attacks " + fighter2.name + " for " + fighter1.Special() + " damage! " + fighter2.name + " has " + fighter2.hp + " hp!");

                    //Om fighter1 dör printas ett meddelande ut som förmedlar detta, sedan läggs fighter2 tillbaka längst bak i kön.
                    if (fighter1.hp < 1 && fighter2.hp > 0)
                    {
                        Console.WriteLine(fighter1.name + " has died!");
                        //Lägger till den levande fightern (fighter2) längst bak i kön.
                        NextFighterB.Enqueue(fighter2);
                        //Lägger till den dödade fightern (fighter1) i stack graveyard.
                        graveyard.Push(fighter1);
                    }
                    //Om fighter2 dör printas ett meddelande ut som förmedlar detta, sedan läggs fighter1 tillbaka längst bak i kön.
                    else if (fighter2.hp < 1 && fighter1.hp > 0)
                    {
                        Console.WriteLine(fighter2.name + " has died!");
                        //Lägger till den levande fightern (fighter1) längst bak i kön.
                        NextFighterA.Enqueue(fighter1);
                        //Lägger till den dödade fightern (fighter2) i stack graveyard.
                        graveyard.Push(fighter2);
                    }
                    //Om båda fighters dör läggs båda till i graveyard, men ingen hamnar längst bak i kön.
                    else if(fighter1.hp < 1 && fighter2.hp < 1)
                    {
                        Console.WriteLine("Both fighters has died!");
                        //Lägger till båda fighters i graveyard.
                        graveyard.Push(fighter1);
                        graveyard.Push(fighter2);
                    }
                    //Lägger till ett på variabeln round.
                    round++;
                    //Städar upp konsollen
                    Console.ReadLine();
                    Console.Clear();
                }
                //När någon av lagen får slut på fighters kollar denna algoritm vilket lag som van
                //Om båda lagen har slut på fighters vinner ingen
                if (NextFighterA.Count == 0 && NextFighterB.Count == 0)
                {
                    Console.WriteLine("No one wins! Say no to fighting!");
                    //Kallar metoden graveyard
                    Graveyard();
                }
                //Om LagA har slut på fighters, men lag B har fler än 0 vinner lag B
                else if (NextFighterA.Count == 0 && NextFighterB.Count > 0)
                {
                    Console.WriteLine("Team B wins!");
                    //Kallar metoden graveyard
                    Graveyard();
                }
                //Om LagB har slut på fighters, men lag A har fler än 0 vinner lag B
                else if (NextFighterB.Count == 0 && NextFighterA.Count > 0)
                {
                    Console.WriteLine("Team A wins!");
                    //Kallar metoden graveyard
                    Graveyard();
                }
            }
        }

        //Metod för att printa ut vilken fighter som dog sist
        static void Graveyard()
        {
            //Printar graveyard.pop
            Console.WriteLine("Last man to loose his life was " + graveyard.Pop().name);
        }
    }
}
