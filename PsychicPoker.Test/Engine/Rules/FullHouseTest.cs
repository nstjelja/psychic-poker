using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using PsychicPoker.Domain;
using PsychicPoker.Engine.Rules;


namespace PsychicPoker.Test.Engine.Rules
{
    [TestClass]
    public class FullHouseTest
    {
        [TestMethod]
        public void CardList_Is_FullHouse()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Eight,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts },
                 new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Hearts }
            };

            var rule = new FullHouseRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNotNull(hand);
            Assert.AreEqual("Full House", hand.Name);
            Assert.AreEqual(700, hand.RankPrimary);
            Assert.AreEqual(61, hand.RankSecondry);


            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Jack && x.Suit == CardSuit.Spades));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Jack && x.Suit == CardSuit.Clubs));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Jack && x.Suit == CardSuit.Diamonds));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.HighAce &&  x.Suit == CardSuit.Spades));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.HighAce && x.Suit == CardSuit.Hearts));
        }

        [TestMethod]
        public void CardList_Is_Not_FullHouse()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Eight,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts },
                 new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Hearts }
            };

            var rule = new FullHouseRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNull(hand);
           
        }
    }
}
