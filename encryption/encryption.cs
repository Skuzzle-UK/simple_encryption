﻿//Created by and copyright of Nicholas Edward Bailey 10/08/2021
//
//Simple encription class
//
//Encryption requires a unique identifier / passphrase provided during encryption and required to decrypt.
//Dont lose the identifier or you'll never get the data back.
//
//Pass data as a string by calling encrypt(data, identifier), returns a string of hexadecimal.
//Get data back by passing the encrypted hexstring through decrypt(hexstring, identifier), returns the data as a string.

using System;
using System.Text;

namespace encription
{
    class encription
    {
        static void Main(string[] args)
        {
        Start:
            Console.Clear();
            Console.WriteLine("Select:");
            Console.WriteLine("1. Encrypt");
            Console.WriteLine("2. Decrypt");
            Console.WriteLine("3. Exit");
            int selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 1)
            {
                enc();
            }
            else if (selection == 2)
            {
                dec();
            }
            else if (selection == 3)
            {
                goto Finish;
            }
            else
            {
                goto Start;
            }
            Console.WriteLine("Press any key to close...");
            string close = Console.ReadLine();
        Finish:
            return;
        }

        private static void enc()
        {
            Console.Clear();
            Console.WriteLine("Input a unique identifier (Dont forget this as it is needed to decrypt: ");
            string ident = Console.ReadLine();
            Console.Write("Input string to be encoded: ");
            string str = encrypt(Console.ReadLine(), ident);
            Console.WriteLine("Encrypted string: " + str);
        }

        private static void dec()
        {
            Console.Clear();
            Console.WriteLine("Input unique identifier that was used during encryption: ");
            string ident = Console.ReadLine();
            Console.Write("Input string to be decoded: ");
            string str = decrypt(Console.ReadLine(), ident);
            Console.WriteLine("Decoded string: " + str);
        }

        public static string encrypt(string input, string ident)
        {
            return encryptAlg(input, ident);
        }

        public static string decrypt(string input, string ident)
        {
            return decryptAlg(input, ident);
        }

        private static string encryptAlg(string input, string ident)
        {
            string hexed = ToHexString(input);
            StringBuilder sb = new StringBuilder();
            for (int i = hexed.Length; i > 0; i--)
            {
                sb.Append(hexed.Substring(i - 1, 1));
            }
            sb.Append(ident);
            hexed = ToHexString(sb.ToString());
            sb.Clear();
            for (int i = hexed.Length; i > 0; i--)
            {
                sb.Append(hexed.Substring(i - 1, 1));
            }
            return sb.ToString();
        }

        private static string decryptAlg(string input, string ident)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = input.Length; i > 0; i--)
            {
                sb.Append(input.Substring(i - 1, 1));
            }

            input = FromHexString(sb.ToString());
            string check = input.Substring(input.Length - ident.Length, ident.Length);
            if (check != ident)
            {
                return "Stop#Hacking!";
            }
            else
            {
                input = input.Substring(0, input.Length - ident.Length);
            }
            sb.Clear();

            for (int i = input.Length; i > 0; i--)
            {
                sb.Append(input.Substring(i - 1, 1));
            }
            input = FromHexString(sb.ToString());
            return input;
        }

        private static string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }

        private static string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes);
        }
    }
}