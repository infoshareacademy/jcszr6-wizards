using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wizards.BusinessLogic
{
    public class Player
    {
        public int Id { get; set; }
        public string UserName { get;  set; }
        public string Password { get;  set; }
        public string Email { get;  set; }
        public DateTime DateOfBirth { get; set; }
        public List<Hero> Heroes = new();

        public Player()
        {
            
        }
    }
}
