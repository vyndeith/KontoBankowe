using System.Globalization;

namespace KontoBankowe
{
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
            konto.PokazHistorie();
            automat.PokazMonety();

            KontoBankowe drugieKonto = new KontoBankowe();
            Console.WriteLine("Numer drugiego konta: " + drugieKonto.Numer);
        }
    }
}