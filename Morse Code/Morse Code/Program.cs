﻿using System.Text.RegularExpressions;
using System;
namespace MorseCode
{
    class Definitions
    {
        private string[] written;
        private string[] morse = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "-----", ".-.-.-", "--..--", "..--..", "|", "" };
        private string[] english = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "Stop", ",", "?", " ", "" };
        public Definitions(string[] written1)
        {
            this.written = written1;
        }
        public string Translation()
        {
            string newRes = "";
            for (int i = 0; i < written.Length; i++)
            {
                newRes += morse[Array.IndexOf(english, written[i])];
            }
            return newRes;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            global::System.Console.WriteLine("Write a line to convert to morse code.");
            string[] morse = Regex.Split(Console.ReadLine().ToLower(), string.Empty);
            Definitions morse1 = new Definitions(morse);
            global::System.Console.WriteLine("This translates to: {0}", morse1.Translation());
        }
    }
}