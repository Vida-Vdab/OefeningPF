using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OefeningPF
{
    public class BesteldGerecht : IBedrag
    {
        decimal totaalBedrag = 0m;

        private string extraValue;
        public decimal Bedrag { get; set; }
        public Gerecht Gerecht { get; set; }
        public Grootte Grootte { get; set; }
        public List<Extra> Extra { get; set; }
        public BesteldGerecht(Gerecht gerecht, List<Extra> extra = null, Grootte grootte = Grootte.Klein)
        {
            Gerecht = gerecht;
            Grootte = grootte;
            Extra = extra;
            Bedrag = BerekenTotaalBedrag();
        }
        public decimal BerekenBedrag() => Bedrag;
        public int AantalExtras=> Extra != null ? Extra.Count() : 0;
        public decimal BerekenTotaalBedrag()
        {
            totaalBedrag += Gerecht.BerekenBedrag();
            if (Grootte == Grootte.Groot)
                totaalBedrag += 3m;
            totaalBedrag += AantalExtras;
            return totaalBedrag;
        }
        public string ExtraString(string teken)
        {
            extraValue = "";
            if (Extra != null)
            {
                extraValue = "extra: ";
                foreach (var extras in Extra)
                {
                    extraValue += extras + teken;
                }
                
            }
            return extraValue;
        }
        public override string ToString()
        {
            return $"{Gerecht} ({Grootte}) {ExtraString(" ")} (bedrag: {Bedrag} euro)";
        }

    }
}
