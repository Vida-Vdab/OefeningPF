using System;
using System.Collections.Generic;
using System.Text;

namespace OefeningPF
{
    public class Frisdrank : Drank
    {
        public decimal prijsValue = 2m;

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
                if (value == DrankNaam.Thee || value == DrankNaam.Koffie)
                    throw new Exception("een verkeerde dranknaam wordt opgegeven.");

                naamvalue = value;
            }
        }
        public Frisdrank(DrankNaam naam) : base(naam) { }
        public override decimal BerekenBedrag() => Prijs;
        public override string ToString() => $"Drank: {Naam} ({Prijs} euro)";
        
    }
}
