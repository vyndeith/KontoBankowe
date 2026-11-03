namespace KontoBankowe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KontoBankowe konto = new KontoBankowe();
            Automat automat = new Automat(konto, 2);

            automat.WrzucMonety("5 2 abc 0.5 3 1");
            automat.WrzucMonety("5 5 5");

            Console.WriteLine("Stan konta: " + konto.StanKonta());
            Console.WriteLine("Numer konta: " + konto.Numer);
            konto.PokazHistorie();
            automat.PokazMonety();

            KontoBankowe drugieKonto = new KontoBankowe();
            Console.WriteLine("Numer drugiego konta: " + drugieKonto.Numer);
        }
    }
}