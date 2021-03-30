using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameofWar
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Deck { get; set; }

        public Player(string name)
        {
            this.Name = name;
            Deck = new List<Card>();
        }

        public static List<Card> Deal (List<Card> cards)
        {
            var DealtDeck = new List<Card>();
            foreach (var c in cards.Where((x, i) => i % 2 == 0).ToList())
            {
                DealtDeck.Add(c);
                cards.Remove(c);
            }
            
            return DealtDeck;
        }
    }
}
