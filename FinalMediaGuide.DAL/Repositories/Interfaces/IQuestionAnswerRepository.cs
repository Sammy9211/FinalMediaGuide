using FinalMediaGuide.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.DAL.Repositories.Interfaces
{
    public interface IQuestionAnswerRepository
    {
        void Add(QuestionAnswer model);
        QuestionAnswer GetForEdit(int id);
        void Update(QuestionAnswer model);
        QuestionAnswer GetQuestionAnswerById(int id);
        List<QuestionAnswer> GetQuestionAnswers();
    }
}
