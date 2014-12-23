using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PsychicPoker.Domain;
using System.Collections.Generic;
using PsychicPoker.Engine.Rules;
using System.Linq;

namespace PsychicPoker.Test.Engine.Rules
{
    [TestClass]
    public class TwoPairRuleTest
    {
        [TestMethod]
        public void CardList_Is_Two_Pairs()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Two,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts }
            };

            var rule = new TwoPairRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNotNull(hand);
            Assert.AreEqual("Two pair", hand.Name);
            Assert.AreEqual(300, hand.RankPrimary);
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Jack));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Queen));
        }

        [TestMethod]
        public void CardList_Is_Not_Two_Pairs()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Two,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Three,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Seven,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts }
            };

            var rule = new TwoPairRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNull(hand);
           
        }
    }
}
