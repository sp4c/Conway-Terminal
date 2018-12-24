﻿using System;

namespace Conway_Terminal
{

    class Program
    {

        public static void Main(string[] args)
        {

            var newGame = new Conway();
            while (true)
            {
                Console.Clear();
                //newGame.DrawFrame();
                newGame.DrawBoth();
                System.Threading.Thread.Sleep(500);
            }

        }
        public static string Prompt(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

    }
}
