using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.MasterMind
{
    /*
     * Un objet
     * Une réponse de 5 couleurs
     * 10 Lignes
     * 5 couleurs (Bleu, Jaune, Vert, Rouge, Noir)
     *
     *-> On demande la réponse
     *->boucle
     *-->On demande une solution
     *-->On vérifie Si oui -> victoire Si non on recommence en indiquant l'aide.
     * 
     */

    public class MasterMindGame
    {
        //Création du tableau colors
        private string[] colorsChoices = {"Bleu","Jaune","Vert","Rouge","Noir"};
        // La réponse
        public string[] response = new string[5];
        // Le jeu
        public string[,] gameBoard = new string[10, 5];
        // La sélection
        int selectedOptionGame = 0;


        //Méthode pour créer la réponse
        public void CreateReponse()
        {
            Console.Clear();
            Console.WriteLine("Choix de la réponse:");

            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2 - colorsChoices.Length / 2 - 2;
            int currentIndex = 0;
            int selectedColorsCount = 0;

            while (selectedColorsCount < 5)
            {
                Console.Clear();
                Console.WriteLine("Choix de la réponse:");
                Console.WriteLine($"Étape {selectedColorsCount + 1} sur 5\n");

                for (int i = 0; i < colorsChoices.Length; i++)
                {
                    if (i == currentIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.SetCursorPosition(centerX - colorsChoices[i].Length / 2, centerY + i);
                    Console.WriteLine(colorsChoices[i]);
                }

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentIndex = (currentIndex == 0) ? colorsChoices.Length - 1 : currentIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        currentIndex = (currentIndex == colorsChoices.Length - 1) ? 0 : currentIndex + 1;
                        break;
                    case ConsoleKey.Enter:
                        response[selectedColorsCount] = colorsChoices[currentIndex];
                        selectedColorsCount++;
                        break;
                }
            }
        }

    }
}
