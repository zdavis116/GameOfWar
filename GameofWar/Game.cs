using System;
using System.Collections.Generic;
using System.Text;

namespace GameofWar
{
    public class Game
    {
        public Player Player1;
        public Player Player2;
        
        public Game (string P1Name, string P2Name)
        {
            Player1 = new Player(P1Name);
            Player2 = new Player(P2Name);

            var cards = Deck.CardCreator();

            var splitDeck = Player.Deal(cards);
            Player1.Deck = splitDeck;
            Player2.Deck = cards;
        }

        public Boolean IsEndOfGame(int turnCount)
        {
            if (Player1.Deck.Count == 0)
            {
                Console.WriteLine(Player1.Name + " is out of cards! " + Player2.Name + " wins the game!");
                return true;
            }
            else if (Player2.Deck.Count == 0)
            {
                Console.WriteLine(Player2.Name + " is out of cards! " + Player1.Name + " wins the game!");
                return true;
            }
            else if (turnCount > 1000)
            {
                Console.WriteLine("Turn limit exceeded, lets call it a draw!");
                return true;
            }

            return false;
        }

        public void PlayTurn(Card p1, Card p2)
        {
            bool stillWar = true;
            
            Console.WriteLine(Player1.Name + " plays "
                              + p1.CardValue + ", " 
                              + Player2.Name + " plays " + p2.CardValue);

            Player1.Deck.Remove(p1);
            Player2.Deck.Remove(p2);

            if ((int)p1.CardValue > (int)p2.CardValue) 
            {
                Player1.Deck.Add(p2);
                Player1.Deck.Add(p1);
                Console.WriteLine(Player1.Name + " wins the hand!");
            }
            else if ((int)p2.CardValue > (int)p1.CardValue)
            {
                Player2.Deck.Add(p1);
                Player2.Deck.Add(p2);
                Console.WriteLine(Player2.Name + " wins the hand!");
            }
            else
            {
                var Player1Cards = new List<Card>();
                var Player2Cards = new List<Card>();

                while ((int)p1.CardValue == (int)p2.CardValue && stillWar)
                {
                    Console.WriteLine("WAR!");

                    for(int i = 0; i < Player1.Deck.Count && i <= 3; i++)
                    {
                        var p1CardVal = Player1.Deck[i];
                        Player1Cards.Add(p1CardVal);
                        Player1.Deck.Remove(p1CardVal);
                    }

                    for (int i = 0; i < Player2.Deck.Count && i <= 3; i++)
                    {
                        var p2CardVal = Player2.Deck[i];
                        Player2Cards.Add(p2CardVal);
                        Player2.Deck.Remove(p2CardVal);
                    }

                    if (Player1Cards.Count == 0)
                    {
                        stillWar = false;
                        Console.WriteLine(Player1.Name + " ran out of cards");
                    }
                    else if (Player2Cards.Count == 0)
                    {
                        stillWar = false;
                        Console.WriteLine(Player2.Name + " ran out of cards");
                    }
                    else
                    {
                        Console.WriteLine(Player1.Name + " plays "
                                      + Player1Cards[(Player1Cards.Count - 1)].CardValue + ", "
                                      + Player2.Name + " plays " + Player2Cards[(Player2Cards.Count - 1)].CardValue);


                        if ((int)Player1Cards[(Player1Cards.Count - 1)].CardValue != (int)Player2Cards[(Player2Cards.Count - 1)].CardValue)
                        {
                            stillWar = false;

                            if ((int)Player1Cards[(Player1Cards.Count - 1)].CardValue < (int)Player2Cards[(Player2Cards.Count - 1)].CardValue)
                            {
                                foreach (var p1c in Player1Cards)
                                {
                                    Player2.Deck.Add(p1c);
                                }
                                foreach (var p2c in Player2Cards)
                                {
                                    Player2.Deck.Add(p2c);
                                }

                                Console.WriteLine(Player1.Name + " wins the hand!");
                            }
                            else
                            {
                                foreach (var p1c in Player1Cards)
                                {
                                    Player1.Deck.Add(p1c);
                                }
                                foreach (var p2c in Player2Cards)
                                {
                                    Player1.Deck.Add(p2c);
                                }

                                Console.WriteLine(Player1.Name + " wins the hand!");
                            }
                        }
                    }
                    
                }
               
            }
        }
    }
}
