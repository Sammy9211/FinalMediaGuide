using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalMediaGuide.DAL.Entities;

namespace FinalMediaGuide.DAL.Repositories.Interfaces
{
    public interface INewsRepository
    {
        void Add(News model);
        News GetForEdit(int id);
        void Update(News model);
        News GetNewsById(int id);
        List<News> GetAllNews();
    }
}
