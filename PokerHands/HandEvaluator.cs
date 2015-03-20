using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class HandEvaluator
    {
        private bool _isFlush;
        private bool _isStraight;
        private Dictionary<CardValue, int> _cardPairs = new Dictionary<CardValue, int>();

        public bool IsFlush { get { return _isFlush; } }
        public bool IsStraight { get { return _isStraight; } }

        public HandResult GetHandResult(List<Card> cards)
        {
            DetermineIfFlush(cards);

            DetermineIfStraight(cards);

            DetermineAllPairs(cards);

            return EvaluateHand();
        }

        private HandResult EvaluateHand()
        {
            if (_isFlush && _isStraight) return HandResult.StraightFlush;

            if (_cardPairs.ContainsValue(4)) return HandResult.FourOfAKind;

            if (_cardPairs.ContainsValue(3) && _cardPairs.Count > 1) return HandResult.FullHouse;

            if (_isFlush) return HandResult.Flush;

            if (_isStraight) return HandResult.Straight;

            if (_cardPairs.ContainsValue(3)) return HandResult.ThreeOfAKind;

            if (_cardPairs.Count > 1) return HandResult.TwoPair;

            if (_cardPairs.Count == 1) return HandResult.OnePair;

            return HandResult.HighCard;
        }

        private void DetermineAllPairs(List<Card> cards)
        {
            var pairs = cards.GroupBy(c => c.CardValue);

            foreach (var pairGroup in pairs)
            {
                _cardPairs.Add(pairGroup.Key, pairGroup.Count());
            }
        }

        private void DetermineIfStraight(List<Card> cards)
        {
            var cardValues = cards.Select(c => c.CardValue).ToList();

            _isStraight = !cardValues.Select((i, j) => i - j).Distinct().Skip(1).Any();
        }

        private void DetermineIfFlush(List<Card> cards)
        {
            var suits = cards.GroupBy(c => c.Suit);

            if (suits.Count() == 1) _isFlush = true;
        }
    }
}
