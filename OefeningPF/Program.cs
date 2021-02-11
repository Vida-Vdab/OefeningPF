using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace OefeningPF
{
    class Program
    {
        public static void Main(string[] args)
        {
            Pizza Margherita = new Pizza("Pizza Margherita", 8m, new List<string> { "Tomatensaus", "Mozzarella" });
            Pizza Napoli = new Pizza("Pizza Napoli", 10m, new List<string> { "Tomatensaus", "Mozzarella", "Ansjovis", "Kappers", "Olijven" });
            Pizza Lardiera = new Pizza("Pizza Lardiera", 9.5m, new List<string> { "Tomatensaus", "Mozzarella", "Spek" });
            Pizza Vegetariana = new Pizza("Pizza Vegetariana", 9.5m, new List<string> { "Tomatensaus", "Mozarella", "Groenten" });

            Pasta SphagettiBolognese = new Pasta("Sphagetti Bolognese", 12m, "gehaktsaus ");
            Pasta SphagettiCarbonara = new Pasta("Spahgetti Carbonara", 13m, "Spek, roomsaus en parmezaanse kaas");
            Pasta Arrabbiata = new Pasta("Penne Arrabbiata", 14m, "pittige romatensaus");
            Pasta Lasagne = new Pasta("Lasagne", 15m);

            Warmedrank Thee = new Warmedrank("Thee");
            Warmedrank Koffie = new Warmedrank("Koffie");

            Frisdrank Water = new Frisdrank("Water");
            Frisdrank Limonade = new Frisdrank("Limonade");
            Frisdrank Cocacola = new Frisdrank("Cocacola");

            Dessert Tiramisu = new Dessert(Dessert.NaamDesseert.Tiramisu, 3m);
            Dessert Ijs = new Dessert(Dessert.NaamDesseert.Ijs, 3m);
            Dessert Cake = new Dessert(Dessert.NaamDesseert.Cake, 2m);

            Klant Jan = new Klant(1, "Jan Janssen");
            Klant Piet = new Klant(2, "Piet Peeters");

            BesteldGerecht[] besteldGerechts = new BesteldGerecht[6];

            besteldGerechts[0] = new BesteldGerecht(Margherita, new List<Extra> { Extra.Kaas, Extra.Look }, Grootte.Groot);
            besteldGerechts[1] = new BesteldGerecht(Margherita, null);
            besteldGerechts[2] = new BesteldGerecht(Napoli, null, Grootte.Groot);
            besteldGerechts[3] = new BesteldGerecht(Lasagne, new List<Extra> { Extra.Look });
            besteldGerechts[4] = new BesteldGerecht(SphagettiCarbonara, null);
            besteldGerechts[5] = new BesteldGerecht(SphagettiBolognese, new List<Extra> { Extra.Kaas }, Grootte.Groot);

            List<Klant> klanten = new List<Klant> { Jan, Piet };
            List<Drank> dranken = new List<Drank> { Thee, Koffie, Limonade, Water, Cocacola };
            List<Gerecht> Gerechten = new List<Gerecht> { Margherita, Napoli, Lardiera, Vegetariana, SphagettiBolognese, SphagettiCarbonara, Arrabbiata, Lasagne };
            List<Bestelling> bestellingen = new List<Bestelling>
            {
                new Bestelling(Jan, besteldGerechts[0], Water, Ijs, 2),
                new Bestelling(Piet, besteldGerechts[1], Water,Tiramisu),
                new Bestelling(Piet, besteldGerechts[2], Thee, Ijs),
                new Bestelling(null, besteldGerechts[3], null, null),
                new Bestelling(Jan, besteldGerechts[4], Cocacola, null),
                new Bestelling(Piet, besteldGerechts[5], Cocacola, Cake),
                new Bestelling(Piet, null, Koffie, null, 3),
                new Bestelling(Jan, null, null, Tiramisu),
            };

            Console.WriteLine("Toon eerste lijst van bestellingen: \n");

            foreach (var bestelling in bestellingen)
            {
                Console.WriteLine(bestelling);
                for (var teller = 1; teller <= 70; teller++)
                    Console.Write('*');
                Console.WriteLine();
            }


            Console.WriteLine("Toon enkel de bestellingen van klant Jan Janssen : \n");
            decimal berekenBedrag = 0m;
            var bestellingenVanJan = from bestelling in bestellingen
                                     where bestelling.Klanten == Jan
                                     select bestelling;
            foreach (var bestelling in bestellingenVanJan)
            {
                Console.WriteLine(bestelling);
                Console.WriteLine();
                berekenBedrag = bestellingenVanJan.Sum(bestelling => bestelling.BerekenBedrag());
            }
            Console.WriteLine($"Het totaal bedrag van alle bestellingen van klant Jan Janssen: {berekenBedrag} euro");
            Console.WriteLine("***********************************************");
            Console.WriteLine();


            Console.WriteLine("Toon alle bestellingen, gegroepeerd per klant: \n");
            decimal totaalBedrag;
            var alleBestellingen = from bestelling in bestellingen
                                   group bestelling by bestelling.Klanten
                                   into klantgroep
                                   select new
                                   {
                                       klanten = klantgroep,
                                       klantNaam = klantgroep.Key
                                   };
            foreach (var bestelling in alleBestellingen)
            {
                if (bestelling.klantNaam != null)
                    Console.WriteLine($"Bestellingen van {bestelling.klantNaam} \n");
                else
                    Console.WriteLine($"Onbekende Klanten:\n");
                totaalBedrag = 0m;
                foreach (var klant in bestelling.klanten)
                {
                    Console.WriteLine(klant);
                    totaalBedrag += klant.BerekenBedrag();
                    Console.WriteLine();
                }
                if (bestelling.klantNaam != null)
                    Console.WriteLine($"Het totaal bedrag van alle bestellingen van {bestelling.klantNaam}: {totaalBedrag} euro");
                Console.WriteLine();
                Console.WriteLine("******************************************************************");
                Console.WriteLine();
            }

            /////DEEL 2:////

            string locatieVanKlant = @"C:\Data\";
            StringBuilder klantgegevens;
            try
            {
                using var schrijver = new StreamWriter(locatieVanKlant + "klanten.txt");
                foreach (var klant in klanten)
                {
                    klantgegevens = new StringBuilder();
                    klantgegevens = klantgegevens.Append($"{klant.KlantID}#{klant.Naam}");
                    schrijver.WriteLine(klantgegevens);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het schrijven naar het bestand!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            //Console.WriteLine("gerechten: gerechten.txt");
            string locatieVanGerechten = @"C:\Data\";
            StringBuilder gerechten;
            try
            {
                using var schrijver = new StreamWriter(locatieVanGerechten + "gerechten.txt");
                foreach (var gerecht in Gerechten)
                {
                    gerechten = new StringBuilder();
                    gerechten.Append(gerecht.ToonGerecht());
                    schrijver.WriteLine(gerechten);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het schrijven naar het bestand!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("bestellingen: bestellingen.txt");
            string locatieVanBestelling = @"C:\Data\";
            StringBuilder bestellingData;
            string bestellingLezen;
            try
            {
                using var schrijver = new StreamWriter(locatieVanBestelling + "bestellingen.txt");
                foreach (var bestelling in bestellingen)
                {
                    bestellingData = new StringBuilder();
                    bestellingData.Append(bestelling.ToonBestelling());
                    schrijver.WriteLine(bestellingData); ;
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het schrijven naar het bestand!");
            }

            try
            {
                using var lezer = new StreamReader(locatieVanBestelling + "bestellingen.txt");
                while ((bestellingLezen = lezer.ReadLine()) != null)
                {
                    Console.WriteLine(bestellingLezen);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het lezen van het bestand!");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }

}

























