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

            Bankomat bankomat = new Bankomat();
            bankomat.ZaladujMonety(5m, 3);
            bankomat.ZaladujMonety(2m, 5);
            bankomat.ZaladujMonety(1m, 5);

            Console.WriteLine("Wypłata 9 zł:");
            bankomat.Wyplac(konto, 9m);

            Console.WriteLine("Wypłata 1000 zł:");
            bankomat.Wyplac(konto, 1000m);

            Console.WriteLine("Wypłata 0.3 zł:");
            bankomat.Wyplac(konto, 0.3m);

            Console.WriteLine("Stan konta: " + konto.StanKonta());
            bankomat.PokazMonety();
        }
    }
}