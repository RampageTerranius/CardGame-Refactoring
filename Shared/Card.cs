using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//enums for use with card class
public enum eSuit
{
    SPADES,
    CLUBS,
    DIAMONDS,
    HEARTS
}

public enum eValue
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
    class Card
    {
        private eSuit suit;
        private eValue val;

        public eSuit Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        public eValue Value
        {
            get { return val; }
            set { val = value; }
        }


        public Card(eSuit Suit, eValue Value)
        {
            this.Suit = Suit;
            this.Value = Value;

        }

        public override string ToString()
        {
            string convSuit = "";
            string convVal = "";

            switch (suit)
            {
                case eSuit.SPADES:
                    convSuit = "Spades";
                    break;
                case eSuit.CLUBS:
                    convSuit = "Clubs";
                    break;
                case eSuit.DIAMONDS:
                    convSuit = "Diamonds";
                    break;
                case eSuit.HEARTS:
                    convSuit = "Hearts";
                    break;
            }

            switch (Value)
            {
                case eValue.ACE:
                    convVal = "Ace";
                    break;
                case eValue.TWO:
                    convVal = "2";
                    break;
                case eValue.THREE:
                    convVal = "3";
                    break;
                case eValue.FOUR:
                    convVal = "4";
                    break;
                case eValue.FIVE:
                    convVal = "5";
                    break;
                case eValue.SIX:
                    convVal = "6";
                    break;
                case eValue.SEVEN:
                    convVal = "7";
                    break;
                case eValue.EIGHT:
                    convVal = "8";
                    break;
                case eValue.NINE:
                    convVal = "9";
                    break;
                case eValue.TEN:
                    convVal = "10";
                    break;
                case eValue.JACK:
                    convVal = "Jack";
                    break;
                case eValue.QUEEN:
                    convVal = "Queen";
                    break;
                case eValue.KING:
                    convVal = "King";
                    break;
            }

            string write = "Suit: " + convSuit;

            write += " Value: " + convVal;

            Console.WriteLine(write);
            return "";
        }
    }
}
