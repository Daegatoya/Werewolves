using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Starter_Classes
{
    internal class Players_Class
    {
        public string Name { get; set; }
        private string Role { get; set; }
        public List<string> pulled_Roles { get; set; }

        /// <summary>
        /// Main Func
        /// </summary>
        /// <param name="pulled_Roles"></param>
        public Players_Class(List<string> pulled_Roles)
        {
            Role = GiveRole(pulled_Roles);
        }

        /// <summary>
        /// Give Main Role
        /// </summary>
        /// <param name="pulled_Roles"></param>
        /// <returns>Main Role</returns>
        public string GiveRole(List<string> pulled_Roles)
        {
            object[][] roles =
            {
                new string[] { "Werewolf", "Seer", "Witch", "Cupid", "Hunter", "Crow", "Peasant" },
                new object[] { 2, 1, 1, 1, 1, 1, 1}
            };
            this.pulled_Roles = pulled_Roles;
            Random random = new Random();
            int r;
            int nb;
            string role;

            do
            {
                r = random.Next(0, 7);
                role = roles[0][r].ToString();
            } while (this.pulled_Roles.Contains(role) && role != "Werewolf");

            switch (role)
            {
                case var value when value == "Werewolf":
                    if (this.pulled_Roles.Contains(value)) this.pulled_Roles.Add(role);
                    else this.pulled_Roles.Add(role);
                    break;
            }

            nb = int.Parse(roles[1][r].ToString());
            nb--;
            if (nb == 0) this.pulled_Roles.Add(role);

            return role;
        }

        /// <summary>
        /// Return Main Role Public
        /// </summary>
        /// <returns>Main Role Public</returns>
        public string ReturnRole()
        {
            return Role;
        }
    }
}
