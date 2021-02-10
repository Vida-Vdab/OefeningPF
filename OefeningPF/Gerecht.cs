using System;
using System.Collections.Generic;
using System.Text;

namespace OefeningPF
{
    public abstract class Gerecht: IBedrag
    {
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public Gerecht(string naam, decimal prijs)
        {
            Naam = naam;
            Prijs = prijs;
        }
        public abstract decimal BerekenBedrag();
        public abstract string ToonGerecht();

    }
}
