using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PsychicPoker.Domain;
using PsychicPoker.Engine.Rules;
using System.Collections.Generic;

namespace PsychicPoker.Test.Engine.Rules
{
    [TestClass]
    public class StraightTest
    {
        [TestMethod]
        public void CardList_Is_Straight()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Two,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Three,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts }
            };

            var rule = new StraightRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNotNull(hand);
            Assert.AreEqual("Straight", hand.Name);
            Assert.AreEqual(500, hand.RankPrimary);
           
        }

        [TestMethod]
        public void CardList_Is_Not_Straight()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Two,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Seven,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts }
            };

            var rule = new StraightRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNull(hand);
           

        }
    }
}
