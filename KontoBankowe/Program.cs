
using System.Globalization;

namespace KontoBankowe
{
    internal class KontoBankowe
    {
        private static int licznik = 0;
        private decimal stan = 0;

        public int Numer { get; }

        public KontoBankowe()
        {
            licznik++;
            Numer = licznik;
        }

        public void Wplac(decimal kwota)
        {
            stan += kwota;
        }

        public decimal StanKonta()
        {
            return stan;
        }
    }

    internal class Automat
    {
        private KontoBankowe konto;
        private Dictionary<decimal, int> monety = new Dictionary<decimal, int>
        {
            { 0.01m, 0 }, { 0.02m, 0 }, { 0.05m, 0 },
            { 0.1m, 0 }, { 0.2m, 0 }, { 0.5m, 0 },
            { 1m, 0 }, { 2m, 0 }, { 5m, 0 }
        };

        public Automat(KontoBankowe konto)
        {
            this.konto = konto;
        }

        public void WrzucMonete(string tekst)
        {
            if (!decimal.TryParse(tekst, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal wartosc))
            {
                Console.WriteLine("Nieudany odczyt: " + tekst);
                return;
            }

            if (!monety.ContainsKey(wartosc))
            {
                Console.WriteLine("Zła moneta: " + wartosc);
                return;
            }

            monety[wartosc]++;
            konto.Wplac(wartosc);
            Console.WriteLine("Moneta przyjęta: " + wartosc);
        }

        public void PokazMonety()
        {
            decimal suma = 0;
            foreach (var moneta in monety)
            {
                Console.WriteLine(moneta.Key + ": " + moneta.Value);
                suma += moneta.Key * moneta.Value;
            }
            Console.WriteLine("Razem: " + suma);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            KontoBankowe konto = new KontoBankowe();
            Automat automat = new Automat(konto);

            automat.WrzucMonete("0.5");
            automat.WrzucMonete("1");
            automat.WrzucMonete("2");
            automat.WrzucMonete("3");
            automat.WrzucMonete("abc");

            Console.WriteLine("Stan konta: " + konto.StanKonta());
            Console.WriteLine("Numer konta: " + konto.Numer);
            automat.PokazMonety();

            KontoBankowe drugieKonto = new KontoBankowe();
            Console.WriteLine("Numer drugiego konta: " + drugieKonto.Numer);
        }
    }
}