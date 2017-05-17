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
        double cash;

        public Player()
        {
            ClearHand();
        }

        public void ClearHand()
        {
            Hand = new LinkedList<Card>();
        }

        public void Draw(Deck deck)
        {
            if (deck.CardDeck.GetLength() > 0)
                Hand.AddValue(deck.Draw());
            else
                Console.WriteLine("No cards left in deck to draw");
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
