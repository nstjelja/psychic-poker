﻿using PsychicPoker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Engine
{
    public abstract class Rule
    {
        #region Memebers
        protected List<CardSuit> m_Suits = new List<CardSuit>() { 
                CardSuit.Clubs, CardSuit.Diamonds, CardSuit.Hearts, CardSuit.Spades
            };
        #endregion Members

        #region Abstract
        public abstract Hand BuildStrongestHand(List<Card> cards);
        #endregion Abstract

        #region Methods
        protected List<Card> FindCardsOfSameSuit(List<Card> cards, CardSuit suit)
        {
            var cardsInSuit = cards.Where(x => x.Suit == suit).ToList();
            return cardsInSuit;
        }

        protected List<Card> OrderCardListBasedOnSuitValue(List<Card> cards)
        {
            var ordering = cards.OrderBy(card => (int)card.FaceValue).ToList();

            return ordering;
        
        }
        #endregion Methods
    }
}
