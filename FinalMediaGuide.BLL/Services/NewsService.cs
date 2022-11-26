using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.BLL.ViewModels;
using FinalMediaGuide.DAL;
using FinalMediaGuide.DAL.Entities;
using FinalMediaGuide.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.BLL.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IUnitOfWork _uow;
        public NewsService(INewsRepository newsRepository,IUnitOfWork uow) { 
            _newsRepository = newsRepository;
            _uow = uow;
        }
        public void Add(NewsVM newsVM)
        {
            News news = new News { 
                Description= newsVM.Description,
                ImageFile= newsVM.ImageFile,
                NewsType = newsVM.NewsType,
                Title = newsVM.Title,
            };
            _newsRepository.Add(news);
            _uow.Save();
        }

        public List<NewsVM> GetAllNews()
        {
            var news = _newsRepository.GetAllNews().Select(n => new NewsVM { 
                Id= n.Id,
                Description= n.Description,
                ImageFile= n.ImageFile,
                NewsType= n.NewsType,
                Title= n.Title,
            }).ToList();
            return news;
        }

        public NewsVM GetNewsById(int id)
        {
            var news = _newsRepository.GetNewsById(id);
            NewsVM newsVM = new NewsVM { 
                Id= id,
                Description= news.Description,
                ImageFile= news.ImageFile,
                NewsType= news.NewsType,
                Title= news.Title,
            };
            return newsVM;
        }

        public void Update(NewsVM newsVM)
        {
            var news = new News
            {
                Id = newsVM.Id,
                Description = newsVM.Description,
                NewsType= newsVM.NewsType,
                ImageFile= newsVM.ImageFile,
                Title= newsVM.Title,
            };
            _newsRepository.Update(news);
            _uow.Save();
        }
    }
}
