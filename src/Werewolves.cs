using System;
using System.Text;
using Werewolf.Reactions;
using Werewolf.Starter_Classes;

namespace Werewolf
{
    internal class Main_Class
    {

        /// <summary>
        /// Function Main, used to launch everything and make everything works correctly.
        /// </summary>
        public static void Main()
        {
         List<string> role_List = new List<string>(), name_List = new List<string>(), death_List = new List<string>();
         string[] display_Names = new string[8];
         string[] display_Roles = new string[8];
         string main_Role;
            int night = 2;
            List<string> lovers = new List<string>();
            int[] witch_Potions = { 1, 1 };
         Players_Class main_Player = new Players_Class(role_List);
         main_Role = main_Player.ReturnRole();
         Definition_Class AI_1 = new Definition_Class(name_List, main_Player.pulled_Roles);
         Definition_Class AI_2 = new Definition_Class(AI_1.Names, AI_1.Roles);
         Definition_Class AI_3 = new Definition_Class(AI_2.Names, AI_2.Roles);
         Definition_Class AI_4 = new Definition_Class(AI_3.Names, AI_3.Roles);
         Definition_Class AI_5 = new Definition_Class(AI_4.Names, AI_4.Roles);
         Definition_Class AI_6 = new Definition_Class(AI_5.Names, AI_5.Roles);
         Definition_Class AI_7 = new Definition_Class(AI_6.Names, AI_6.Roles);
         int i = 0;

            foreach(string name in AI_7.Names)
            {
                display_Names[i] = name;
                i++;
            }
            i = 0;
            foreach (string role in AI_7.Roles)
            {
                display_Roles[i] = role;
                i++;
            }

            main_Player.Name = Intro();
            display_Names[7] = main_Player.Name;
            display_Roles[7] = main_Player.ReturnRole();
            Displayer(main_Role, main_Player.Name, display_Names);
            Console.WriteLine("Press ENTER to continue");
            Console.ReadKey();
            Console.Clear();
            Displayer(main_Role, main_Player.Name, display_Names);
            Night_1(display_Names, display_Roles, ref death_List, main_Role, main_Player.Name, ref witch_Potions, ref lovers);
            Console.Clear();
            Displayer(main_Role, main_Player.Name, display_Names);
            Console.WriteLine($"Tonight, {death_List.Count} {{0}} {{1}} dead. {{2}}",
                death_List.Count == 1 ? "person" : "people", death_List.Count == 1 ? "is" : "are", death_List.Count == 0 ? "" : "Here is who they are and their role: ");
            Console.WriteLine();
            for(int q = 0; q < display_Names.Length; q++)
            {
                if (death_List.Contains(display_Names[q]))
                {
                    Console.Write(display_Names[q] + " | ");
                    ConsoleColor color = ChooseColor(display_Roles[q]);
                    Console.ForegroundColor = color;
                    Console.WriteLine(display_Roles[q]);
                    Console.ResetColor();
                }
            }
            for (int j = 0; j < display_Names.Length; j++)
            {
                if (death_List.Contains(display_Names[j]))
                {
                    List<string> x = display_Names.ToList();
                    x.Remove(display_Names[j]);
                    display_Names = x.ToArray();
                    x = display_Roles.ToList();
                    x.Remove(display_Roles[j]);
                    display_Roles = x.ToArray();
                }
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Press ENTER to continue");
            Console.ReadKey();
            End(main_Player.Name, death_List, main_Player.ReturnRole(), display_Names, display_Roles);
            HunterAI(death_List, display_Names, display_Roles);
            death_List.Clear();
            Console.Clear();

            do
            {
                if (display_Roles.Length <= 3) End(main_Player.Name, death_List, main_Player.ReturnRole(), display_Names, display_Roles);
                Displayer(main_Role, main_Player.Name, display_Names);
                Day(display_Names, display_Roles, ref death_List, main_Role, main_Player.Name);
                    Console.Clear();
                Displayer(main_Role, main_Player.Name, display_Names);
                Console.WriteLine("Today, the village decided to eliminate this/those player(s) : ");
                for (int z = 0; z < display_Names.Length; z++)
                {
                    if (death_List.Contains(display_Names[z]))
                    {
                        ConsoleColor color = ChooseColor(display_Roles[z]);
                        Console.Write(display_Names[z] + " | ");
                        Console.ForegroundColor = color;
                        Console.WriteLine(display_Roles[z]);
                        Console.ResetColor();
                    }
                }
                for (int o = 0; o < display_Names.Length; o++)
                {
                    if (death_List.Contains(display_Names[o]))
                    {
                        if (lovers.Contains(display_Names[o]))
                        {
                            for (int d = 0; d < display_Names.Length; d++)
                            {
                                if (lovers.Contains(display_Names[d]))
                                {
                                    List<string> y = display_Names.ToList();
                                    y.Remove(display_Names[d]);
                                    display_Names = y.ToArray();
                                    y = display_Roles.ToList();
                                    y.Remove(display_Roles[d]);
                                    display_Roles = y.ToArray();
                                }
                            }
                        }
                        List<string> x = display_Names.ToList();
                        x.Remove(display_Names[o]);
                        display_Names = x.ToArray();
                        x = display_Roles.ToList();
                        x.Remove(display_Roles[o]);
                        display_Roles = x.ToArray();
                    }
                }
                Console.ResetColor();
                End(main_Player.Name, death_List, main_Player.ReturnRole(), display_Names, display_Roles);
                HunterAI(death_List, display_Names, display_Roles);
                if (!display_Roles.Contains("Werewolf")) Win();
                death_List.Clear();
                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue");
                Console.ReadKey();
                Console.Clear();
                Displayer(main_Role, main_Player.Name, display_Names);
                Night(display_Names, display_Roles, ref death_List, main_Role, main_Player.Name, ref witch_Potions, lovers, night);
                Console.Clear();
                Displayer(main_Role, main_Player.Name, display_Names);
                Console.WriteLine($"Tonight, {death_List.Count} {{0}} {{1}} dead. {{2}}",
                    death_List.Count == 1 ? "person" : "people", death_List.Count == 1 ? "is" : "are", death_List.Count == 0 ? "" : "Here is who they are and their role: ");
                Console.WriteLine();
                for (int a = 0; a < display_Names.Length; a++)
                {
                    if (death_List.Contains(display_Names[a]))
                    {
                        ConsoleColor color = ChooseColor(display_Roles[a]);
                        Console.Write(display_Names[a] + " ");
                        Console.ForegroundColor = color;
                        Console.WriteLine(display_Roles[a]);
                        Console.ResetColor();
                    }
                }
                for (int s = 0; s < display_Names.Length; s++)
                {
                    if (death_List.Contains(display_Names[s]))
                    {
                        List<string> x = display_Names.ToList();
                        x.Remove(display_Names[s]);
                        display_Names = x.ToArray();
                        x = display_Roles.ToList();
                        x.Remove(display_Roles[s]);
                        display_Roles = x.ToArray();
                    }
                }
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue");
                Console.ReadKey();
                End(main_Player.Name, death_List, main_Player.ReturnRole(), display_Names, display_Roles);
                HunterAI(death_List, display_Names, display_Roles);
                death_List.Clear();
                Console.Clear();
                night++;
            } while (true);
        }

        /// <summary>
        /// Function used to display the winning message.
        /// </summary>
        public static void Win()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You won! Game over!");
            Console.ResetColor();
            Environment.Exit(0x2);
        }

        /// <summary>
        /// Function to run every "day" phases of the game.
        /// </summary>
        /// <param name="players_Names">The names of every players in an array</param>
        /// <param name="roles">The roles of every players in an array</param>
        /// <param name="death_List">The list of dead people</param>
        /// <param name="player_Role">The role of the main player</param>
        /// <param name="player_Name">The name of the main player</param>
        public static void Day(string[] players_Names, string[] roles, ref List<string> death_List,
            string player_Role, string player_Name)
        {
            string choice;
            int[] votes = new int[roles.Length];
            int? index = null;
            Random random = new Random();
            int index_Elimination = 0;

            if (!roles.Contains("Werewolf")) Win();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The day is starting, people may start voting.");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("Here is the list of alive players : ");

            if (players_Names.Contains(player_Name))
            {
                List<string> x = players_Names.ToList();
                x.Remove(player_Name);
                players_Names = x.ToArray();
            }

            foreach (string name in players_Names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            if (!players_Names.Contains(player_Name))
            {
                List<string> x = players_Names.ToList();
                x.Add(player_Name);
                players_Names = x.ToArray();
            }

            Console.Write("Who would you like to vote for? ");
            choice = Console.ReadLine();

            while (!players_Names.Contains(choice))
            {
                Console.Write("This player doesn't exist. Please try again : ");
                choice = Console.ReadLine();
            }

            while(choice == player_Name)
            {
                Console.Write("You can't vote for yourself. Please try again : ");
                choice = Console.ReadLine();
            }

            for(int i = 0; i < players_Names.Length; i++)
            {
                if (players_Names[i] == choice) index = i;
            }

            for (int j = 0; j < votes.Length; j++)
            {
                votes[j] = 0;
            }

            if (player_Role == "Crow")
            {
                votes[(int)index]++;
                votes[(int)index]++;
            }
            else
            {
                votes[(int)index]++;
            }

            if (players_Names.Contains(player_Name))
            {
                List<string> x = players_Names.ToList();
                x.Remove(player_Name);
                players_Names = x.ToArray();
            }

            for (int k = 0; k < roles.Length; k++)
            {
                index = random.Next(0, players_Names.Length);
                List<string> x;
                if (!players_Names.Contains(player_Name))
                {
                    x = players_Names.ToList();
                    x.Add(player_Name);
                    players_Names = x.ToArray();
                }
                while (players_Names[(int)index] == players_Names[k])
                {
                    x = players_Names.ToList();
                    x.Remove(player_Name);
                    players_Names = x.ToArray();
                    index = random.Next(0, players_Names.Length);
                    x = players_Names.ToList();
                    x.Add(player_Name);
                    players_Names = x.ToArray();
                }
                if (roles[k] == "Crow")
                {
                    votes[(int)index]++;
                    votes[(int)index]++;
                }
                else
                {
                    votes[(int)index]++;
                }
            }

            Console.Clear();
            Displayer(player_Role, player_Name, players_Names);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The vote session is over. Let's see who is getting eliminated today...");
            Thread.Sleep(3000);

            for(int l = 0; l < votes.Length; l++)
            {
                if (l == 0) index_Elimination = votes[l];
                else if (votes[l] > index_Elimination) index_Elimination = votes[l];
            }

            death_List.Add(players_Names[index_Elimination]);
        }

        /// <summary>
        /// Function to run every nights (except the first one).
        /// </summary>
        /// <param name="players_Names">The names of every players</param>
        /// <param name="roles">The roles of every players</param>
        /// <param name="death_List">The list of dead people</param>
        /// <param name="player_Role">The main player's role</param>
        /// <param name="player_Name">The main player's name</param>
        /// <param name="witch_Potions">The potions available for the witch</param>
        /// <param name="lovers">The 2 lovers</param>
        /// <param name="night">What night is it</param>
        public static void Night(string[] players_Names, string[] roles, ref List<string> death_List,
            string player_Role, string player_Name, ref int[] witch_Potions, List<string> lovers, int night)
        {
            string other_Werewolf = null;
            List<string> AIWWs = new List<string>();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Night #{night} is falling... The village falls asleep.");
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.Clear();
            Displayer(player_Role, player_Name, players_Names);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("The Seer ");
            Console.ResetColor();
            Console.WriteLine("wakes up. They will be allowed to take a look at one card...");

            if (player_Role == "Seer")
            {
                if (players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Remove(player_Name);
                    players_Names = x.ToArray();
                }
                if (roles.Contains(player_Role))
                {
                    List<string> x = roles.ToList();
                    x.Remove(player_Role);
                    roles = x.ToArray();
                }

                Player_Reactions Seer_Reaction = new Player_Reactions(players_Names, player_Role, other_Werewolf, death_List, witch_Potions);

                switch (Seer_Reaction.Seer_Choice)
                {
                    case var value when value == players_Names[0]: { SeerDisplayer(0, players_Names, roles); break; }
                    case var value when value == players_Names[1]: { SeerDisplayer(1, players_Names, roles); break; }
                    case var value when value == players_Names[2]: { SeerDisplayer(2, players_Names, roles); break; }
                    case var value when value == players_Names[3]: { SeerDisplayer(3, players_Names, roles); break; }
                    case var value when value == players_Names[4]: { SeerDisplayer(4, players_Names, roles); break; }
                    case var value when value == players_Names[5]: { SeerDisplayer(5, players_Names, roles); break; }
                    case var value when value == players_Names[6]: { SeerDisplayer(6, players_Names, roles); break; }
                }
                Displayer(player_Role, player_Name, players_Names);
            }
            else
            {
                Thread.Sleep(5000);
            }

            Console.Clear();
            Displayer(player_Role, player_Name, players_Names);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("The Werewolves ");
            Console.ResetColor();
            Console.WriteLine("wakes up. They will choose who to kill for tonight...");

            if (player_Role == "Werewolf")
            {
                if (players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Remove(player_Name);
                    players_Names = x.ToArray();
                }
                if (roles.Contains(player_Role))
                {
                    List<string> x = roles.ToList();
                    x.Remove(player_Role);
                    roles = x.ToArray();
                }

                for (int i = 0; i < roles.Length; i++)
                {
                    if (roles[i] == "Werewolf")
                    {
                        other_Werewolf = players_Names[i];
                        List<string> x = roles.ToList();
                        x.Remove(roles[i]);
                        roles = x.ToArray();
                        x = players_Names.ToList();
                        x.Remove(players_Names[i]);
                        players_Names = x.ToArray();
                    }
                }
                Player_Reactions Wereworlf_Reaction = new Player_Reactions(players_Names, player_Role, other_Werewolf, death_List, witch_Potions);
                if (lovers.Contains(Wereworlf_Reaction.Werewolves_Choice))
                {
                    foreach (string name in lovers)
                    {
                        death_List.Add(name);
                    }
                }
                death_List.Add(Wereworlf_Reaction.Werewolves_Choice);

                List<string> y = roles.ToList();
                y.Add("Werewolf");
                roles = y.ToArray();
                y = players_Names.ToList();
                y.Add(other_Werewolf);
                players_Names = y.ToArray();
            }
            else
            {
                if (!players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Add(player_Name);
                    players_Names = x.ToArray();
                }
                if (!roles.Contains(player_Role))
                {
                    List<string> x = roles.ToList();
                    x.Add(player_Role);
                    roles = x.ToArray();
                }
                for (int i = 0; i < roles.Length; i++)
                {
                    if (roles[i] == "Werewolf")
                    {
                        AIWWs.Add(players_Names[i]);
                        List<string> x = roles.ToList();
                        x.Remove(roles[i]);
                        roles = x.ToArray();
                        x = players_Names.ToList();
                        x.Remove(players_Names[i]);
                        players_Names = x.ToArray();
                    }
                }
                Reactions_AI Werewolf_Reaction_AI = new Reactions_AI(players_Names, "Werewolf", death_List, witch_Potions);
                if (lovers.Contains(Werewolf_Reaction_AI.Werewolf_Choice_AI))
                {
                    foreach (string name in lovers)
                    {
                        death_List.Add(name);
                    }
                }
                death_List.Add(Werewolf_Reaction_AI.Werewolf_Choice_AI);
                Thread.Sleep(5000);
            }

            Console.Clear();
            Displayer(player_Role, player_Name, players_Names);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("The Witch ");
            Console.ResetColor();
            Console.WriteLine("wakes up. They will decide if they kill someone, reanimate someone or do nothing.");

            if (player_Role == "Witch")
            {
                if (players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Remove(player_Name);
                    players_Names = x.ToArray();
                }

                Player_Reactions Witch_Reaction = new Player_Reactions(players_Names, player_Role, other_Werewolf, death_List, witch_Potions);
                switch (Witch_Reaction.Witch_Choice[0][0])
                {
                    case 1:
                        death_List.Remove((string)Witch_Reaction.Witch_Choice[1][0]);
                        witch_Potions[0]--;
                        break;

                    case 2:
                        death_List.Add((string)Witch_Reaction.Witch_Choice[1][0]);
                        witch_Potions[1]--;
                        break;
                }
            }
            else
            {
                if (!players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Add(player_Name);
                    players_Names = x.ToArray();
                }

                Reactions_AI Witch_Reaction_AI = new Reactions_AI(players_Names, "Witch", death_List, witch_Potions);
                switch (Witch_Reaction_AI.Witch_Choice_AI[0][0])
                {
                    case 1:
                        death_List.Remove((string)Witch_Reaction_AI.Witch_Choice_AI[1][0]);
                        witch_Potions[0]--;
                        break;

                    case 2:
                        death_List.Add((string)Witch_Reaction_AI.Witch_Choice_AI[1][0]);
                        witch_Potions[1]--;
                        break;
                }
                Thread.Sleep(5000);
            }
        }

        /// <summary>
        /// Function to execute when the hunter is dead and is an AI.
        /// </summary>
        /// <param name="death_List">The list of dead people</param>
        /// <param name="names">The names of every players</param>
        /// <param name="roles">The roles of every players</param>
        public static void HunterAI(List<string> death_List, string[] names, string[] roles)
        {
            for(int i = 0; i < names.Length; i++)
            {
                if (death_List.Contains(names[i]))
                {
                    if (roles[i] == "Hunter")
                    {
                        string choice;
                        Random random = new Random();
                        int? index = null;

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Wait... {names[i]} was the hunter? They still have a chance to take their revenge...");
                        Console.ResetColor();
                        Console.WriteLine();

                        choice = names[random.Next(0, names.Length)];

                        while (!names.Contains(choice) || choice == names[i])
                        {
                            choice = names[random.Next(0, names.Length)];
                        }

                        for (int j = 0; j < names.Length; j++)
                        {
                            if (names[j] == choice) index = j;
                        }

                        Thread.Sleep(5000);
                        Console.Beep();
                        Console.WriteLine($"Boom... {choice} was {roles[(int)index]}");
                        Console.WriteLine();
                    }
                }
            }
        }

        /// <summary>
        /// Function to run when the main player dies.
        /// </summary>
        /// <param name="player">The name of the main player</param>
        /// <param name="death_List">The list of dead people</param>
        /// <param name="role">The role of the main player</param>
        /// <param name="names">The names of every players</param>
        /// <param name="roles">The roles of every players</param>
        public static void End(string player, List<string> death_List, string role, string[] names, string[] roles)
        {
            if (death_List.Contains(player))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You are dead. Game over.");
                Console.ResetColor();

                if (role == "Hunter")
                {
                    string choice;
                    int? index = null;

                    Thread.Sleep(5000);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Wait... You were the hunter? You still have a chance to take your revenge... Who should die? ");
                    Console.ResetColor();
                    Console.WriteLine();
                    foreach (string name in names)
                    {
                        Console.WriteLine(name);
                    }
                    Console.WriteLine();

                    choice = Console.ReadLine();

                    while (!names.Contains(choice))
                    {
                        Console.Write("This player doesn't exist. Please try again : ");
                        choice = Console.ReadLine();
                    }

                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i] == choice) index = i;
                    }

                    Console.Beep();
                    Console.WriteLine($"Boom... {choice} was {roles[(int)index]}");
                    Console.WriteLine();
                }
                Environment.Exit(0x1);
            }
        }

        /// <summary>
        /// Function used to apply a color to every roles.
        /// </summary>
        /// <param name="player_Role">The role to color</param>
        /// <returns>The color of the role</returns>
        public static ConsoleColor ChooseColor(string player_Role)
        {
            ConsoleColor color = ConsoleColor.White;
            switch (player_Role)
            {
                case var value when value == "Werewolf":
                    color = ConsoleColor.Red;
                    break;
                case var value when value == "Cupid":
                    color = ConsoleColor.Magenta;
                    break;
                case var value when value == "Hunter":
                    color = ConsoleColor.DarkGreen;
                    break;
                case var value when value == "Seer":
                    color = ConsoleColor.DarkMagenta;
                    break;
                case var value when value == "Peasant":
                    color = ConsoleColor.Yellow;
                    break;
                case var value when value == "Witch":
                    color = ConsoleColor.DarkRed;
                    break;
                case var value when value == "Crow":
                    color = ConsoleColor.Cyan;
                    break;
            }
            return color;
        }

        /// <summary>
        /// Used to start the game and ask the player for their name.
        /// </summary>
        /// <returns>The name of the player</returns>
        public static string Intro()
        {
            string name;

            Console.WriteLine("\t\t-------------------------------------");
            Console.WriteLine("\t\t\t    Werewolves");
            Console.WriteLine("\t\t-------------------------------------");
            Console.Write("\n\n\n\t\t      Press ENTER to start");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Start by entering your username : ");
            name = Console.ReadLine();

            while(name.Length > 15)
            {
                Console.Clear();
                Console.Write("Username shall not contains more than 15 characters. Try again : ");
                name = Console.ReadLine();
            }
            while(name.Length <= 0 || name.Contains(" "))
            {
                Console.Clear();
                Console.Write("Username shall be at least 1 character long and no space. Try again : ");
                name = Console.ReadLine();
            }

            Console.Clear();
           return name;
        }

        /// <summary>
        /// Used to display the screen's top.
        /// </summary>
        /// <param name="player_Role">The role of the main player</param>
        /// <param name="player_Name">The name of the main player</param>
        /// <param name="arr">The names of every players</param>
        public static void Displayer(string player_Role, string player_Name, params string[] arr)
        {
            IEnumerable<string> display_Query;
            ConsoleColor color;

            Func<IEnumerable<string>> query_Selector = () => display_Query =
            from x in arr
            where x != player_Name
            select x;

            color = ChooseColor(player_Role);

            Console.WriteLine("Players :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(player_Name + "  ");
            Console.ResetColor();
            Console.WriteLine(String.Join("  ", query_Selector()));
            Console.WriteLine();
            Console.WriteLine("Your role :");
            Console.ForegroundColor = color;
            Console.WriteLine(player_Role);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Displayer for the seer's choice.
        /// </summary>
        /// <param name="index">Index of the card</param>
        /// <param name="players_Names">Names of every players</param>
        /// <param name="roles">Roles of every players</param>
        /// <returns>The role of the chosen player</returns>
        public static string SeerDisplayer(int index, string[] players_Names, string[] roles)
        {
            Console.Write("The card of ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(players_Names[index]);
            Console.ResetColor();
            Console.Write(" is : ");
            Console.ForegroundColor = ChooseColor(roles[index]);
            Console.WriteLine(roles[index]);
            Console.ResetColor();
            Console.Write("\n\nPress ENTER to continue");
            Console.ReadKey();
            Console.Clear();

            return roles[index];
        }

        /// <summary>
        /// Used to start the first night.
        /// </summary>
        /// <param name="players_Names">Names of every players</param>
        /// <param name="roles">Roles of every players</param>
        /// <param name="death_List">List of every dead players</param>
        /// <param name="player_Role">Role of main player</param>
        /// <param name="player_Name">Name of main player</param>
        /// <param name="witch_Potions">Potions available for the witch</param>
        /// <param name="lovers">The 2 lovers</param>
        public static void Night_1(string[] players_Names, string[] roles, ref List<string> death_List, 
            string player_Role, string player_Name, ref int[] witch_Potions, ref List<string> lovers)
        {
            string other_Werewolf = null;
            List<string> AIWWs = new List<string>();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Night #1 is falling... The village falls asleep.");
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.Clear();
            Displayer(player_Role, player_Name, players_Names);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Cupid ");
            Console.ResetColor();
            Console.WriteLine("wakes up. They can now choose two people that will love each other till death and beyond...");

            if (player_Role == "Cupid")
            {
                if (players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Remove(player_Name);
                    players_Names = x.ToArray();
                }
                if (roles.Contains(player_Role))
                {
                    List<string> x = roles.ToList();
                    x.Remove(player_Role);
                    roles = x.ToArray();
                }

                Player_Reactions Cupid_Reaction = new Player_Reactions(players_Names, player_Role, other_Werewolf, death_List, witch_Potions);
                lovers = Cupid_Reaction.Cupid_Choice;
            }
            else
            {
                if (!players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Add(player_Name);
                    players_Names = x.ToArray();
                }
                if (!roles.Contains(player_Role))
                {
                    List<string> x = roles.ToList();
                    x.Add(player_Role);
                    roles = x.ToArray();
                }

                Reactions_AI Cupid_Reaction_AI = new Reactions_AI(players_Names, "Cupid", death_List, witch_Potions);
                lovers = Cupid_Reaction_AI.Cupid_Choice_AI;
                Thread.Sleep(5000);
            }
            if (lovers.Contains(player_Name))
            {
                Console.WriteLine();
                Console.Write("You were chosen by Cupid! Your lover is ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                foreach (string name in lovers)
                {
                    if (name != player_Name) Console.Write(name);
                }
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue");
                Console.ReadKey();
            }

            Console.Clear();
            Displayer(player_Role, player_Name, players_Names);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("The Seer ");
            Console.ResetColor();
            Console.WriteLine("wakes up. They will be allowed to take a look at one card...");

            if (player_Role == "Seer")
            {
                if (players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Remove(player_Name);
                    players_Names = x.ToArray();
                }
                if (roles.Contains(player_Role))
                {
                    List<string> x = roles.ToList();
                    x.Remove(player_Role);
                    roles = x.ToArray();
                }

                Player_Reactions Seer_Reaction = new Player_Reactions(players_Names, player_Role, other_Werewolf, death_List, witch_Potions);

                switch (Seer_Reaction.Seer_Choice)
                {
                    case var value when value == players_Names[0]: { SeerDisplayer(0, players_Names, roles); break; }
                    case var value when value == players_Names[1]: { SeerDisplayer(1, players_Names, roles); break; }
                    case var value when value == players_Names[2]: { SeerDisplayer(2, players_Names, roles); break; }
                    case var value when value == players_Names[3]: { SeerDisplayer(3, players_Names, roles); break; }
                    case var value when value == players_Names[4]: { SeerDisplayer(4, players_Names, roles); break; }
                    case var value when value == players_Names[5]: { SeerDisplayer(5, players_Names, roles); break; }
                    case var value when value == players_Names[6]: { SeerDisplayer(6, players_Names, roles); break; }
                }
             Displayer(player_Role, player_Name, players_Names);
            }
            else
            {
                string result = null;

                if (!players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Add(player_Name);
                    players_Names = x.ToArray();
                }
                if (!roles.Contains(player_Role))
                {
                    List<string> x = roles.ToList();
                    x.Add(player_Role);
                    roles = x.ToArray();
                }

                Reactions_AI Seer_Reaction_AI = new Reactions_AI(players_Names, "Seer", death_List, witch_Potions);

                switch (Seer_Reaction_AI.Seer_Choice_AI)
                {
                    case var value when value == players_Names[0]: { result = SeerDisplayer(0, players_Names, roles); break; }
                    case var value when value == players_Names[1]: { result = SeerDisplayer(1, players_Names, roles); break; }
                    case var value when value == players_Names[2]: { result = SeerDisplayer(2, players_Names, roles); break; }
                    case var value when value == players_Names[3]: { result = SeerDisplayer(3, players_Names, roles); break; }
                    case var value when value == players_Names[4]: { result = SeerDisplayer(4, players_Names, roles); break; }
                    case var value when value == players_Names[5]: { result = SeerDisplayer(5, players_Names, roles); break; }
                    case var value when value == players_Names[6]: { result = SeerDisplayer(6, players_Names, roles); break; }
                    case var value when value == players_Names[7]: { result = SeerDisplayer(7, players_Names, roles); break; }
                }
                Thread.Sleep(5000);
            }

            Console.Clear();
            Displayer(player_Role, player_Name, players_Names);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("The Werewolves ");
            Console.ResetColor();
            Console.WriteLine("wakes up. They will choose who to kill for tonight...");
            
            if(player_Role == "Werewolf")
            {
                if (players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Remove(player_Name);
                    players_Names = x.ToArray();
                }
                if (roles.Contains(player_Role))
                {
                    List<string> x = roles.ToList();
                    x.Remove(player_Role);
                    roles = x.ToArray();
                }

                for(int i = 0; i < players_Names.Length; i++)
                {
                    if (roles[i] == "Werewolf")
                    {
                        other_Werewolf = players_Names[i];
                        List<string> x = roles.ToList();
                        x.Remove(roles[i]);
                        roles = x.ToArray();
                        x = players_Names.ToList();
                        x.Remove(players_Names[i]);
                        players_Names = x.ToArray();
                    }
                }
                Player_Reactions Wereworlf_Reaction = new Player_Reactions(players_Names, player_Role, other_Werewolf, death_List, witch_Potions);
                if (lovers.Contains(Wereworlf_Reaction.Werewolves_Choice))
                {
                    foreach (string name in lovers)
                    {
                        death_List.Add(name);
                    }
                }
                death_List.Add(Wereworlf_Reaction.Werewolves_Choice);
                List<string> y = roles.ToList();
                y.Add("Werewolf");
                roles = y.ToArray();
                y = players_Names.ToList();
                y.Add(other_Werewolf);
                players_Names = y.ToArray();
            }
            else
            {
                if (!players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Add(player_Name);
                    players_Names = x.ToArray();
                }
                if (!roles.Contains(player_Role))
                {
                    List<string> x = roles.ToList();
                    x.Add(player_Role);
                    roles = x.ToArray();
                }
                for (int i = 0; i < roles.Length; i++)
                {
                    if (roles[i] == "Werewolf")
                    {
                        AIWWs.Add(players_Names[i]);
                        List<string> x = roles.ToList();
                        x.Remove(roles[i]);
                        roles = x.ToArray();
                        x = players_Names.ToList();
                        x.Remove(players_Names[i]);
                        players_Names = x.ToArray();
                    }
                }
                Reactions_AI Werewolf_Reaction_AI = new Reactions_AI(players_Names, "Werewolf", death_List, witch_Potions);
                if (lovers.Contains(Werewolf_Reaction_AI.Werewolf_Choice_AI))
                {
                    foreach(string name in lovers)
                    {
                        death_List.Add(name);
                    }
                }
                death_List.Add(Werewolf_Reaction_AI.Werewolf_Choice_AI);
                Thread.Sleep(5000);
            }

            Console.Clear();
            Displayer(player_Role, player_Name, players_Names);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("The Witch ");
            Console.ResetColor();
            Console.WriteLine("wakes up. They will decide if they kill someone, reanimate someone or do nothing.");

            if(player_Role == "Witch")
            {
                if (players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Remove(player_Name);
                    players_Names = x.ToArray();
                }

                Player_Reactions Witch_Reaction = new Player_Reactions(players_Names, player_Role, other_Werewolf, death_List, witch_Potions);
                switch (Witch_Reaction.Witch_Choice[0][0])
                {
                    case 1:
                        death_List.Remove((string)Witch_Reaction.Witch_Choice[1][0]);
                        witch_Potions[0]--;
                        break;

                    case 2:
                        death_List.Add((string)Witch_Reaction.Witch_Choice[1][0]);
                        witch_Potions[1]--;
                        break;
                }
            }
            else
            {
                if (!players_Names.Contains(player_Name))
                {
                    List<string> x = players_Names.ToList();
                    x.Add(player_Name);
                    players_Names = x.ToArray();
                }

                Reactions_AI Witch_Reaction_AI = new Reactions_AI(players_Names, "Witch", death_List, witch_Potions);
                switch (Witch_Reaction_AI.Witch_Choice_AI[0][0])
                {
                    case 1:
                        death_List.Remove((string)Witch_Reaction_AI.Witch_Choice_AI[1][0]);
                        witch_Potions[0]--;
                        break;

                    case 2:
                        death_List.Add((string)Witch_Reaction_AI.Witch_Choice_AI[1][0]);
                        witch_Potions[1]--;
                        break;
                }
                Thread.Sleep(5000);
            }
        }
    }
}
