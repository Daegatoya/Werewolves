using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Starter_Classes
{
    internal class AI_Name
    {
        public string New_Name { get; set; }
        public List<string> pulled_Names { get; set; }

        /// <summary>
        /// Main Func
        /// </summary>
        /// <param name="names_List"></param>
        public AI_Name(List<string> names_List)
        {
            New_Name = Name(names_List);
        }

        /// <summary>
        /// Give AI Name
        /// </summary>
        /// <param name="names_List"></param>
        /// <returns>AI#X Name</returns>
        public string Name(List<string> names_List)
        {
            string name;
            string[] possibilities = { "Jane", "Eric", "Patrick", "John", "Alice", "Kim", "Martin", "Nicolas", "Mark", "Charlotte",
            "Dereck", "Gina", "Arianna", "Justin", "Greg", "Robert", "Karim", "Mary", "Jocelyn", "Charlie", "Sasha", "Scarlett" };
            Random random = new Random();
            pulled_Names = names_List;

            do
            {
                name = possibilities[random.Next(0, possibilities.Length)];
            } while (pulled_Names.Contains(name));

            pulled_Names.Add(name);
            return name;
        }

        /// <summary>
        /// Return AI Name
        /// </summary>
        /// <returns>Return AI#X Name</returns>
        public string ReturnName()
        {
            return New_Name;
        }
    }
}
