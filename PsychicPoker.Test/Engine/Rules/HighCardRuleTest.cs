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
    public class HighCardRuleTest
    {
        [TestMethod]
        public void CardList_Is_HighCard() 
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

            var rule = new HighCardRule();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNotNull(hand);
            Assert.AreEqual("High card", hand.Name);
            Assert.AreEqual(100, hand.RankPrimary);
          
        }
    }
}
