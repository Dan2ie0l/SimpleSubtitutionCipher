using System;

namespace SimpleCipher
{
    class Program
    {
        public static string plainAlphabet = "abcdefghijklmnopqrstuvwxyz";
        static void Main(string[] args)
        {
            Console.Write("Text:");
            string text = Console.ReadLine();

            Console.Write("KeyWord:");
            string word = Console.ReadLine();
            string cipherAlphabet = keyWithWord(word);

            Console.WriteLine(cipherAlphabet);

            Console.Write("Choose(encipher/decipher):");
            string choose = Console.ReadLine();

            switch (choose)
            {
                case "encipher":
                    Console.WriteLine(Encipher(text, cipherAlphabet));
                    break;

                case "decipher":
                    Console.Write("Ciphered Text:");
                    string cipheredText = Console.ReadLine();
                    Console.WriteLine(Decipher(cipheredText, cipherAlphabet));
                    break;
                case "e":
                    Console.WriteLine(Encipher(text, cipherAlphabet));
                    break;

                case "d":
                    Console.Write("Ciphered Text:");
                    string cipherText = Console.ReadLine();
                    Console.WriteLine(Decipher(cipherText, cipherAlphabet));
                    break;
            }




        }

        private static string Cipher(string input, string newAlphabet, string oldAlphabet)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                int oldCharIndex = oldAlphabet.IndexOf(char.ToLower(input[i]));

                if (oldCharIndex >= 0)
                {
                    output += char.IsUpper(input[i]) ? char.ToUpper(newAlphabet[oldCharIndex]) : newAlphabet[oldCharIndex];
                }

                else
                {
                    output += input[i];
                }
            }

            return output;

        }

        public static string Encipher(string input, string cipherAlphabet)
        {

            return Cipher(input, plainAlphabet, cipherAlphabet);
        }

        public static string Decipher(string input, string cipherAlphabet)
        {

            return Cipher(input, cipherAlphabet, plainAlphabet);
        }

        public static string keyWithWord(string word)
        {
            string key = string.Empty;
            bool check = false;
            for (int i = 0; i < word.Length; i++)
            {
                if ((!key.Contains(word[i])) && (word[i] != ' '))
                {
                    key += word[i];
                }
            }
            for (int i = 0; i < plainAlphabet.Length; i++)
            {
                check = false;
                for (int j = 0; j < word.Length; j++)
                {
                    if (plainAlphabet[i] == word[j])
                    {
                        check = true;

                    }


                }
                if (check == false)
                {
                    key += plainAlphabet[i];
                    check = false;
                }

            }
            return key;
        }
    }



}
