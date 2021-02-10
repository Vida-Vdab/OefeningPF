using System;
using System.Collections.Generic;
using System.Text;

namespace OefeningPF
{
    public class Warmedrank : Drank
    {
        public decimal prijsValue = 2.5m;

        private DrankNaam naamvalue;
        public override decimal Prijs
        {
            get => prijsValue;
        }
        public override DrankNaam Naam
        {
            get => naamvalue;
            set
            {
                if (value != DrankNaam.Thee && value != DrankNaam.Koffie)
                    throw new Exception("een verkeerde dranknaam wordt opgegeven.");
                naamvalue = value;
            }
        }
        public Warmedrank(DrankNaam naam) : base(naam) { }
        public override decimal BerekenBedrag() => Prijs;
        public override string ToString() => $"Drank: {Naam} ({Prijs} euro)";

    }
}
