using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace FinalMediaGuide.DAL.Entities
{
    public class User:IdentityUser<int>
    {
        public int Year { get; set; }
    }
}
