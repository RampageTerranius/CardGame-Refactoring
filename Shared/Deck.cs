using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Deck
    {
        public LinkedList<Card> CardDeck;
        public LinkedList<Card> DrawnCards;

        public Deck()
        {
            ResetDeck();
        }

        public void ResetDeck()
        {
            CardDeck = new LinkedList<Card>();
            DrawnCards = new LinkedList<Card>();
        }

        public void CreateDeck()
        {
            ResetDeck();

            for (int i = 0; i < 4; i++)
                for (int n = 0; n < 13; n++)
                    CardDeck.AddValue(new Card((Suit)i, (Value)n));
        }

        public void Shuffle()
        {
            Shuffle<Card> shuffle = new Shuffle<Card>(CardDeck);
        }

        public void Sort()
        {
            Sort sort = new Sort(CardDeck);
        }

        public Card Draw()
        {
            Card Temp = CardDeck.GetValueAt(CardDeck.GetLength());
            CardDeck.RemoveValueAt(CardDeck.GetLength() - 1);
            DrawnCards.AddValue(Temp);

            return Temp;
        }

        public void PrintDeck()
        {
            Console.WriteLine("Deck Cards:");
            CardDeck.PrintValues(true);
            Console.WriteLine();
        }

        public void PrintDrawn()
        {
            Console.WriteLine("Drawn Cards:");
            DrawnCards.PrintValues(true);
            Console.WriteLine();
        }
    }
    class Shuffle<T>
    {
        Random r = new Random();

        public Shuffle(LinkedList<T> Data)
        {
            for (int i = Data.GetLength() - 1; i > 0; i--)
            {
                int n = r.Next(0, i);

                T Temp = Data.GetValueAt(n);
                Data.ModifyValueAt(n, Data.GetValueAt(i));
                Data.ModifyValueAt(i, Temp);
            }
        }
    }

    class Sort
    {
        public Sort(LinkedList<Card> Data)
        {
            Sorter(Data);
        }

        private void Sorter(LinkedList<Card> Data)
        {
            bool lLoop = true;
            while (lLoop)
            {
                lLoop = false;
                for (int i = 0; i < Data.GetLength() - 1; i++)
                {
                    if (Data.GetValueAt(i).Suit > Data.GetValueAt(i + 1).Suit)
                    {
                        Card Temp = Data.GetValueAt(i);
                        Data.ModifyValueAt(i, Data.GetValueAt(i + 1));
                        Data.ModifyValueAt(i + 1, Temp);
                        lLoop = true;
                        break;
                    }
                    else
                    if (Data.GetValueAt(i).Suit == Data.GetValueAt(i + 1).Suit)
                        if (Data.GetValueAt(i).Value > Data.GetValueAt(i + 1).Value)
                        {
                            Card Temp = Data.GetValueAt(i);
                            Data.ModifyValueAt(i, Data.GetValueAt(i + 1));
                            Data.ModifyValueAt(i + 1, Temp);
                            lLoop = true;
                            break;
                        }
                }
            }
        }
    }
}

