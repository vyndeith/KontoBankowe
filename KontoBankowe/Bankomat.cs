namespace KontoBankowe
{
    internal class Bankomat
    {
        private decimal[] nominaly = Automat.nominaly;
        private int[] ilosci;

        public Bankomat()
        {
            ilosci = new int[nominaly.Length];
        }

        public void ZaladujMonety(decimal nominal, int sztuki)
        {
            int indeks = Array.IndexOf(nominaly, nominal);
            if (indeks == -1)
            {
                Console.WriteLine("Zły nominał: " + nominal);
                return;
            }

            ilosci[indeks] += sztuki;
        }

        public void Wyplac(KontoBankowe konto, decimal kwota)
        {
            if (kwota <= 0 || kwota > konto.StanKonta())
            {
                Console.WriteLine("Odmowa: brak środków na koncie");
                return;
            }

            int[] doWydania = new int[nominaly.Length];
            decimal reszta = kwota;

            for (int i = 0; i < nominaly.Length; i++)
            {
                while (reszta >= nominaly[i] && doWydania[i] < ilosci[i])
                {
                    doWydania[i]++;
                    reszta -= nominaly[i];
                }
            }

            if (reszta != 0)
            {
                Console.WriteLine("Odmowa: bankomat nie może wydać dokładnie tej kwoty");
                return;
            }

            konto.Wyplac(kwota);

            for (int i = 0; i < nominaly.Length; i++)
            {
                if (doWydania[i] > 0)
                {
                    ilosci[i] -= doWydania[i];
                    Console.WriteLine("Wydano " + doWydania[i] + " x " + nominaly[i] + " zł");
                }
            }
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
