using System;
using System.Collections.Generic;
using System.Text;

namespace OefeningPF
{
    public class Dessert : IBedrag
    {
        public enum NaamDesseert
        {
            Tiramisu, Ijs, Cake
        }
        public NaamDesseert Naam { get; set; }
        public decimal Prijs
        {
            get
            {
                return Naam switch
                {
                    NaamDesseert.Tiramisu => 3,
                    NaamDesseert.Ijs => 3,
                    NaamDesseert.Cake => 2,
                    _ => 0,
                };
            }
        }
        public Dessert(NaamDesseert naam) => Naam = naam;
        public decimal BerekenBedrag() => Prijs;
        public override string ToString() => $"Dessert: {Naam} ({Prijs} euro)";
        
    }
}
