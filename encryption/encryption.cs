using System;
using System.Text;

namespace encryption
{
    class Encrpytion
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
            Console.Write("Input string to be encoded: ");
            string str = encrypt(Console.ReadLine());
            Console.WriteLine("Encoded string: " + str);
        }

        private static void dec()
        {
            Console.Clear();
            Console.Write("Input string to be decoded: ");
            string str = decrypt(Console.ReadLine());
            Console.WriteLine("Decoded string: " + str);
        }

        private static string encrypt(string input)
        {
            string hexed = ToHexString(input);
            StringBuilder sb1 = new StringBuilder();
            for (int i = hexed.Length; i > 0; i--)
            {
                sb1.Append(hexed.Substring(i - 1, 1));
            }

            hexed = ToHexString(sb1.ToString());
            StringBuilder sb2 = new StringBuilder();
            for (int i = hexed.Length; i > 0; i--)
            {
                sb2.Append(hexed.Substring(i - 1, 1));
            }
            return sb2.ToString();
        }

        private static string decrypt(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = input.Length; i > 0; i--)
            {
                sb.Append(input.Substring(i - 1, 1));
            }

            input = FromHexString(sb.ToString());
            sb.Clear();

            for (int i = input.Length; i > 0; i--)
            {
                sb.Append(input.Substring(i - 1, 1));
            }

            return FromHexString(sb.ToString());
        }

        public static string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }

        public static string FromHexString(string hexString)
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
