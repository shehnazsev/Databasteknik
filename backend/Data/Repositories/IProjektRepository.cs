using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IProjektRepository
    {
        IEnumerable<Projekt> GetAll();
        Projekt GetById(int projektnummer);
        void Add(Projekt projekt);
        void Update(Projekt projekt);
    }
}
