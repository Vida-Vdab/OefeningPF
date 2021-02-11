using System;
using System.Collections.Generic;
using System.Text;

namespace OefeningPF
{
    public abstract class Drank : IBedrag
    {
        public abstract List<string> DrankNamen { get; set; }
        public abstract string Naam { get; set; }
       
        public abstract decimal Prijs { get; }

        public Drank(string naam) => Naam = naam;
       
        public abstract decimal BerekenBedrag();
        
    }
}
