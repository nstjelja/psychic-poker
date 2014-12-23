using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PsychicPoker.Engine.Rules;
using PsychicPoker.Domain;
using System.Linq;
using System.Collections.Generic;

namespace PsychicPoker.Test.Engine.Rules
{
    [TestClass]
    public class OnePairRuleTest
    {
        [TestMethod]
        public void CardList_Is_One_Pair()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Two,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Nine,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts }
            };

            var rule = new OnePairRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNotNull(hand);
            Assert.AreEqual("One pair", hand.Name);
            Assert.AreEqual(200, hand.RankPrimary);
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Jack));
            
        }

        [TestMethod]
        public void CardList_Is_Not_One_Pair()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Two,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Nine,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts }
            };

            var rule = new OnePairRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNull(hand);
           

        }
    }
}
