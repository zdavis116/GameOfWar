using System;
using System.Collections.Generic;

namespace GameofWar
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game("Ryan", "Zach");

            int turnCount = 0;

            bool EndGame = false;

            while (!EndGame)
            {
                turnCount++;

                if (game.IsEndOfGame(turnCount) == true)
                {
                    EndGame = true;
                }
                else
                {
                    game.PlayTurn(game.Player1.Deck[0], game.Player2.Deck[0]);
                    EndGame = false;
                }

            }

            Console.WriteLine(game.Player1.Name + " has this many cards in his deck " + game.Player1.Deck.Count);
            Console.WriteLine(game.Player2.Name + " has this many cards in his deck " + game.Player2.Deck.Count);

            Console.Read();         

        }
    }
}
