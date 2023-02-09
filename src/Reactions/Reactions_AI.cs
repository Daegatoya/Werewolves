using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Reactions
{
    internal class Reactions_AI
    {
        public List<string> Cupid_Choice_AI { get; set; }
        public string Seer_Choice_AI { get; set; }
        public string Werewolf_Choice_AI { get; set; }
        public object[][] Witch_Choice_AI { get; set; }

        /// <summary>
        /// Main Func
        /// </summary>
        /// <param name="players"></param>
        /// <param name="role"></param>
        /// <param name="death_List"></param>
        /// <param name="potions"></param>
        public Reactions_AI(string[] players, string role, List<string> death_List, int[] potions)
        {
            switch (role)
            {
                case var value when value == "Werewolf": { Werewolf_Choice_AI = Werewolf_React(players); break; }
                case var value when value == "Seer": { Seer_React(players); break; }
                case var value when value == "Witch": { Witch_Choice_AI = Witch_React(players, death_List, potions); break; }
                case var value when value == "Peasant": { Peasant_React(); break; }
                case var value when value == "Crow": { Crow_React(); break; }
                case var value when value == "Cupid": { Cupid_Choice_AI = Cupid_React(players); break; }
            }
        }

        /// <summary>
        /// Werewolves Reaction
        /// </summary>
        /// <param name="players"></param>
        /// <returns>Choice of Werewolves</returns>
        public string Werewolf_React(string[] players)
        {
            Random random = new Random();
            string choice;

            choice = players[random.Next(0, players.Length)];

            return choice;
        }

        /// <summary>
        /// Seer Reaction
        /// </summary>
        /// <param name="players"></param>
        /// <returns>Choice of Seer</returns>
        public string Seer_React(string[] players)
        {
            Random random = new Random();
            string choice;

            choice = players[random.Next(0, players.Length)];

            return choice;
        }

        /// <summary>
        /// Witch Reaction
        /// </summary>
        /// <param name="players"></param>
        /// <param name="death_List"></param>
        /// <param name="potions"></param>
        /// <returns>Results of Witch</returns>
        public object[][] Witch_React(string[] players, List<string> death_List, int[] potions)
        {
            Random random = new Random();
            string revive;
            string kill;
            object[][] results =
            {
                new object[] { null },
                new string[] { null }
            };

            switch(random.Next(1, 11))
            {
                case 1:
                    if (potions[1] != 0)
                    {

                        results[0][0] = 2;
                        do
                        {
                            kill = players[random.Next(0, players.Length)];
                        } while (death_List.Contains(kill));
                        results[1][0] = kill;
                    }
                    else results[0][0] = 3;
                    break;

                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    if (potions[0] != 0)
                    {

                        results[0][0] = 1;
                        revive = death_List[random.Next(0, death_List.Count)];
                        results[1][0] = revive;
                    }
                    else results[0][0] = 3;
                    break;

                default:
                    results[0][0] = 3;
                    break;
            }

        return results;
        }

        /// <summary>
        /// Cupid Reaction
        /// </summary>
        /// <param name="players"></param>
        /// <returns>Lovers</returns>
        public List<string> Cupid_React(string[] players)
        {
            Random random = new Random();
            string choice, choice2;
            List<string> lovers = new List<string>();

            choice = players[random.Next(0, players.Length)];
            lovers.Add(choice);

            do
            {
                choice2 = players[random.Next(0, players.Length)];
            } while (lovers.Contains(choice2));
            lovers.Add(choice2);

            return lovers;
        }
    }
}
