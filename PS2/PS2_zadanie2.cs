using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class PS2zadanie2
    {
        static void Main(string[] args)
        {
            // ZADANIE 2
            // 2. Zaprojektuj kryptosystem bazujący na równaniu (Affine Cipher):
            // c = (a*k1 + k0) mod n
            // gdzie k0 i k1 sa liczbami wzglednie pierwszymi
            
            string[] tablica = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            int k0 = 0; // JAKAKOLWIEK LICZBA CAŁKOWITA >=0
            int k1 = 23; // LICZBA PIERWSZA - 1,3,5,7,9,11,15,17,19,21,23, itp

            string zaszyfruj = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string zaszyfrowany = "";
            zaszyfruj = zaszyfruj.ToUpper();

            Console.WriteLine("Zad2 Słowo do zaszyfrowania: " + zaszyfruj);

            foreach (char c in zaszyfruj)
            {
                for (int i = 0; i < tablica.Count(); i++)
                {
                    if (tablica[i] == c.ToString()) 
                    { 
                        int index = ((i * k1 + k0) % 26);
                        zaszyfrowany = zaszyfrowany + tablica[index];
                        break; 
                    }
                }
            }

            Console.WriteLine("Zad2 Słowo zaszyfrowane: " + zaszyfrowany);

            string rozszyfrowany = "";

            foreach (char c in zaszyfrowany)
            {
                for (int i = 0; i < tablica.Count(); i++)
                {
                    //if (i == 14 && c.ToString()=="O") { Console.WriteLine(c.ToString()+" == "+tablica[i]); }

                    if (tablica[i] == c.ToString()) 
                    {
                        /* MODULAR MULTIPLICATIVE INVERSE ze wzoru na rozszyfrowanie
                         * Nasz alfabet ma 26 znaków, więc przy rozszyfrowywaniu mnożymy przez 21 bo:
                         * 21 x 5 = 105 = 1 mod 26, ponieważ 26 x 4 = 104, a 105 - 104 = 1 
                         */
                        int inverseInt = wyliczInverseInt(k1,tablica.Length);
                        int index = inverseInt * (i - k0) % tablica.Length;
                        while (index < 0)
                        {
                            index += tablica.Length;
                        }
                        rozszyfrowany = rozszyfrowany + tablica[index];  
                        break; 
                    }
                }
            }

            Console.WriteLine("Zad2 Słowo rozszyfrowane: " + rozszyfrowany);
            Console.ReadKey();

        }

        static int wyliczInverseInt(int k1, int wielkoscAlfabetu)
        {
            int inverseInt = 0;
            // inwersje wyliczamy metoda "brute force" ;]
            // Lista 40 kolejnych (1 mod wielkosc_alfabetu) zaczynajac od jedynki:

            int[] mods = new int[40];
            mods[0] = 1;
            for (int i = 1; i < 40; i++)
            {
                mods[i] = wielkoscAlfabetu * i + 1;
            }

            // wyszukiwanie wartosci inwersji:
            // 21 x 5 = 105 = 1 mod 26, ponieważ 26 x 4 = 104, a 105 - 104 = 1 
            bool found = false;
            for (int j = 1; j < 100000; j++)
            {
                for(int o=0;o<mods.Length;o++)
                { 
                    if (mods[o] == (j * k1))
                    {
                        inverseInt = j; found = true;
                        break;
                    }   
                }
                if (found == true) { break; }
            }

            return inverseInt;
        }
    }
}
