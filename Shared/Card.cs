using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//enums for use with card class
public enum Suit
{
    SPADES,
    CLUBS,
    DIAMONDS,
    HEARTS
}

public enum Value
{
    ACE,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX,
    SEVEN,
    EIGHT,
    NINE,
    TEN,
    JACK,
    QUEEN,
    KING
}

//base card class used by player and deck
namespace Shared
{
    public class Card
    {
        private Suit suit;
        private Value val;

        public Suit Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        public Value Value
        {
            get { return val; }
            set { val = value; }
        }

        public Card(Suit Suit, Value Value)
        {
            this.Suit = Suit;
            this.Value = Value;

        }

        public int CardValue()
        {
            int num = 0;
            switch (val)
            {
                case Value.ACE:
                    num = 1;
                    break;
                case Value.TWO:
                    num = 2;
                    break;
                case Value.THREE:
                    num = 3;
                    break;
                case Value.FOUR:
                    num = 4;
                    break;
                case Value.FIVE:
                    num = 5;
                    break;
                case Value.SIX:
                    num = 6;
                    break;
                case Value.SEVEN:
                    num = 7;
                    break;
                case Value.EIGHT:
                    num = 8;
                    break;
                case Value.NINE:
                    num = 9;
                    break;
                case Value.TEN:
                    num = 10;
                    break;
                case Value.JACK:
                    num = 10;
                    break;
                case Value.QUEEN:
                    num = 10;
                    break;
                case Value.KING:
                    num = 10;
                    break;
            }

            return num;
        }

        public override string ToString()
        {
            return ((int)suit) + "," + ((int)val);
        }        
    }
}
