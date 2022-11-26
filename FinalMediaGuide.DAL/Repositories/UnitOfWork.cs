using FinalMediaGuide.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinalMediaGuideDataContext _context;
        public UnitOfWork(FinalMediaGuideDataContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
