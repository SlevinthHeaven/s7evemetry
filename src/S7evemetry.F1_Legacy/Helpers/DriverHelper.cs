namespace S7evemetry.F1_Legacy.Helpers
{
    public static class DriverHelper
    {
        public static string GetDriverById(int id)
        {
            switch (id)
            {
                case 0: return "Carlos Sainz";
                case 1: return "Daniil Kvyat";
                case 2: return "Daniel Ricciardo";
                case 3: return "Fernando Alonso";
                case 6: return "Kimi Räikkönen";
                case 7: return "Lewis Hamilton";
                case 8: return "Marcus Ericsson";
                case 9: return "Max Verstappen";
                case 10: return "Nico Hulkenburg";
                case 11: return "Kevin Magnussen";
                case 12: return "Romain Grosjean";
                case 13: return "Sebastian Vettel";
                case 14: return "Sergio Perez";
                case 15: return "Valtteri Bottas";
                case 17: return "Esteban Ocon";
                case 18: return "Stoffel Vandoorne";
                case 19: return "Lance Stroll";
                case 20: return "Arron Barnes";
                case 21: return "Martin Giles";
                case 22: return "Alex Murray";
                case 23: return "Lucas Roth";
                case 24: return "Igor Correia";
                case 25: return "Sophie Levasseur";
                case 26: return "Jonas Schiffer";
                case 27: return "Alain Forest";
                case 28: return "Jay Letourneau";
                case 29: return "Esto Saari";
                case 30: return "Yasar Atiyeh";
                case 31: return "Callisto Calabresi";
                case 32: return "Naota Izum";
                case 33: return "Howard Clarke";
                case 34: return "Wilheim Kaufmann";
                case 35: return "Marie Laursen";
                case 36: return "Flavio Nieves";
                case 37: return "Peter Belousov";
                case 38: return "Klimek Michalski";
                case 39: return "Santiago Moreno";
                case 40: return "Benjamin Coppens";
                case 41: return "Noah Visser";
                case 42: return "Gert Waldmuller";
                case 43: return "Julian Quesada";
                case 44: return "Daniel Jones";
                case 58: return "Charles Leclerc";
                case 59: return "Pierre Gasly";
                case 60: return "Brendon Hartley";
                case 61: return "Sergey Sirotkin";
                case 69: return "Ruben Meijer";
                case 70: return "Rashid Nair";
                case 71: return "Jack Tremblay";
                default:
                    break;
            }
            return "";
        }
    }
}
