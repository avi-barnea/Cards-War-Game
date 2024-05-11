namespace CardsWarGame
{
    public interface IDeck
    {   void CreateDeck();
        void ShuffleDeck();
        Card DrawCard();
        void AddCardToDeck(Card card);
        bool IsEmpty();        
        int Size();
    }
}
