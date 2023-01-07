using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.BLL.ViewModels
{
    public class CreateUserVM
    {
        public string Email { get; set; } 
        public string Password { get; set; }
        public int Year { get;set; }
    }
}
