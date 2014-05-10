using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // ZADANIE 3
            // 3. Zaprojektuj kryptosystem bazujący na tablicy Vigenere.
            
            string[,] vigenereTable = new string [,] {  { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" },
                                                        { "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A" },
                                                        { "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B" },
                                                        { "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C" },
                                                        { "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D" },
                                                        { "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E" },
                                                        { "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F" },
                                                        { "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G" },
                                                        { "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H" },
                                                        { "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I" },
                                                        { "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" },
                                                        { "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" },
                                                        { "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" },
                                                        { "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" },
                                                        { "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N" },
                                                        { "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" },
                                                        { "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P" },
                                                        { "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q" },
                                                        { "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R" },
                                                        { "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S" },
                                                        { "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" },
                                                        { "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U" },
                                                        { "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" },
                                                        { "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W" },
                                                        { "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X" },
                                                        { "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y" }};
            
            string key = "BREAK";
            string tekst = "POLITECHNIKA";
            char[] keyTable = new char[tekst.Length];
            Console.WriteLine("Zad3 Słowo do zaszyfrowania: " + tekst);

            // tworzenie tabeli z kluczem
            int helpInt=0;
            for (int a=0;a<tekst.Length;a++)
            {
                if(helpInt==key.Length){helpInt=0;}
                keyTable[a] = key.ToCharArray()[helpInt];
                helpInt++;
            }
            
            // szyfrowanie
            char[] zaszyfrowany = new char[tekst.Length];
            #region szyfrowanie
            // dla każdej litery w tekście do zaszyfrowania
            for (int b = 0; b < tekst.Length; b++)
            {
                char charTekst = tekst.ToCharArray()[b];
                char charKey = keyTable[b];

                int indexCharTekst = -1;
                int indexCharKey = -1;

                // znajduje indeksy x i y
                for(int c=0; c<vigenereTable.GetLength(0);c++)
                {
                    if (vigenereTable[0,c]==tekst.ToCharArray()[b].ToString())
                    {
                        indexCharTekst=c;
                    }
                    if (vigenereTable[0,c]==keyTable[b].ToString())
                    {
                        indexCharKey=c;
                    }

                }
                // wstawia zaszyfrowaną wartość
                zaszyfrowany[b] = vigenereTable[indexCharKey,indexCharTekst][0];
            }
            string tekstZaszyfrowany = new string(zaszyfrowany);
            Console.WriteLine("Zad3 Słowo zaszyfrowane: " + tekstZaszyfrowany);
            #endregion

            //odszyfrowywanie
            char[] odszyfrowany = new char[zaszyfrowany.Length];

            for (int b = 0; b < tekst.Length; b++)
            {
                char charZaszyfrowany = zaszyfrowany[b];
                char charKey = keyTable[b];

                int indexKolumna = -1;
                int indexWiersz = -1;

                // dla każdej litery w alfabecie
                for (int c = 0; c < vigenereTable.GetLength(0); c++)
                {
                    // szukamy indeksu tablicy szyfrującej (wiersza)
                    if (vigenereTable[0, c] == charKey.ToString()) 
                    { 
                        indexWiersz = c;
                        // szukamy kolumny
                        for (int d = 0; d < vigenereTable.GetLength(0); d++)
                        {
                            if (vigenereTable[indexWiersz, d] == charZaszyfrowany.ToString())
                            {
                                indexKolumna = d;
                                // wstawia odszyfrowaną wartość 
                                odszyfrowany[b] = vigenereTable[0, indexKolumna][0];
                            }
                        }
                    
                    }


                }
                         
            }

            string tekstOdszyfrowany = new string(odszyfrowany);
            Console.WriteLine("Zad3 Słowo zaszyfrowane: " + tekst);










            Console.ReadKey();
        }
    }
}
