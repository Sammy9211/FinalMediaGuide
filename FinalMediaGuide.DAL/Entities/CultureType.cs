using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.DAL.Entities
{
    public enum CultureType
    {
        [Display(Name = "ՀԱՅ")]
        am = 1,
        [Display(Name = "RU")]
        ru,
        [Display(Name = "EN")]
        en = 3
    }
}
