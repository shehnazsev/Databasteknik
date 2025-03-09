using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProjektRepository : IProjektRepository
    {
        private readonly AppDbContext _context;

        public ProjektRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Projekt> GetAll() => _context.Projekt.Include(p => p.Kund).Include(p => p.Tjanst).ToList();

        public Projekt GetById(int projektnummer) => _context.Projekt.Find(projektnummer);

        public void Add(Projekt projekt)
        {
            var kund = _context.Kunder.FirstOrDefault(k => k.Kundnummer == projekt.Kundnummer);

            projekt.Kund = kund;

            _context.Projekt.Add(projekt);
            _context.SaveChanges();
        }

        public void Update(Projekt projekt)
        {
            _context.Projekt.Update(projekt);
            _context.SaveChanges();
        }
    }
}
