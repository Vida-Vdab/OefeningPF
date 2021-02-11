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
        public decimal Prijs { get; set; }
        public Dessert(NaamDesseert naam, decimal prijs)
        {
            Naam = naam;
            Prijs = prijs;
        }
        public decimal BerekenBedrag() => Prijs;
        public override string ToString() => $"Dessert: {Naam} ({Prijs} euro)";
        
    }
}
