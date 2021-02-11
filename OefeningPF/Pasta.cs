using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OefeningPF
{
    public class Pasta: Gerecht
    {
        private string onderdeldString;
        public string Omschrijving { get; set; }
        public Pasta(string naam, decimal prijs, string omschrijving="")
           : base(naam, prijs)
        {
            Omschrijving = omschrijving;
        }
        public override string ToString()
        {
            return $"Gerecht:{Naam} ({Prijs} euro) {Omschrijving}";
        }
        public override decimal BerekenBedrag() => Prijs;
        public override string ToonGerecht()
        {
            onderdeldString = "";
            onderdeldString += "pasta#" + $"{Naam}#" + $"{Prijs}#";
            onderdeldString += Omschrijving != "" ? string.Join("#", $"met {Omschrijving}"): "";
            return onderdeldString;

        }


    }
}
