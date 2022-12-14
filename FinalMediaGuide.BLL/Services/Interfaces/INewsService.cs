using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalMediaGuide.BLL.ViewModels;


namespace FinalMediaGuide.BLL.Services.Interfaces
{
    public interface INewsService
    {
        public List<NewsVM> GetAllNews();
        public NewsVM GetNewsById(int id);
        public void Add(NewsVM newsVM);
        public void Update(NewsVM newsVM);
    }
}
