using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsWarGame
{
    public class Deck : IDeck
    {
        private const int _numOfCards = 52;
        private List<Card> _stack = new List<Card>(52);

        public List<Card> Cards { get; private set; }

        public virtual Card DrawCard()
        {
            Card card = null;

            try 
            {
                if(null != _stack && _stack.Count > 0)
                { 
                    card = _stack[0];
                    _stack.Remove(card);
                }
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
                throw;
            }            

            return card;
        }

        public virtual void CreateDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    var card = new Card((Card.Value)j,(Card.Type)i);
                    _stack.Add(card);
                }
            }
        }

        public virtual int Size()
        {
           return (int)(this._stack?.Count);
        }

        public virtual bool IsEmpty()
        {
            return 0 == _stack?.Count;
        }

        public virtual void AddCardToDeck(Card card)
        {
            _stack.Add(card);
        }

        public virtual void ShuffleDeck()
        {
            Random random = new Random();

            for (int i = _stack.Count - 1; i > 1; i--)
            {
                int index = random.Next(i);

                try
                { 
                    Card card = _stack.ElementAt(index);
                    _stack[index] = _stack[i];
                    _stack[i] = card;
                } 
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
        }

        public void DealCards(Player firstPlayer, Player secondPlayer)
        {
            if(firstPlayer.HasCards() && secondPlayer.HasCards()) return;

            var totalCards = _stack.Count;

            for (int i = 0; i < totalCards; i++)
            {
                var card = DrawCard();

                if (i % 2 == 0)
                {
                    firstPlayer.AddCard(card);
                }
                else
                {
                    secondPlayer.AddCard(card);
                }
            }
        }
    }
}
