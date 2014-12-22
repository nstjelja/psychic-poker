using Microsoft.VisualStudio.TestTools.UnitTesting;
using PsychicPoker.Domain;
using PsychicPoker.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Test.Engine.Rules
{
    [TestClass]
    public class FlushTest
    {
        [TestMethod]
        public void CardList_Is_Flush()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Eight,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts },
                 new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Hearts }
            };

            var rule = new FlushRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNotNull(hand);

            Assert.AreEqual("Flush", hand.Name);
            Assert.AreEqual(700, hand.RankPrimary);
            Assert.AreEqual(14, hand.RankSecondry);
        }

        [TestMethod]
        public void CardList_Is_Not_Flush()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Eight,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.HighAce,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts },
                 new Card(){FaceValue = CardFaceValue.Five,Suit = CardSuit.Hearts }
            };

            var rule = new FlushRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNotNull(hand);

            Assert.AreEqual("Flush", hand.Name);
            Assert.AreEqual(700, hand.RankPrimary);
            Assert.AreEqual(14, hand.RankSecondry);
        }
    }
}
