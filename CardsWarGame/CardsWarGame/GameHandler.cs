using System;
using System.Collections.Generic;

namespace CardsWarGame
{
    internal class GameHandler
    {
        static void Main(string[] args)
        {
            try
            {
                Player firstPlayer  = new Player("Player1");
                Player secondPlayer = new Player("Player2");

                Game game = new Game(firstPlayer,secondPlayer);
                game.Play();
            } 
            catch (Exception e) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opps.... something went wrong please start a new game");
            }           
        }        
    }
}
