using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PsychicPoker.Domain;
using System.Collections.Generic;
using PsychicPoker.Engine.Rules;
using System.Linq;

namespace PsychicPoker.Test.Engine.Rules
{
    [TestClass]
    public class StraightFlushRuleTest
    {
        [TestMethod]
        public void CardList_Is_Straight_Flush()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Two,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Three,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts }
            };

            var rule = new StraightFlushRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNotNull(hand);
            Assert.AreEqual("Straight flush", hand.Name);
            Assert.AreEqual(900, hand.RankPrimary);
            Assert.AreEqual(60, hand.RankSecondry);

            Assert.IsTrue(hand.Cards.All(x => x.Suit == CardSuit.Hearts));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Ten));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Jack));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Queen));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.King));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.HighAce));
        }

        [TestMethod]
        public void CardList_Is_Not_Straight_Flush()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Two,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Three,Suit = CardSuit.Clubs},
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts }
            };

            var rule = new StraightFlushRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNull(hand);
          
        }
    }
}
