﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using PsychicPoker.Domain;

namespace PsychicPoker.Test.Engine.Rules
{
    [TestClass]
    public class FourOfKindTest
    {
        [TestMethod]
        public void CardList_Is_FourOfKind()
        {
            var cardList = new List<Card>() { 
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Clubs },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Diamonds },
                new Card(){FaceValue = CardFaceValue.Jack,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Spades },
                new Card(){FaceValue = CardFaceValue.Ace,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Ten,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Four,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.Queen,Suit = CardSuit.Hearts },
                new Card(){FaceValue = CardFaceValue.King,Suit = CardSuit.Hearts }
            };

            var rule = new RoyalFlush();
            var hand = rule.BuildStrongestHand(cardList);

            Assert.IsNotNull(hand);
            Assert.AreEqual("Royal Flush", hand.Name);
            Assert.AreEqual(800, hand.RankPrimary);

        
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Jack));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Jack));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Jack));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Jack));
            Assert.IsTrue(hand.Cards.Any(x => x.FaceValue == CardFaceValue.Jack));
        }
    }
}