using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Factories
{
    public class ProjektFactory
    {
        private readonly AppDbContext _context;

        public ProjektFactory(AppDbContext context)
        {
            _context = context;
        }

        public Projekt CreateProjekt(string namn, DateTime startdatum, DateTime? slutdatum,
            string projektansvarig, int kundnummer, int tjanstId, decimal totalpris, ProjektStatus status)
        {
            var kund = _context.Kunder.FirstOrDefault(k => k.Kundnummer == kundnummer);
            var tjanst = _context.Tjanster.FirstOrDefault(t => t.TjanstId == tjanstId);

            var projekt = new Projekt
            {
                Namn = namn,
                Startdatum = startdatum,
                Slutdatum = slutdatum,
                Projektansvarig = projektansvarig,
                Kund = kund,
                Tjanst = tjanst,
                Totalpris = totalpris,
                Status = status,
                Kundnummer = kundnummer,
                TjanstId = tjanstId
            };

            return projekt;
        }
    }
}
