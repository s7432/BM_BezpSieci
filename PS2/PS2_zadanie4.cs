using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {

            string[,] playFairTable = { {"M", "A", "L", "Y", "S"},
                                        {"Z", "K", "O", "B", "C"},
                                        {"D", "E", "F", "G", "H"},
                                        {"I", "J", "N", "P", "Q"},
                                        {"R", "T", "U", "V", "W"} };

            string[,] testTable = { {"M", "A", "L", "Y", "S"},
                                        {"Z", "K", "O", "B", "C"},
                                        {"D", "E", "F", "G", "H"},
                                        {"I", "J", "N", "P", "Q"},
                                        {"R", "T", "U", "V", "W"} };


            string zaszyfruj = "PIZZAPEPERONI";
            string zaszyfrowany = "";
            string odszyfrowany = "";
            int currentIndex = -1;
            string symbolNieuzywany = "";
    
            Console.WriteLine("Zad4 Słowo do zaszyfrowania: " + zaszyfruj);

            #region przygotowanie wyrazu do szyfrowania
            // znajdujemy symbol nie uzywany w alfabecie
            foreach (char item in zaszyfruj)
            {
                for (int i = 0; i < testTable.GetLength(0); i++)
                {
                    for (int j = 0; j < testTable.GetLength(1); j++)
                    {
                        if (testTable[i, j] == item.ToString()) { testTable[i, j] = "_"; }
                    }
                }
            }

            for (int i = 0; i < testTable.GetLength(0); i++)
            {
                for (int j = 0; j < testTable.GetLength(1); j++)
                {
                    if (testTable[i, j] != "_") { symbolNieuzywany = testTable[i, j]; break; }
                }
            }

            // jeśli wyraz ma powtarzające się litery, wstawiamy w nie symbol nie uzywany w szyfrowanej frazie
            char currentLetter = zaszyfruj[0];
            for (int a = 1; a < zaszyfruj.Length; a++)
            {
                if(currentLetter==zaszyfruj[a])
                {
                    zaszyfruj=zaszyfruj.Insert(a,symbolNieuzywany);
                }
                currentLetter = zaszyfruj[a];
            }

            // jeśli wyraz ma nie parzysta ilosc znakow, dostawiamy na koncu znak nie uzywany
            if (zaszyfruj.Length % 2 == 1) { zaszyfruj += symbolNieuzywany.ToString(); }
            #endregion

            Console.WriteLine("Zad4 Słowo przygotowane do zaszyfrowania: " + zaszyfruj);

            #region szyfrowanie
            int index1_X = -1;
            int index1_Y = -1;
            int index2_X = -1;
            int index2_Y = -1;

            
            for (int b = 0; b < zaszyfruj.Length; b=b+2)
            {
                // dla każdej pary znaków w wyrazie znajdujemy współrzędne w tabeli
                char znak1 = zaszyfruj[b];
                char znak2 = zaszyfruj[b + 1];

                for (int i = 0; i < playFairTable.GetLength(0);i++ )
                {
                    for (int j = 0; j < playFairTable.GetLength(1); j++)
                    {
                        if (playFairTable[i, j] == znak1.ToString()) { index1_X = i; index1_Y = j; }
                        if (playFairTable[i, j] == znak2.ToString()) { index2_X = i; index2_Y = j; }
                    }
                }

                // jeżeli znaki sa w tym samym wierszu:
                if (index1_Y == index2_Y) 
                {
                    znak1 = playFairTable[(index1_X + 1) % playFairTable.GetLength(0), index1_Y][0];
                    znak2 = playFairTable[(index2_X + 1) % playFairTable.GetLength(0), index2_Y][0]; 
                }

                // jezeli znaki sa w tej samej kolumnie:
                else if (index1_X == index2_X)
                {
                    znak1 = playFairTable[index1_X, (index1_Y + 1) % playFairTable.GetLength(1)][0];
                    znak2 = playFairTable[index2_X, (index2_Y + 1) % playFairTable.GetLength(1)][0];
                }

                // jezeli znaki nie sa ani w tym samym wierszu ani w tej samej kolumnie
                else 
                { 
                    znak1 = playFairTable[index1_X, index2_Y][0];
                    znak2 = playFairTable[index2_X, index1_Y][0];
                }


                zaszyfrowany = zaszyfrowany + znak1 + znak2;
            }

            Console.WriteLine("Zad4 Słowo zaszyfrowane: " + zaszyfrowany);
            #endregion

            #region odszyfrowywanie

            for (int b = 0; b < zaszyfrowany.Length; b = b + 2)
            {
                // dla każdej pary znaków w wyrazie znajdujemy współrzędne w tabeli
                char znak1 = zaszyfrowany[b];
                char znak2 = zaszyfrowany[b + 1];

                for (int i = 0; i < playFairTable.GetLength(0); i++)
                {
                    for (int j = 0; j < playFairTable.GetLength(1); j++)
                    {
                        if (playFairTable[i, j] == znak1.ToString()) { index1_X = i; index1_Y = j; }
                        if (playFairTable[i, j] == znak2.ToString()) { index2_X = i; index2_Y = j; }
                    }
                }

                // jeżeli znaki sa w tym samym wierszu:
                if (index1_Y == index2_Y)
                {
                    znak1 = playFairTable[(index1_X + playFairTable.GetLength(0) - 1) % playFairTable.GetLength(0), index1_Y][0];
                    znak2 = playFairTable[(index2_X + playFairTable.GetLength(0) - 1) % playFairTable.GetLength(0), index2_Y][0];
                }

                // jezeli znaki sa w tej samej kolumnie:
                else if (index1_X == index2_X)
                {
                    znak1 = playFairTable[index1_X, (index1_Y + playFairTable.GetLength(1) - 1) % playFairTable.GetLength(1)][0];
                    znak2 = playFairTable[index2_X, (index2_Y + playFairTable.GetLength(1) - 1) % playFairTable.GetLength(1)][0];
                }

                // jezeli znaki nie sa ani w tym samym wierszu ani w tej samej kolumnie
                else
                {
                    znak1 = playFairTable[index1_X, index2_Y][0];
                    znak2 = playFairTable[index2_X, index1_Y][0];
                }


                odszyfrowany = odszyfrowany + znak1 + znak2;
            }
            // usuwanie dodanego ewentualnie pustego znaku i wyświetlanie wyniku
            odszyfrowany=odszyfrowany.Replace(symbolNieuzywany[0].ToString(),"");
            Console.WriteLine("Zad4 Słowo odszyfrowane: " + odszyfrowany);



            #endregion

            Console.ReadKey();
        }
    }
}
