using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Hand
    {
        private readonly Guid _playerId;
        private readonly List<Card> _cards;
        private readonly HandEvaluator _handEvaluator;

        public Guid PlayerId { get { return _playerId; }}
        public List<Card> Cards { get { return _cards; } }

        public Hand(List<Card> cards)
        {
            _cards = cards;
            _playerId = Guid.NewGuid();
            _handEvaluator = new HandEvaluator();
        }

        public KeyValuePair<HandResult, int> GetHandResultWithHighCard()
        {
            var result = _handEvaluator.GetHandResult(Cards);

            var highCard = Cards.OrderByDescending(c => c.CardValue).FirstOrDefault();

            return new KeyValuePair<HandResult, int>(result, (int)highCard.CardValue);
        }
    }
}
