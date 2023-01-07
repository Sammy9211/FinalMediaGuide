using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalMediaGuide.BLL.ViewModels;
using FinalMediaGuide.DAL.Entities;

namespace FinalMediaGuide.BLL.Services.Interfaces
{
    public interface INewsService
    {
        public List<NewsVM> GetAllNews(CultureType cultureType);
        public NewsVM GetNewsById(int id,CultureType cultureType);
        public void Add(NewsVM newsVM);
        public void Update(NewsVM newsVM,CultureType cultureType);
    }
}
