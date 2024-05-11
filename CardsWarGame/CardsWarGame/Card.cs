using System;

namespace CardsWarGame
{
    public class Card
    {
        public enum Type:int { Spades = 0, Hearts, Clubs, Diamonds };
        public enum Value:int { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

        private Type type;
        private Value value;

        public Card(Value value , Type type)
        {
            this.value = value;
            this.type = type;
        }

        public void Print()
        {
            Console.WriteLine($"{this.value.ToString()} of {this.type.ToString()} ");
        }

        public override string ToString()
        {
            return ($"{this.value.ToString()} of {this.type.ToString()} ");
        }
        public int GetValue()
        {
            return (int)this.value;
        }
    }
}
