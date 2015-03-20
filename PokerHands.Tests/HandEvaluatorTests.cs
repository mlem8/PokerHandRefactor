using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace PokerHands.Tests
{
    [TestFixture]
    public class HandEvaluatorTests
    {
        private HandEvaluator _handEvaluator;

        [SetUp]
        public void SetUp()
        {
            _handEvaluator = new HandEvaluator();
        }

        [Test]
        public void GetResults_IfHandIsFullHouse_ReturnsFullHouse()
        {
            // Arrange
            var cards = new List<Card>
                        {
                                new Card(CardValue.Three, Suit.Heart),
                                new Card(CardValue.Three, Suit.Club),
                                new Card(CardValue.Three, Suit.Diamond),
                                new Card(CardValue.Ten, Suit.Club),
                                new Card(CardValue.Ten, Suit.Diamond)
                        };
            // Act
            var result = _handEvaluator.GetHandResult(cards);
            // Assert
            result.Should().Be(HandResult.FullHouse);
        }

        [Test]
        public void GetResults_IfHandIsStraightFlush_ReturnsStraightFlush()
        {
            // Arrange
            var cards = new List<Card>
                        {
                                new Card(CardValue.Two, Suit.Club),
                                new Card(CardValue.Three, Suit.Club),
                                new Card(CardValue.Four, Suit.Club),
                                new Card(CardValue.Five, Suit.Club),
                                new Card(CardValue.Six, Suit.Club)
                        };
            // Act
            var result = _handEvaluator.GetHandResult(cards);
            // Assert
            result.Should().Be(HandResult.StraightFlush);
        }
    }
}
