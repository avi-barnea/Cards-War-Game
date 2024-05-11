using System;
using System.Collections.Generic;

namespace CardsWarGame
{
    public class Game
    {
        private Player _firstPlayer;
        private Player _secondPlayer;
        private Deck _mainDeck;

        public Game(Player player1, Player player2, Deck deck = null) 
        {
            _firstPlayer = player1;
            _secondPlayer = player2;
            _mainDeck = deck;
        }

        public Player Play()
        {
            try
            {
                Console.WriteLine("*****  Starting New Game  *****");

                Deck mainDeck = Initialize();

                mainDeck.DealCards(_firstPlayer, _secondPlayer);

                int round = 1;
                do
                {
                    PrintRoundStats(_firstPlayer, _secondPlayer, round++);

                    Card firstPlayingCard = DrawCard(_firstPlayer);
                    Card secondPlayingCard = DrawCard(_secondPlayer);

                    if (firstPlayingCard.GetValue() > secondPlayingCard.GetValue())
                    {
                        AddCardsToWinner(_firstPlayer, firstPlayingCard, secondPlayingCard);
                    }
                    else if (firstPlayingCard.GetValue() < secondPlayingCard.GetValue())
                    {
                        AddCardsToWinner(_secondPlayer, firstPlayingCard, secondPlayingCard);
                    }
                    else
                    {
                        Console.WriteLine("WAR!");

                        HandleWar(_firstPlayer, _secondPlayer, new List<Card> { firstPlayingCard, secondPlayingCard });
                    }

                } while (_firstPlayer.HasCards() && _secondPlayer.HasCards());

                DeclareAWinner(_firstPlayer, _secondPlayer);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opps... something went wrong please start a new game");
            }

            if(_firstPlayer.GetNumberOfCardsInDeck() > _secondPlayer.GetNumberOfCardsInDeck()) return _firstPlayer;
            else return _secondPlayer;
        }

        #region Private Methods

        private void PrintRoundStats(Player _firstPlayer, Player _secondPlayer, int round)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($" Round {round}");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"{_firstPlayer.Name}  has {_firstPlayer.GetNumberOfCardsInDeck()}  cards");
            Console.WriteLine($"{_secondPlayer.Name} has {_secondPlayer.GetNumberOfCardsInDeck()} cards");
        }

        private Card DrawCard(Player player)
        {
            var firstPlayingCard = player.DrawCard();

            Console.Write($"{player.Name} draw ");
            firstPlayingCard.Print();

            return firstPlayingCard;
        }

        private void DeclareAWinner(Player _firstPlayer, Player _secondPlayer)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            if (_firstPlayer.HasCards()) Console.WriteLine($"{_firstPlayer.Name} Won !!");
            else Console.WriteLine($"{_secondPlayer.Name} Won !!");
        }

        private void AddCardsToWinner(Player player, Card firstPlayingCard, Card secondPlayingCard)
        {
            Console.WriteLine($"{player.Name} won this hand");

            player.AddCard(firstPlayingCard);
            player.AddCard(secondPlayingCard);
        }

        private void HandleWar(Player _firstPlayer, Player _secondPlayer, List<Card> initialList)
        {
            // Players draw three more cards or as many has the player has
            List<Card> warCards1 = _firstPlayer.DrawMultipleCards(3);
            List<Card> warCards2 = _secondPlayer.DrawMultipleCards(3);

            PrintDrawnCards(_firstPlayer, warCards1);
            PrintDrawnCards(_secondPlayer, warCards2);

            List<Card> list = SavePlayingCards(initialList, warCards1, warCards2);

            if (warCards1[2].GetValue() > warCards2[2].GetValue())
            {
                _firstPlayer.AddCards(list);
                Console.WriteLine($"{_firstPlayer.Name} wins the war!");
            }
            else if (warCards1[2].GetValue() < warCards2[2].GetValue())
            {
                _secondPlayer.AddCards(list);
                Console.WriteLine($"{_secondPlayer.Name} wins the war!");
            }
            else
            {
                Console.WriteLine("Another WAR!");
                HandleWar(_firstPlayer, _secondPlayer, list);
            }
        }

        private List<Card> SavePlayingCards(List<Card> initialList, List<Card> warCards1, List<Card> warCards2)
        {
            var list = new List<Card>();
            int min = Math.Min(warCards1.Count, warCards2.Count);

            for (int i = 0; i < min; i++)
            {
                list.Add(warCards1[i]);
                list.Add(warCards2[i]);
            }

            list.AddRange(initialList);

            return list;
        }

        private void PrintDrawnCards(Player _firstPlayer, List<Card> warCards1)
        {
            Console.WriteLine($"{_firstPlayer.Name} plays {warCards1[0].ToString()} (face down)");
            Console.WriteLine($"{_firstPlayer.Name} plays {warCards1[1].ToString()} (face down)");
            Console.WriteLine($"{_firstPlayer.Name} plays {warCards1[2].ToString()}");
        }

        private Deck Initialize()
        {
            if ( _mainDeck != null ) return _mainDeck;

            var mainDeck = new Deck();
            try
            {
                mainDeck.CreateDeck();
                mainDeck.ShuffleDeck();
            }
            catch
            {
                Console.WriteLine("Opps.... Failed to start a new game");
                throw;
            }

            return mainDeck;
        }

        #endregion 
    }
}
