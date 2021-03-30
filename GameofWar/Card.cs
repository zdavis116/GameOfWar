using System;
using System.Collections.Generic;
using System.Text;

namespace GameofWar
{
    public class Card
    {
        public Suits Suit { get; set; }
        public CardRank CardValue { get; set; }

        public Card(Suits suit, CardRank cardValue)
        {
            this.Suit = suit;
            this.CardValue = cardValue;
        }
    }
}
