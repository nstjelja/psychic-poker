using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PsychicPoker.Domain;
using System.Collections.Generic;
using PsychicPoker.Engine.Rules;

namespace PsychicPoker.Test.Engine.Rules
{
    [TestClass]
    public class ThreeOfAKindTest
    {
        [TestMethod]
        public void CardList_Is_Three_Of_A_Kind()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Two,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts }
            };

            var rule = new ThreeOfAKindRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNotNull(hand);
            Assert.AreEqual("Three of a kind", hand.Name);
            Assert.AreEqual(400, hand.RankPrimary);
        }

        [TestMethod]
        public void CardList_Is_Not_Three_Of_A_Kind()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Two,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts }
            };

            var rule = new ThreeOfAKindRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNull(hand);
      
        }
    }
}
