using FinalMediaGuide.DAL.Entities;
using FinalMediaGuide.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.DAL.Repositories
{
    public class TranslateRepository : ITranslateRepository
    {
        private readonly FinalMediaGuideDataContext _context;
        public TranslateRepository(FinalMediaGuideDataContext context)
        {
            _context = context;
        }

        public void AddRange(List<Translator> translators)
        {
            _context.Translators.AddRange(translators);
        }

        public List<Translator> List(Expression<Func<Translator, bool>> predicate)
        {
            var data = _context.Translators.Where(predicate).ToList();
            return data;
        }

        public void RemoveRange(List<Translator> translators)
        {
            _context.Translators.RemoveRange(translators);
        }
    }
}
