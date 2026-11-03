using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;

namespace KontoBankowe
{
    internal class KontoBankowe
    {
        private static int licznik = 0;
        private decimal stan = 0;
        private string _numer = string.Empty;

        public string Numer { get { return _numer; } }

        public KontoBankowe()
        {
            licznik++;
            _numer = NumerKonta();
        }

        public void Wplac(decimal kwota)
        {
            stan += kwota;
        }

        public string NumerKonta()
        {
            string _numer = RandomNumberGenerator.GetString("0123456789", 25);
            return _numer;
        }

        public decimal StanKonta()
        {
            return stan;
        }
    }
}
