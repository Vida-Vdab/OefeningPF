using System;
using System.Collections.Generic;
using System.Text;

namespace OefeningPF
{
    public class Klant
    {
        public int KlantID { get; set; }
        public string Naam { get; set; }
        public Klant(int klantid, string naam)
        {
            KlantID = klantid;
            Naam = naam;
        }
        public override string ToString() => $"Klant: {Naam}"; 
    }
}
