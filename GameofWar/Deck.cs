using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GameofWar
{
    public static class Deck
    {
        public static List<Card> CardCreator()
        {
            List<Card> tempDeck = new List<Card>();

            foreach (CardRank value in Enum.GetValues(typeof(CardRank)))
            {
                foreach (Suits s in Enum.GetValues(typeof(Suits)))
                {
                    var card = new Card(s, value);
                    tempDeck.Add(card);
                }
            }

            return Shuffle(tempDeck);
        }

        private static readonly Random rng = new Random();
        public static List<Card> Shuffle (List<Card> cards)
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card temp = cards[k];
                cards[k] = cards[n];
                cards[n] = temp;
            }

            return cards;
        }
    }
}
