using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Zaimplementuj algorytm kodujący i dekodujący z wykorzystaniem szyfru prostego przestawiania „rail fence" dla k = n. 

            string zaszyfruj = "duże drzewa rosną w ogrodzie";
            int k = 5; // ilość "płotków"
            string[,] table = new string[k, zaszyfruj.Length];
            int currentRow = 0;
            bool increasing = true;

            #region szyfrowanie
            Console.WriteLine("PS1_zad1 String do zaszyfrowania: " + zaszyfruj);

            for (int i = 0; i < zaszyfruj.Length; i++)
            {
                if (increasing == true)
                {
                    table[currentRow, i] = zaszyfruj[i].ToString();
                    if (currentRow == k - 1) { increasing = false; currentRow--; }
                    else { currentRow++; }
                }
                else
                {
                    table[currentRow, i] = zaszyfruj[i].ToString();
                    if (currentRow == 0) { increasing = true; currentRow++; }
                    else { currentRow--; }
                }
            }

            string zaszyfrowany = "";
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < zaszyfruj.Length; j++)
                {
                    if (table[i, j] != null) { zaszyfrowany = zaszyfrowany + table[i, j]; }
                }
            }
            Console.WriteLine("PS1_zad1 String zaszyfrowany: " + zaszyfrowany);
            #endregion

            #region odszyfrowywanie

            string[,] tableOdszyfruj = new string[k, zaszyfrowany.Length];

            currentRow = 0;
            increasing = true;

            // wpisywanie znaków ciągu w pola tabeli
            for (int i = 0; i < zaszyfrowany.Length; i++)
            {
                if (increasing == true)
                {
                    tableOdszyfruj[currentRow, i] = zaszyfrowany[i].ToString();
                    if (currentRow == k - 1) { increasing = false; currentRow--; }
                    else { currentRow++; }
                }
                else
                {
                    tableOdszyfruj[currentRow, i] = zaszyfrowany[i].ToString();
                    if (currentRow == 0) { increasing = true; currentRow++; }
                    else { currentRow--; }
                }
            }

            // ustawianie znaków ciągu w odpowiednim szyku
            increasing = true;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < zaszyfrowany.Length; j++)
                {
                    if (tableOdszyfruj[i, j] != null) { tableOdszyfruj[i, j] = zaszyfrowany[0].ToString(); zaszyfrowany.Remove(0, 1); }
                }
            }

            // wczytywanie poukładanej tabeli, wpisywanie tego w rozszyfrowany ciąg
            string rozszyfrowany = "";
            for (int i = 0; i < zaszyfruj.Length; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (tableOdszyfruj[j, i] != null) { rozszyfrowany = rozszyfrowany + table[j, i]; }
                }
            }
            Console.WriteLine("PS1_zad1 String odszyfrowany: " + rozszyfrowany);


            #endregion

            Console.ReadKey();
        }
        // funkcja nie aktywna
        //static void drukujTabele(string[,] tabela)
        //{
        //    int wierszy = tabela.GetLength(0);
        //    int kolumny = tabela.GetLength(1);
        //    Console.WriteLine("");
        //    Console.WriteLine("");
        //    for (int i = 0; i < wierszy; i++)
        //    {
        //        for (int j = 0; j < kolumny; j++)
        //        {
        //            if (tabela[i, j] == null) { Console.Write("_"); }
        //            else { Console.Write(tabela[i, j].ToString()); }
        //        }
        //        Console.WriteLine("");
        //    }
        //}
    }
}
