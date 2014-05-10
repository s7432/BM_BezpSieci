using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class PS2zadanie1
    {
        static void Main(string[] args)
        {
            // PS 1 zadanie 3 - szyfr Cezara
            string[] tablica1 = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            string zaszyfruj = "Politechnika";
            int przesuniecie = 7;
            string zaszyfrowany = "";
            zaszyfruj = zaszyfruj.ToUpper();

            Console.WriteLine("Słowo do zaszyfrowania: " + zaszyfruj);

            foreach (char c in zaszyfruj)
            {
                for (int i = 0; i < tablica1.Count(); i++)
                {
                    if (tablica1[i] == c.ToString())
                    {
                        zaszyfrowany = zaszyfrowany + tablica1[(i + przesuniecie) % tablica1.Length]; break;
                    }
                }
            }

            Console.WriteLine("Słowo zaszyfrowane: " + zaszyfrowany);

            string rozszyfrowany = "";

            foreach (char c in zaszyfrowany)
            {
                for (int i = 0; i < tablica1.Count(); i++)
                {
                    if (tablica1[i] == c.ToString())
                    {
                        rozszyfrowany = rozszyfrowany + tablica1[((i - przesuniecie) + tablica1.Length) % tablica1.Length]; break;
                    }
                }
            }

            Console.WriteLine("Słowo rozszyfrowane: " + rozszyfrowany);
            Console.ReadKey();
        }
    }
}
