using System.Security.Cryptography;

namespace KontoBankowe
{
    internal class KontoBankowe
    {
        private static int licznik = 0;
        private decimal stan = 0;
        private string _numer = string.Empty;
        private List<decimal> historia = new List<decimal>();

        public string Numer { get { return _numer; } }

        public KontoBankowe()
        {
            licznik++;
            _numer = NumerKonta();
        }

        public void Wplac(decimal kwota)
        {
            stan += kwota;
            historia.Add(kwota);
        }

        public bool Wyplac(decimal kwota)
        {
            if (kwota <= 0 || kwota > stan)
            {
                Console.WriteLine("Wypłata nieudana");
                return false;
            }

            stan -= kwota;
            return true;
        }

        public string NumerKonta()
        {
            return RandomNumberGenerator.GetString("0123456789", 25);
        }

        public decimal StanKonta()
        {
            return stan;
        }

        public void PokazHistorie()
        {
            Console.WriteLine("Liczba wpłat: " + historia.Count);
            foreach (decimal kwota in historia)
            {
                Console.WriteLine(kwota);
            }
        }
    }
}