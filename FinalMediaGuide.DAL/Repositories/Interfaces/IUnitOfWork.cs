using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMediaGuide.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
