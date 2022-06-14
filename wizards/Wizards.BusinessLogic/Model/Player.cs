using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wizards.BusinessLogic
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [MinLength(3)]
        [MaxLength(20)]
        public string UserName { get;  set; }
        
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get;  set; }
        
        [Required]
        [Display(Name = "Email addres")]
        [EmailAddress]
        public string Email { get;  set; }

        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        
        public List<Hero> Heroes = new List<Hero>();

        public Player()
        {
            
        }
    }
}
