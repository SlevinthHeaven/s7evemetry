namespace S7evemetry.F1_2017.Helpers
{
    public static class DriverHelper
    {
        public static string GetDriverById(int id)
        {
            switch (id)
            {
                case 0: return "Sebastian Vettel";
                case 1: return "Daniil Kvyat";
                case 2: return "Fernando Alonso";
                case 3: return "Felipe Massa";
                case 5: return "Sergio Perez";
                case 6: return "Kimi Räikkönen";
                case 7: return "Romain Grosjean";
                case 9: return "Lewis Hamilton";
                case 10: return "Nico Hulkenberg";
                case 14: return "Kevin Magnussen";
                case 15: return "Valtteri Bottas";
                case 16: return "Daniel Ricciardo";
                case 18: return "Marcus Ericsson";
                case 20: return "Jolyon Palmer";
                case 22: return "Max Verstappen";
                case 23: return "Carlos Sainz Jr.";
                case 31: return "Pascal Wehrlein";
                case 33: return "Esteban Ocon";
                case 34: return "Stoffel Vandoorne";
                case 35: return "Lance Stroll";
                default: return "Unknown";
            }
        }

        public static string GetClassicDriverById(int id)
        {
            switch (id)
            {
                case 0: return "Klimek Michalski";
                case 1: return "Martin Giles";
                case 2: return "Igor Correia";
                case 3: return "Sophie Levasseur";
                case 4: return "Alain Forest";
                case 5: return "Santiago Moreno";
                case 6: return "Esto Saari";
                case 7: return "Peter Belousov";
                case 8: return "Lars Kaufmann";
                case 9: return "Yasar Atiyeh";
                case 10: return "Howard Clarke";
                case 14: return "Marie Laursen";
                case 15: return "Benjamin Coppens";
                case 16: return "Alex Murray";
                case 18: return "Callisto Calabresi";
                case 20: return "Jay Letourneau";
                case 22: return "Naota Izum";
                case 23: return "Arron Barnes";
                case 24: return "Jonas Schiffer";
                case 31: return "Flavio Nieves";
                case 32: return "Noah Visser";
                case 33: return "Gert Waldmuller";
                case 34: return "Julian Quesada";
                case 68: return "Lucas Roth";
                default: return "Unknown";
            }
        }
    }
}
