using Microsoft.AspNetCore.Identity;

namespace Wizards.Core.Model
{
    public class Player : IdentityUser<int>
    {
        //public int Id { get; set; }
        //public string UserName { get;  set; }
        public string Password { get; set; }
        //public string Email { get;  set; }
        public DateTime DateOfBirth { get; set; }

        public List<Hero> Heroes = new();

        public Player()
        {
            
        }


    }
}
