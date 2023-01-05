using FinalMediaGuide.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.DAL.Repositories.Interfaces
{
    public interface ITranslateRepository
    {
        List<Translator> List(Expression<Func<Translator, bool>> predicate);
        void AddRange(List<Translator> translators);
        void RemoveRange(List<Translator> translators);

    }
}
