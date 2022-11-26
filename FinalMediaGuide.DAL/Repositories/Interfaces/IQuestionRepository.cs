using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalMediaGuide.DAL.Entities;

namespace FinalMediaGuide.DAL.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        void Add(Question model);
        Question GetForEdit(int id);
        void Update(Question model);
        Question GetQuestionById(int id);
        List<Question> GetAllQuestions();
    }
}
}
