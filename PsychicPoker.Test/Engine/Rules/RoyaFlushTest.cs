using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PsychicPoker.Domain;
using PsychicPoker.Engine.Rules;
using System.Linq;

namespace PsychicPoker.Test.Engine.Rules
{
    [TestClass]
    public class RoyaFlushTest
    {
        [TestMethod]
        public void CardList_Is_RoyalFlush()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Eight,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts }
            };

            var rule = new RoyalFlush();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNotNull(hand);
            Assert.AreEqual("Royal Flush", hand.Name);
            Assert.AreEqual(500, hand.RankPrimary);

            Assert.IsTrue( hand.Cards.All(x => x.Suit == CardSuit.Hearts));
            Assert.IsTrue( hand.Cards.Any( x=> x.FaceValue == CardFaceValue.Ten));
            Assert.IsTrue( hand.Cards.Any( x=> x.FaceValue == CardFaceValue.Jack));
             Assert.IsTrue( hand.Cards.Any( x=> x.FaceValue == CardFaceValue.Queen));
             Assert.IsTrue( hand.Cards.Any( x=> x.FaceValue == CardFaceValue.King));
            Assert.IsTrue( hand.Cards.Any( x=> x.FaceValue == CardFaceValue.Ace));
        }

        [TestMethod]
        public void CardList_Is_Not_RoyalFlush()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Eight,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Diamonds }
            };

            var rule = new RoyalFlush();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNull(hand);
         
        }
    }
}
