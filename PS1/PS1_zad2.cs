using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            //2. Zaimplementuj kryptosystem przedstawieniowy bazujący na przykładzie 2 dla d = 5 oraz klucza key =3-4-1-5-2

            string tekst = "lubie placki z maslem";
            int d = 5;
            int[] klucz = { 3, 4, 1, 5, 2 };

            Console.WriteLine("PS1_zad2 String do zaszyfrowania: " + tekst);
            // sprawdzamy czy dlugosc tekstu dzieli sie na d. Jesli nie - dodajemy ewentualne spacje
            while (tekst.Length % d != 0)
            {
                tekst = tekst + " ";
            }

            #region szyfrowanie
            string zaszyfrowany = "";
            int temp = tekst.Length;
            // dla kazdej porcji danych po kolei (w tym wypadku 5)
            for (int i = 0; i < temp; i = i + d)
            {
                char[] datapartPlain = tekst.Substring(0, d).ToCharArray();
                tekst = tekst.Remove(0, d);
                char[] datapartCipher = new char[d]; 


                // wstawiamy po kolei kazdy znak do tymczasowej tabeli - zgodnie z kluczem
                
                for (int j = 0; j < d; j++)
                {
                    int place = klucz[j]-1;
                    datapartCipher[j] = datapartPlain[place];
                }

                foreach (char item in datapartCipher)
                {
                    zaszyfrowany = zaszyfrowany + item.ToString();
                }
                
            }

            Console.WriteLine("PS1_zad2 String zaszyfrowany: " + zaszyfrowany);
            #endregion

            #region rozszyfrowywanie
            string rozszyfrowany = "";

            for (int i = 0; i < temp; i = i + d)
            {
                char[] datapartZasz = zaszyfrowany.Substring(0, d).ToCharArray();
                zaszyfrowany = zaszyfrowany.Remove(0, d);
                char[] datapartTekst = new char[d];


                // wstawiamy po kolei kazdy znak do tymczasowej tabeli 

                for (int j = 0; j < d; j++)
                {
                    int place = klucz[j] - 1;
                   
                    datapartTekst[place] = datapartZasz[j];
                }

                foreach (char item in datapartTekst)
                {
                    rozszyfrowany = rozszyfrowany + item.ToString();
                }

            }

            Console.WriteLine("PS1_zad2 String rozszyfrowany: " + rozszyfrowany);

            #endregion

            Console.ReadKey();

        }
    }
}
