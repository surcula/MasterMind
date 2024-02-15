using System;
using System.Diagnostics;
using System.Threading;
using MasterMind;
using MasterMind.MasterMind;

class Program
{ 
    static int selectedOption = 0;
    static string[] menuOptions = { "New Game", "Exit" };


    static void Main(string[] args)
    {
       

        //Boucle du menu
        while (true)
        {
            Console.Clear();
            DrawMenu();
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (selectedOption - 1 + menuOptions.Length) % menuOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption + 1) % menuOptions.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                if (selectedOption == 0)
                {
                    StartGame();
                }
                else if (selectedOption == 1)
                {
                    Environment.Exit(0);
                }
            }

        }

        //Affichage du menu
        static void DrawMenu()
        {
            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;

            Console.SetCursorPosition(centerX, centerY - (menuOptions.Length / 2));
            Console.WriteLine("MASTERMIND");
            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.SetCursorPosition(centerX - (menuOptions[i].Length / 2), Console.CursorTop + 1);
                Console.WriteLine(menuOptions[i]);
            }
        }

        //Le jeu
        static void StartGame()
        {
            MasterMindGame mastermind = new MasterMindGame();
            mastermind.CreateReponse();
            
        }

    }
}