using CardsWarGame;
using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    public class WarDeck : Deck
    {
        private const int _numOfCards = 52;
        private Queue<Card> _stack = new Queue<Card>(52);

        public override Card DrawCard()
        {
            return _stack.Dequeue();
        }

        public override void CreateDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    var card = new Card((Card.Value)j, (Card.Type)i);
                    _stack.Enqueue(card);
                }
            }
        }

        public override int Size()
        {
            return this._stack.Count;
        }

        public override bool IsEmpty()
        {
            return 0 == _stack.Count;
        }

        public override void AddCardToDeck(Card card)
        {
            _stack.Enqueue(card);
        }

        public override void ShuffleDeck()
        {
            Random random = new Random();

            for (int i = _stack.Count - 1; i > 1; i--)
            {
                int randomType = random.Next(i) % 4;
                int randomValue = random.Next(i) % 14;

                Card newCard = new Card((Card.Value)randomType, (Card.Type)randomValue);
                _stack.Enqueue(newCard);
            }
        }
    }
}
