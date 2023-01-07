﻿using FinalMediaGuide.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.BLL.ViewModels
{
    public class QuizTypeVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CultureType Culture { get; set; }
    }
}
