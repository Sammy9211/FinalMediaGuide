using FinalMediaGuide.BLL.Services.Interfaces;
using FinalMediaGuide.DAL;
using FinalMediaGuide.DAL.Entities;
using FinalMediaGuide.DAL.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.BLL.Services
{
    public class TranslatorService : ITranslatorService
    {
        private readonly FinalMediaGuideDataContext _context;
        private readonly ITranslateRepository _translaterepository;
        public TranslatorService(FinalMediaGuideDataContext context,ITranslateRepository translateRepository)
        {
            _context = context;
            _translaterepository = translateRepository;
        }

        public object Convert(object model, string tableName, int primaryKey, CultureType cultureType, List<int> primarykeys = null)
        {
            if (model is IEnumerable)
            {
                var translates = _translaterepository.List(p => p.TableName == tableName && primarykeys.Contains(p.PrimaryKey) && p.CultureType == cultureType);

                foreach (var item in model as IEnumerable)
                {
                    var fields = item.GetType().GetProperties().ToList();
                    var pk = (int)fields.FirstOrDefault(p => p.Name == "Id").GetValue(item);
                    fields.Where(p => p.PropertyType == typeof(string) && !p.Name.Contains("File")).ToList().
                        ForEach(p => p.SetValue(item, translates.FirstOrDefault(t => t.PrimaryKey == pk && t.FieldName == p.Name) != null ? translates.FirstOrDefault(t => t.PrimaryKey == pk && t.FieldName == p.Name).Value : p.GetValue(item)));
                }
                return model;
            }
            var values = _translaterepository.List(t => t.TableName == tableName && t.PrimaryKey == primaryKey && t.CultureType == cultureType);
            var type = model.GetType();
            var props = type.GetProperties().Where(p => !p.Name.Contains("Id") && !p.Name.Contains("Image"));
            foreach (var item in values)
            {
                var prop = type.GetProperty(item.FieldName);
                prop.SetValue(model, item.Value, null);
            }
            return model;
        }



        public void Fill(object model, CultureType cultureType, string tableName, int primaryKey)
        {
            var currentValues = _translaterepository.List(p => p.TableName == tableName && p.PrimaryKey == primaryKey && p.CultureType == cultureType);

            List<Translator> translates = new();
            var type = model.GetType();
            var props = type.GetProperties().Where(p => p.PropertyType == typeof(string) && !p.Name.Contains("File") && !p.Name.Contains("Image") && p.GetValue(model, null) != null);
            foreach (var item in props)
            {
                translates.Add(new Translator
                {
                    TableName = tableName,
                    CultureType = cultureType,
                    FieldName = item.Name,
                    PrimaryKey = primaryKey,
                    Value = item.GetValue(model, null)?.ToString()
                });
            }
            _translaterepository.AddRange(translates);
            _translaterepository.RemoveRange(currentValues.ToList());

        }

    }
}
