using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Starter_Classes
{
    public class Definition_Class
    {
        public string Player_Name { get; set; }
        public string Player_Role { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Names { get; set; }

        /// <summary>
        /// Main Func
        /// </summary>
        /// <param name="Names"></param>
        /// <param name="Roles"></param>
        public Definition_Class(List<string> Names, List<string> Roles)
        {
            AI_Name Name = new AI_Name(Names);
            Players_Class Role = new Players_Class(Roles);

            Player_Name = Name.ReturnName();
            Player_Role = Role.ReturnRole();
            this.Names = Name.pulled_Names;
            this.Roles = Role.pulled_Roles;
        }
    }
}
