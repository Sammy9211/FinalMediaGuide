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
        private readonly ITranslatorService _translatorService;
        private readonly IUnitOfWork _uow;
        public NewsService(INewsRepository newsRepository,IUnitOfWork uow,ITranslatorService translatorService) { 
            _newsRepository = newsRepository;
            _uow = uow;
            _translatorService = translatorService;
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

        public List<NewsVM> GetAllNews(CultureType cultureType)
        {
            var news = _newsRepository.GetAllNews();
            if (cultureType != CultureType.en)
            {
                news = _translatorService.Convert(news, "News", 0, cultureType, news.Select(n => n.Id).ToList()) as List<News>;

            }
            var list = news.Select(n => new NewsVM 
            {
                Description= n.Description,
                ImageFile= n.ImageFile,
                NewsType= n.NewsType,
                Id = n.Id,
                Title = n.Title,
            }).ToList();
            return list;
        }

        public NewsVM GetNewsById(int id,CultureType cultureType)
        {
            var news = _newsRepository.GetNewsById(id);
            if (cultureType != CultureType.en)
            {
                news = _translatorService.Convert(news, "News", id, cultureType, new List<int> { id}) as News;
            }
            NewsVM newsVM = new NewsVM { 
                Id= id,
                Description= news.Description,
                ImageFile= news.ImageFile,
                NewsType= news.NewsType,
                Title= news.Title,
            };
            return newsVM;
        }

        public void Update(NewsVM newsVM, CultureType cultureType)
        {
            var entity = _newsRepository.GetForEdit(newsVM.Id);
            if (cultureType == CultureType.en)
            {
                entity.Title = newsVM.Title;
                entity.Description = newsVM.Description;
                entity.NewsType = newsVM.NewsType;
                entity.ImageFile = newsVM.ImageFile;
                _newsRepository.Update(entity);
            }
            else 
            {
                var tableName = "News";
                _translatorService.Fill(newsVM,cultureType,tableName,newsVM.Id);
            }
            _uow.Save();
            //var news = new News
            //{
            //    Id = newsVM.Id,
            //    Description = newsVM.Description,
            //    NewsType= newsVM.NewsType,
            //    ImageFile= newsVM.ImageFile,
            //    Title= newsVM.Title,
            //};
            //_newsRepository.Update(news);
            //_uow.Save();
        }
    }
}
