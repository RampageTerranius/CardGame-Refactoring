using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Player
    {
        public LinkedList<Card> Hand;

        public Player()
        {
            ClearHand();
        }

        public void ClearHand()
        {
            Hand = new LinkedList<Card>();
        }

        public Card Draw(Deck deck)
        {
            if (deck.CardDeck.GetLength() > 0)
            {
                Hand.AddValue(deck.Draw());
                return Hand.GetValueAt(Hand.GetLength()-1);
            }                
            else
                Console.WriteLine("No cards left in deck to draw");

            return null;
        }

        public void Draw(Card card)
        {
            Hand.AddValue(card);
        }

        public void Drop(Deck deck)
        {
            if (Hand.GetLength() > 0)
            {
                Card temp = Hand.GetValueAt(Hand.GetLength() - 1);
                Hand.RemoveValueAt(Hand.GetLength() - 1);
                deck.CardDeck.AddValue(temp);
            }
            else
                Console.WriteLine("No cards left in players hand to drop");
        }

        public void PrintHand()
        {
            Console.WriteLine("Players Hand:");
            Hand.PrintValues(true);
            Console.WriteLine();
        }

        public int GetHandValue()
        {
            int val = 0;
            for (int i = 0; i < Hand.GetLength(); i++)
                val += (int)Hand.GetValueAt(i).CardValue();
            return val;
        }

        public void Shuffle()
        {
            Shuffle<Card> shuffle = new Shuffle<Card>(Hand);
        }

        public void Sort()
        {
            Sort sort = new Sort(Hand);
        }
    }
}
