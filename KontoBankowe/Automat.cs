using System.Globalization;

namespace KontoBankowe
{
    internal class Automat
    {
        private KontoBankowe konto;
        public static decimal[] nominaly = { 5m, 2m, 1m, 0.5m, 0.2m, 0.1m };
        private int[] ilosci;
        private int pojemnosc;

        public Automat(KontoBankowe konto, int pojemnosc)
        {
            this.konto = konto;
            this.pojemnosc = pojemnosc;
            ilosci = new int[nominaly.Length];
        }

        public void WrzucMonety(string tekst)
        {
            string[] czesci = tekst.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int przyjete = 0;
            int zwrocone = 0;

            foreach (string czesc in czesci)
            {
                if (WrzucMonete(czesc))
                {
                    przyjete++;
                }
                else
                {
                    zwrocone++;
                }
            }

            Console.WriteLine("Przyjęte: " + przyjete + ", zwrócone: " + zwrocone);
        }

        public bool WrzucMonete(string tekst)
        {
            if (!decimal.TryParse(tekst, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal wartosc))
            {
                Console.WriteLine("Nieudany odczyt: " + tekst);
                return false;
            }

            int indeks = Array.IndexOf(nominaly, wartosc);
            if (indeks == -1)
            {
                Console.WriteLine("Zła moneta: " + wartosc);
                return false;
            }

            if (ilosci[indeks] == pojemnosc)
            {
                Console.WriteLine("Brak miejsca, zwrot monety: " + wartosc);
                return false;
            }

            ilosci[indeks]++;
            konto.Wplac(wartosc);
            Console.WriteLine("Moneta przyjęta: " + wartosc);
            return true;
        }

        public void PokazMonety()
        {
            decimal suma = 0;
            for (int i = 0; i < nominaly.Length; i++)
            {
                Console.WriteLine(nominaly[i] + ": " + ilosci[i]);
                suma += nominaly[i] * ilosci[i];
            }
            Console.WriteLine("Razem: " + suma);
        }
    }
}