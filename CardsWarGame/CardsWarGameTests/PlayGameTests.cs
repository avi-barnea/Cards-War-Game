using CardsWarGame;

namespace CardsWarGameTests
{
    public class PlayGameTests
    {
        [Fact]
        public void PlayerWithBetterCardsShouldWin()
        {
            Card card1 = new Card(Card.Value.Eight, Card.Type.Spades);
            Card card2 = new Card(Card.Value.Ten,   Card.Type.Diamonds);

            Deck deck1 = new Deck();
            deck1.AddCardToDeck(card1);

            Deck deck2 = new Deck();
            deck2.AddCardToDeck(card2);

            Player player1 = new Player(deck1,"player1");
            Player player2 = new Player(deck2,"player2");

            Game game = new Game(player1,player2);

            var winner = game.Play();

            Assert.True(winner == player2);
        }

        [Fact]
        public void PlayerWithBetterCardsShouldWinaWar()
        {
            Card card1 = new Card(Card.Value.Eight, Card.Type.Spades);
            Card card2 = new Card(Card.Value.Eight, Card.Type.Diamonds);
            Card card3 = new Card(Card.Value.King, Card.Type.Spades);
            Card card4 = new Card(Card.Value.Ten, Card.Type.Diamonds);
            Card card5 = new Card(Card.Value.Four, Card.Type.Clubs);
            Card card6 = new Card(Card.Value.Two, Card.Type.Hearts);
            Card card7 = new Card(Card.Value.Seven, Card.Type.Spades);
            Card card8 = new Card(Card.Value.Queen, Card.Type.Hearts);

            Deck deck1 = new Deck();
            deck1.AddCardToDeck(card1);
            deck1.AddCardToDeck(card3);
            deck1.AddCardToDeck(card4);
            deck1.AddCardToDeck(card7);

            Deck deck2 = new Deck();
            deck2.AddCardToDeck(card2);
            deck2.AddCardToDeck(card5);
            deck2.AddCardToDeck(card6);
            deck2.AddCardToDeck(card8);

            Player player1 = new Player(deck1, "player1");
            Player player2 = new Player(deck2, "player2");

            Game game = new Game(player1, player2);

            var winner = game.Play();

            Assert.True(winner == player2);
        }
    }
}
