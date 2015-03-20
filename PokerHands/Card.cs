using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Card
    {
        private readonly CardValue _cardValue;
        private readonly Suit _suit;

        public CardValue CardValue { get { return _cardValue; } }

        public Suit Suit { get { return _suit; } }

        public Card(CardValue value, Suit suit)
        {
            _cardValue = value;
            _suit = suit;
        }
    }
}
