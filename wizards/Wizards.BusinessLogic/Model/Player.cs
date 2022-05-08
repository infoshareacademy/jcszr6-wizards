using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.BusinessLogic
{
    internal class Player
    {
        public string UserName { get;  set; }
        public string Password { get;  set; }
        public string Email { get;  set; }
        public DateTime DateOfBirth { get; set; }

        public List<Hero> heros = new List<Hero>();

        public Player(string userName, string password, string email, DateTime dateOfBirth)
        {
            this.UserName=userName;
            this.Password =password;
            this.Email =email;
            this.DateOfBirth =dateOfBirth;
        }

        public Player()
        {
            
        }
    }
}
