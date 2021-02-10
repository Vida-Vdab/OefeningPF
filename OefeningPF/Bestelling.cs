using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OefeningPF
{
    public class Bestelling : IBedrag
    {
        public static int bestellingNummer = 0;
        public int BestellingNummer { get; set; }
        public Klant Klanten { get; set; }
        public BesteldGerecht BesteldGerechten { get; set; }
        public Drank Dranken { get; set; }
        public Dessert Desserts { get; set; }
        public int Aantal { get; set; }

        public decimal totaalBedrag;

        private string bestellingenValue;
        public Bestelling(Klant klanten = null, BesteldGerecht besteldGerechten = null, Drank dranken = null, Dessert desserts = null, int aantal = 1)
        {
            Klanten = klanten;
            BesteldGerechten = besteldGerechten;
            Dranken = dranken;
            Desserts = desserts;
            Aantal = aantal;
            BestellingNummer = ++bestellingNummer;

        }
        public decimal BerekenBedrag()
        {
            totaalBedrag = 0m;

            if (BesteldGerechten != null && Dranken != null && Desserts != null)
            {
                totaalBedrag = Aantal * (BesteldGerechten.BerekenBedrag() + Dranken.BerekenBedrag() + Desserts.BerekenBedrag());
                totaalBedrag = totaalBedrag * 90/100;
            }
            else
            {
                decimal gerechtenPrijs = BesteldGerechten != null ? BesteldGerechten.BerekenBedrag() : 0m;
                decimal drankPrijs = Dranken != null ? Dranken.BerekenBedrag() : 0m;
                decimal dessertsPrijs = Desserts != null ? Desserts.BerekenBedrag() : 0m;
                totaalBedrag = Aantal * (drankPrijs + gerechtenPrijs + dessertsPrijs);
            }
            return totaalBedrag;

        }
        public override string ToString()
        {
            bestellingenValue = "";
            bestellingenValue += $"Bestelling {BestellingNummer}: \n";
            if (Klanten != null)
                bestellingenValue += $"{Klanten} \n";
            else
                bestellingenValue += $"Klant: Onbekende Klant \n";

            if (BesteldGerechten != null)
                bestellingenValue += $"{BesteldGerechten} \n";
            if (Dranken != null)
                bestellingenValue += $"{Dranken} \n";
            if (Desserts != null)
                bestellingenValue += $"{Desserts} \n";

            bestellingenValue += $"Aantal: {Aantal} \n";
            bestellingenValue += $"Bedrag van deze bestelling: {BerekenBedrag()} euro\n";

            return bestellingenValue;
        }
        public string ToonBestelling()
        {
            bestellingenValue += Klanten != null ? $"{Klanten.KlantID}#":"0#";
            bestellingenValue += BesteldGerechten != null ? $"{BesteldGerechten.Gerecht.Naam}-{BesteldGerechten.Grootte}-{BesteldGerechten.AantalExtras()}-{BesteldGerechten.ExtraString("-").Replace("extra: ","")}#" : "#";
            if (Dranken != null)
                bestellingenValue += Dranken is Frisdrank ? $"F-{Dranken.Naam}#" : $"W-{Dranken.Naam}#";
            else
                bestellingenValue += "#";
            bestellingenValue += Desserts != null ? $"{Desserts.Naam}#" : "#";
            bestellingenValue += Aantal;

            return bestellingenValue;
        }
    }
}
