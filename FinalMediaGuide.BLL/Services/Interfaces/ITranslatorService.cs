using FinalMediaGuide.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.BLL.Services.Interfaces
{
    public interface ITranslatorService
    {
        object Convert(object model, string tableName,int primaryKey, CultureType cultureType,List<int> primaryKeys);
        void Fill(object model, CultureType cultureType,string tableName, int primaryKey);
    }
}
