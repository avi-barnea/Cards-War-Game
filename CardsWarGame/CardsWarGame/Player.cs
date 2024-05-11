using System;
using System.Collections.Generic;

namespace CardsWarGame
{
    public class Player
    {
        private IDeck _deck;
        private string _name;
        private Guid _id;

        public Player(string name)
        {
            _name = name;
            _id = Guid.NewGuid();
            _deck = new Deck();
        }
        public Player(IDeck deck, string name)
        {
            _deck = deck;
            _name = name;
            _id = Guid.NewGuid();
        }

        public string Name { get { return _name; } }
        public Guid Id { get { return _id; } }

        public Card DrawCard()
        {
            return _deck?.DrawCard();
        }

        public void AddCards(List<Card> cards)
        {
            foreach (var card in cards)
            {
                _deck?.AddCardToDeck(card);
            }
        }

        public void AddCard(Card card)
        {
           _deck?.AddCardToDeck(card);         
        }

        public bool HasCards()
        {
            return (bool)!_deck?.IsEmpty();
        }

        public int GetNumberOfCardsInDeck()
        {
            return (int)(_deck?.Size());
        }

        public List<Card> DrawMultipleCards(int count)
        {
            var drawnCards = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                if (!_deck.IsEmpty())
                    drawnCards.Add(DrawCard());
            }

            return drawnCards;
        }
    }
}
