using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    class LinkedList<T>
    {
        Node<T> Head;
        Node<T> Tail;
        int Length = 0;

        //finds out if the given int is at the first or 2nd half of the length and returns true if at first half
        private bool StartAtHead(int Index)
        {
            if (Index < (int)(Length / 2))
                return true;
            else
                return false;
        }

        public void AddValue(T Data, Node<T> Current)
        {
            //first run check
            if (Current == null)
                Current = Head;

            //if we dotn have a head we will create it
            if (Current == null)
            {
                Head = new Node<T>(Data);
                Length++;
                return;
            }

            //keep movign forwards till we find the tail
            if (Current.Next != null)
                AddValue(Data, Current.Next);
            else
            {
                //add data to the end and set the new tail
                Current.Next = new Node<T>(Data);
                Current.Next.Last = Current;
                Tail = Current.Next;
                Length++;
            }
        }

        public void AddValue(T Data)
        {
            AddValue(Data, null);
        }

        private bool FindValue(T Data, bool SearchFrontToBack, Node<T> Current)
        {
            //check if we should search from the front or the back first
            if (Current == null)
            {
                if (SearchFrontToBack)
                    Current = Head;
                else
                    Current = Tail;
            }

            //check if we have the data
            if (Current.Data.Equals(Data))
                return true;

            //move through the list (depending on search direction)
            if (SearchFrontToBack)
            {
                if (Current.Next != null)
                    return FindValue(Data, SearchFrontToBack, Current.Next);
                else
                    return false;
            }
            else
            {
                if (Current.Last != null)
                    return FindValue(Data, SearchFrontToBack, Current.Last);
                else
                    return false;
            }
        }

        public bool FindValue(T Data, bool SearchFrontToBack)
        {
            return FindValue(Data, SearchFrontToBack, null);
        }

        public bool FindValue(T Data)
        {
            return FindValue(Data, true);
        }

        private T GetValueAt(int Index, Node<T> Current)
        {
            if (Current == null)
                Current = Head;

            if (Index > 0)
            {
                if (Current.Next != null)
                    return GetValueAt(--Index, Current.Next);
            }

            return Current.Data;
        }

        public T GetValueAt(int Index)
        {
            return GetValueAt(Index, null);
        }

        public int GetLength()
        {
            return Length;
        }

        public void PrintValues(bool FrontToBack)
        {
            PrintValues(FrontToBack, null);
        }

        private void PrintValues(bool FrontToBack, Node<T> Current)
        {
            if (Current == null)
            {
                if (FrontToBack)
                {
                    Current = Head;

                    //lets check if we still have no data
                    if (Current == null)
                    {
                        Console.WriteLine("No data");
                        return;
                    }
                }
                else
                {
                    Current = Tail;

                    //lets check if we still have no data
                    if (Current == null)
                    {
                        Console.WriteLine("No data");
                        return;
                    }
                }
            }

            Current.ToString();

            if (FrontToBack)
            {
                if (Current.Next != null)
                    PrintValues(FrontToBack, Current.Next);
                else
                    return;
            }
            else
            {
                if (Current.Last != null)
                    PrintValues(FrontToBack, Current.Last);
                else
                    return;
            }
        }

        private void Remove(T Data, bool RemoveFirst, bool FrontToBack, Node<T> Current)
        {
            //if we dont have a head we have no data and as such can not remove
            if (Head == null)
                return;

            //first run check
            if (Current == null)
            {
                if (FrontToBack)
                    Current = Head;
                else
                    Current = Tail;
            }

            if (Current.Data.Equals(Data))
            {
                if (FrontToBack)
                {
                    if (Current == Head)
                        Head = Head.Next;
                    else
                    {
                        Node<T> last = Current.Last;
                        Node<T> next = Current.Next;
                        last.Next = next;
                        next.Last = last;
                    }
                }
                else
                {
                    if (Current == Tail)
                        Tail = Tail.Last;
                    else
                    {
                        Node<T> last = Current.Last;
                        Node<T> next = Current.Next;
                        last.Next = next;
                        next.Last = last;
                    }
                }

                Length--;
                if (RemoveFirst)
                    return;
            }
            else
            {
                if (FrontToBack)
                {
                    if (Current.Next != null)
                        Remove(Data, RemoveFirst, FrontToBack, Current.Next);
                    else
                        return;
                }

                else
                {
                    if (Current.Last != null)
                        Remove(Data, RemoveFirst, FrontToBack, Current.Last);
                    else
                        return;
                }
            }
        }

        public void RemoveValue(T Data)
        {
            Remove(Data, false, false, null);
        }

        public void RemoveFirstValue(T Data)
        {
            Remove(Data, true, false, null);
        }

        private void RemoveValueAt(int Index, Node<T> Current)
        {
            //check if first run
            if (Current == null)
                Current = Head;

            if (Index < Length)
            {
                if (Index > 0)
                    RemoveValueAt(--Index, Current.Next);
                else
                {
                    if (Current == Head)
                    {
                        Head = Head.Next;
                        Length--;
                        return;
                    }
                    else
                    {
                        Node<T> last = Current.Last;
                        Node<T> next = Current.Next;
                        if (last != null)
                            last.Next = next;
                        if (next != null)
                            next.Last = last;
                        Length--;
                        return;
                    }
                }
            }
        }

        public void RemoveValueAt(int Index)
        {
            RemoveValueAt(Index, null);
        }

        public void ModifyValueAt(int Index, T Data)
        {
            Node<T> lCurrent = Head;
            Node<T> lPrevious = null;
            int lLoop = 0;

            if (Index <= Length - 1 && Index >= 0)
                while (lCurrent != null)
                {
                    if (lLoop == Index)
                    {
                        lCurrent.Data = Data;
                        return;
                    }

                    lPrevious = lCurrent;
                    lCurrent = lCurrent.Next;
                    lLoop++;
                }
        }

        public T[] ToArray()
        {
            T[] lReturn = new T[Length];
            int lLoop = 0;
            Node<T> lCurrent = Head;

            while (lLoop < Length)
            {
                lReturn[lLoop] = lCurrent.Data;
                lCurrent = lCurrent.Next;
                lLoop++;
            }

            return lReturn;
        }
    }
}
