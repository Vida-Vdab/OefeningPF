using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OefeningPF
{
    public class Pizza : Gerecht
    {
        private string onderdeldString;
        public List<string> Onderdelen { get; set; }
        public Pizza(string naam, decimal prijs, List<string> onderdelen)
            : base(naam, prijs)
        {
            Onderdelen = onderdelen;
        }

        public string OnderdelValue()
        {
            onderdeldString = "";
            foreach (var onderdeel in Onderdelen)
            {
                onderdeldString += onderdeel + "-";
            }
            onderdeldString = onderdeldString.Remove(onderdeldString.Length - 1);
            return onderdeldString;
        }
        public override decimal BerekenBedrag() => Prijs;

        public override string ToString()
        {
            return $"Gerecht:{Naam} ({Prijs} euro) {OnderdelValue()}";
        }

        public override string ToonGerecht()
        {
            onderdeldString = "";
            onderdeldString += "pizza#";
            onderdeldString += $"{Naam}#";
            onderdeldString += $"{Prijs}#";
            foreach (var onderdeel in Onderdelen)
            {
                onderdeldString += onderdeel + "#";
            }
            onderdeldString = onderdeldString.Remove(onderdeldString.Length - 1);
            return onderdeldString;
        }
    }
}
