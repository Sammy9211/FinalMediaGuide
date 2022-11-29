using FinalMediaGuide.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.BLL.Services.Interfaces
{
    public interface IQuestionService
    {
        public List<QuestionVM> GetAllQuestion();
        public QuestionVM GetQuestionById(int id);
        public QuestionAddEditVM GetQuestionForEdit(int id);
        public void Add(QuestionAddEditVM model);
        public void Update(QuestionAddEditVM model);
    }
}
