using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ProjektService : IProjektService
    {
        private readonly IProjektRepository _projektRepository;
        public ProjektService(IProjektRepository projektRepository)
        {
            _projektRepository = projektRepository;
        }

        public IEnumerable<Projekt> GetAll() => _projektRepository.GetAll();
        public Projekt GetById(int projektnummer) => _projektRepository.GetById(projektnummer);
        public void Add(Projekt projekt) => _projektRepository.Add(projekt);
        public void Update(Projekt projekt) => _projektRepository.Update(projekt);
    }
}
