using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Reactions
{
    internal class Player_Reactions
    {
        public List<string> Cupid_Choice { get; set; }
        public string Seer_Choice { get; set; }
        public string Werewolves_Choice { get; set; }
        public object[][] Witch_Choice { get; set; }

        /// <summary>
        /// Main Func
        /// </summary>
        /// <param name="players"></param>
        /// <param name="role"></param>
        /// <param name="werewolf_AI"></param>
        /// <param name="death_List"></param>
        /// <param name="witch_Potions"></param>
        public Player_Reactions(string[] players, string role, string werewolf_AI, List<string> death_List, int[] witch_Potions)
        {
            switch (role)
            {
                case var value when value == "Werewolf": { Werewolves_Choice = Werewolf_React(players, werewolf_AI); break; }
                case var value when value == "Seer": { Seer_Choice = Seer_React(players); break; }
                case var value when value == "Witch": { Witch_Choice = Witch_React(death_List, players, witch_Potions); break; }
                case var value when value == "Cupid": { Cupid_Choice = Cupid_React(players); break; }
            }
        }

        /// <summary>
        /// Werewolf Reaction
        /// </summary>
        /// <param name="players"></param>
        /// <param name="werewolf_AI"></param>
        /// <returns>Choice of Werewolves</returns>
        public string Werewolf_React(string[] players, string werewolf_AI)
        {
            string choice = null, AI_Choice;
            Random random = new Random();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.Write("You are a werewolf. Your mate is ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(werewolf_AI);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(". Here is the list of the players : ");
            Console.WriteLine();
            Console.ResetColor();

            foreach (string name in players)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            AI_Choice = players[random.Next(0, players.Length)];
            Console.Write(werewolf_AI);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" chose to kill ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(AI_Choice);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(". Do you agree? (Y/N) : ");
            Console.ResetColor();
            switch (Console.ReadLine())
            {
                case var value when value == "Y" || value == "y": { choice = AI_Choice; } break;
                case var value when value == "N" || value == "n": {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Who would you like to kill instead? ");
                        Console.ResetColor();
                        choice = Console.ReadLine();

                        while (!players.Contains(choice))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("This player doesn't exist. Please try again : ");
                            Console.ResetColor();
                            choice = Console.ReadLine();
                        }
                    } break;
            }
            return choice;
        }

        /// <summary>
        /// Seer Reaction
        /// </summary>
        /// <param name="players"></param>
        /// <returns>Choice of Seer</returns>
        public string Seer_React(string[] players)
        {
            string choice;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();
            Console.WriteLine("You are the seer. Here is the list of the players : ");
            Console.WriteLine();
            Console.ResetColor();

            foreach (string name in players)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            Console.Write("Enter the name of the player you want to reveal the role of : ");
            choice = Console.ReadLine();

            while (!players.Contains(choice))
            {
                Console.Write("This player doesn't exist. Please try again : ");
                choice = Console.ReadLine();
            }

            return choice;
        }

        /// <summary>
        /// Witch Reaction
        /// </summary>
        /// <param name="death_List"></param>
        /// <param name="players"></param>
        /// <param name="potions"></param>
        /// <returns>Choices of Witch</returns>
        public object[][] Witch_React(List<string> death_List, string[] players, int[] potions)
        {
            int? choice;
            int output;
            string revive;
            string kill;
            object[][] final_Choice =
            {
                new object[] { null },
                new string[] { null }
            };

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine("You are the witch. Here is the list of the players that are dead tonight : ");
            Console.WriteLine();
            Console.ResetColor();

            foreach (string name in death_List)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("What would you like to do for tonight?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1 - Revive someone");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2 - Kill someone");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("3 - Do nothing\n");
            Console.ResetColor();
            Console.WriteLine("\t...");
            Console.WriteLine("\n");
            choice = int.TryParse(Console.ReadLine(), out output) ? output : null;

            while(choice == null || choice > 3 || choice < 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Wrong input. Try again : ");
                Console.ResetColor();
                choice = int.TryParse(Console.ReadLine(), out output) ? output : null;
            }
            while (choice == 1 && potions[0] == 0 || choice == 2 && potions[1] == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("You are out of this kind of potion. Try again : ");
                Console.ResetColor();
                choice = int.TryParse(Console.ReadLine(), out output) ? output : null;
            }

            final_Choice[0][0] = choice;

            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    Console.Write("Who would you like to revive? ");
                    revive = Console.ReadLine();

                    while (!death_List.Contains(revive))
                    {
                        Console.Write("This player doesn't exist. Please try again : ");
                        revive = Console.ReadLine();
                    }

                    final_Choice[1][0] = revive;
                    break;

                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Here is the list of players : ");
                    foreach (string name in players)
                    {
                        Console.WriteLine(name);
                    }
                    Console.WriteLine();
                    Console.Write("Who would you like to kill? ");
                    kill = Console.ReadLine();

                    while (!players.Contains(kill))
                    {
                        Console.Write("This player doesn't exist. Please try again : ");
                        kill = Console.ReadLine();
                    }
                    while (death_List.Contains(kill))
                    {
                        Console.Write("This player is already dead. Please try again : ");
                        kill = Console.ReadLine();
                    }

                    final_Choice[1][0] = kill;
                    break;
            }
            return final_Choice;
        }

        /// <summary>
        /// Cupid Reaction
        /// </summary>
        /// <param name="players"></param>
        /// <returns>Lovers</returns>
        public List<string> Cupid_React(string[] players)
        {
            string choice, choice2;
            List<string> lovers = new List<string>();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("You are cupidon. Here is the list of the players : ");
            Console.WriteLine();
            Console.ResetColor();

            foreach(string name in players)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            Console.Write("Enter the first name : ");
            choice = Console.ReadLine();

            while (!players.Contains(choice))
            {
                Console.Write("This player doesn't exist. Please try again : ");
                choice = Console.ReadLine();
            }
            lovers.Add(choice);

            Console.Write("Enter the second name : ");
            choice2 = Console.ReadLine();

            while (!players.Contains(choice2))
            {
                Console.Write("This player doesn't exist. Please try again : ");
                choice2 = Console.ReadLine();
            }
            while (lovers.Contains(choice2))
            {
                Console.Write("You already selected this player. Please try again : ");
                choice2 = Console.ReadLine();
            }
            lovers.Add(choice2);

            return lovers;
        }
    }
}
