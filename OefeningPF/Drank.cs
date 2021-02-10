using System;
using System.Collections.Generic;
using System.Text;

namespace OefeningPF
{
    public abstract class Drank : IBedrag
    {
        public enum DrankNaam
        {
            Water, Limonade, Cocacola, Koffie, Thee
        }
        public abstract DrankNaam Naam { get; set; }
       
        public abstract decimal Prijs { get; }

        public Drank(DrankNaam naam) => Naam = naam;
       
        public abstract decimal BerekenBedrag();
        
    }
}
