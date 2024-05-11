using CardsWarGame;
using System.Numerics;

namespace CardsWarGameTests
{
    public class BasicGameTests
    {
        [Fact]
        public void DeckInitializationShouldPass()
        {
            Deck deck = new Deck();
            deck.CreateDeck();

            Assert.Equal(52, deck.Size());
        }

        [Fact]
        public void DeckShuffleShouldMixCards()
        {
            Deck deck = new Deck();
            deck.CreateDeck();

            List<Card> originalCards = new List<Card>(deck.Cards);
            deck.ShuffleDeck();

            Assert.NotEqual(originalCards, deck.Cards);
        }

        [Fact]
        public void DealCardsShouldSplitDeckBetweenPlayersEvenly()
        {
            Deck deck = new Deck();
            deck.CreateDeck();

            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            deck.DealCards(player1, player2);

            Assert.Equal(26, player1.GetNumberOfCardsInDeck());
            Assert.Equal(26, player2.GetNumberOfCardsInDeck());
        }
    }
}