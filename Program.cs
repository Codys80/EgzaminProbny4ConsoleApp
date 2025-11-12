using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EgzaminProbny4ConsoleApp
{
    class Uczen
    {
        static int instancja = 0;
        internal int id = 0;
        internal int suma { get; set; }
        internal string imie { get; set; }
        internal List<int> oceny { get; set; }
        public void sortujOceny()
        {
            int j = oceny.Count - 1;
            while (j >= 1)
            {
                for (int i = 0; i < j; i++)
                {
                    if (oceny[i] > oceny[i + 1])
                    {
                        int temp = oceny[i];
                        oceny[i] = oceny[i + 1];
                        oceny[i + 1] = temp;
                    }
                }
                j--;
            }
        }

        public void przypiszSume()
        {
            for (int i = 0; i < oceny.Count; i++)
            {
                this.suma += this.oceny[i];
            }
        }
        public Uczen()
        {
            instancja++;
            id = instancja;
            oceny = new List<int>();
            imie = "";
            przypiszSume();
        }
    }
    class AplikacjaKonsolowa
    {
        public int nwd(Uczen u1, Uczen u2)
        {
            while (u2.suma != 0)
            {
                int temp = u2.suma;
                u2.suma = u1.suma % u2.suma;
                u1.suma = temp;
            }
            return u1.suma;
        }
        public void ktoZwycieza(Uczen uczen1, Uczen uczen2)
        {
            if (uczen1.suma > uczen2.suma)
            {
                Console.WriteLine(uczen1.imie + " WYGRYWA! (przewaga wyrażona NWD: " + nwd(uczen1, uczen2) + ')');
            }
            else if (uczen1.suma < uczen2.suma)
            {
                Console.WriteLine(uczen2.imie + " WYGRYWA! (przewaga wyrażona NWD: " + nwd(uczen1, uczen2) + ')');
            }
            else
            {
                Console.WriteLine("Remis!");
            }
        }
        public void wypiszUcznia(Uczen uczen)
        {
            Console.Write("Uczeń nr " + uczen.id + ": " + uczen.imie + ", oceny: [");
            for(int i=0; i< uczen.oceny.Count; i++)
            {
                if(i == uczen.oceny.Count - 1)
                {
                    Console.Write(uczen.oceny[i]);
                    break;
                }
                Console.Write(uczen.oceny[i] + ", ");
            }
            Console.Write("], suma ocen = " + uczen.suma + ')' + '\n');
        }
        public void wpiszUcznia(Uczen uczen)
        {
            Console.WriteLine("Podaj imię ucznia nr "+ uczen.id+" : ");
            uczen.imie = Console.ReadLine().Trim();
            List<int> oceny = new List<int>();
            Console.WriteLine("Wpisuj oceny ucznia(1 - 6). Wpisz 0, aby zakończyć dodawanie.");
            int input = Convert.ToInt32(Console.ReadLine().Trim());
            while (input != 0)
            {
                uczen.oceny.Add(input);
                if (input < 0 || input > 6)
                {
                    Console.WriteLine("Nieprawidłowa ocena.");
                }
                input = Convert.ToInt32(Console.ReadLine().Trim());
            }
            uczen.przypiszSume();
            uczen.sortujOceny();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AplikacjaKonsolowa w1 = new AplikacjaKonsolowa();
            Uczen uczen1 = new Uczen();
            Uczen uczen2 = new Uczen();
            while (true)
            {
                Console.WriteLine("=== RYWALIZACJA UCZIOW ===");
                w1.wpiszUcznia(uczen1);
                w1.wpiszUcznia(uczen2);
                Console.WriteLine("===Wyniki===");
                w1.wypiszUcznia(uczen1);
                w1.wypiszUcznia(uczen2);
                w1.ktoZwycieza(uczen1, uczen2);
                Console.WriteLine("Co chcesz zrobić dalej?\n 1 - Spróbuj ponownie z nowymi uczniami\n 2 - zakończ program");
                if (Console.ReadLine() == "2") break;
                Console.WriteLine("Wybór 1");
                Console.Clear();
                uczen1 = new Uczen();
                uczen2 = new Uczen();
            }
            Console.WriteLine("Wybór 2\n Do widzenia");
        }
    }
}
