using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalMediaGuide.DAL.Entities;
using FinalMediaGuide.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalMediaGuide.DAL.Repositories
{
    public class NewsRepositories : INewsRepository
    {
        private readonly FinalMediaGuideDataContext _context;
        public NewsRepositories(FinalMediaGuideDataContext context)
        {
            _context = context;
        }
        public void Add(News model)
        {
            _context.News.Add(model);
        }
        public List<News> GetAllNews()
        {
            var data = _context.News.Select(s => new News
            {
                Id = s.Id,
                Description = s.Description,
                Title = s.Title,
                ImageFile = s.ImageFile,
                NewsType = s.NewsType,
            }).AsNoTracking().ToList();
            return data;
        }

        public News GetNewsById(int id)
        {
            var entity = _context.News.Where(s => s.Id == id)
            .AsNoTracking()
            .FirstOrDefault();
            return entity;
        }

        public void Update(News model)
        {
            var entity = _context.News.FirstOrDefault(s => s.Id == model.Id);
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.ImageFile = model.ImageFile;
            entity.NewsType = model.NewsType;
        }
        public News GetForEdit(int id)
        {
            var data = _context.News.Where(s => s.Id == id)          
            .FirstOrDefault();
            return data;
        }
    }
}
