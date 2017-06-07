using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class LinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int length = 0;

        //finds out if the given int is at the first or 2nd half of the length and returns true if at first half
        private bool StartAtHead(int index)
        {
            if (index < (int)(length / 2))
                return true;
            else
                return false;
        }

        public void AddValue(T data)
        {
            AddValue(data, null);
        }

        private void AddValue(T data, Node<T> current)
        {
            //first run check
            if (current == null)
                current = head;

            //if we dont have a head we will create it
            if (current == null)
            {
                head = new Node<T>(data);
                length++;
                return;
            }

            //keep moving forwards till we find the tail
            if (current.Next != null)
                AddValue(data, current.Next);
            else
            {
                //add data to the end and set the new tail
                current.Next = new Node<T>(data);
                current.Next.Last = current;
                tail = current.Next;
                length++;
            }
        }

        private bool FindValue(T data, bool searchFrontToBack, Node<T> current)
        {
            //check if we should search from the front or the back first
            if (current == null)
            {
                if (searchFrontToBack)
                    current = head;
                else
                    current = tail;
            }

            //check if we have the data
            if (current.Data.Equals(data))
                return true;

            //move through the list (depending on search direction)
            if (searchFrontToBack)
            {
                if (current.Next != null)
                    return FindValue(data, searchFrontToBack, current.Next);
                else
                    return false;
            }
            else
            {
                if (current.Last != null)
                    return FindValue(data, searchFrontToBack, current.Last);
                else
                    return false;
            }
        }

        public bool FindValue(T Data, bool searchFrontToBack)
        {
            return FindValue(Data, searchFrontToBack, null);
        }

        public bool FindValue(T data)
        {
            return FindValue(data, true);
        }

        private T GetValueAt(int index, Node<T> current)
        {
            if (current == null)
                current = head;

            if (index > 0)
            {
                if (current.Next != null)
                    return GetValueAt(--index, current.Next);
            }

            return current.Data;
        }

        public T GetValueAt(int index)
        {
            return GetValueAt(index, null);
        }

        public int GetLength()
        {
            return length;
        }

        public void PrintValues(bool frontToBack)
        {
            PrintValues(frontToBack, null);
        }

        private void PrintValues(bool frontToBack, Node<T> current)
        {
            if (current == null)
            {
                if (frontToBack)
                {
                    current = head;

                    //lets check if we still have no data
                    if (current == null)
                    {
                        Console.WriteLine("No data");
                        return;
                    }
                }
                else
                {
                    current = tail;

                    //lets check if we still have no data
                    if (current == null)
                    {
                        Console.WriteLine("No data");
                        return;
                    }
                }
            }

            current.ToString();

            if (frontToBack)
            {
                if (current.Next != null)
                    PrintValues(frontToBack, current.Next);
                else
                    return;
            }
            else
            {
                if (current.Last != null)
                    PrintValues(frontToBack, current.Last);
                else
                    return;
            }
        }

        private void Remove(T data, bool removeFirst, bool frontToBack, Node<T> current)
        {
            //if we dont have a head we have no data and as such can not remove
            if (head == null)
                return;

            //first run check
            if (current == null)
            {
                if (frontToBack)
                    current = head;
                else
                    current = tail;
            }

            if (current.Data.Equals(data))
            {
                if (frontToBack)
                {
                    if (current == head)
                        head = head.Next;
                    else
                    {
                        Node<T> last = current.Last;
                        Node<T> next = current.Next;
                        last.Next = next;
                        next.Last = last;
                    }
                }
                else
                {
                    if (current == tail)
                        tail = tail.Last;
                    else
                    {
                        Node<T> last = current.Last;
                        Node<T> next = current.Next;
                        last.Next = next;
                        next.Last = last;
                    }
                }

                length--;
                if (removeFirst)
                    return;
            }
            else
            {
                if (frontToBack)
                {
                    if (current.Next != null)
                        Remove(data, removeFirst, frontToBack, current.Next);
                    else
                        return;
                }

                else
                {
                    if (current.Last != null)
                        Remove(data, removeFirst, frontToBack, current.Last);
                    else
                        return;
                }
            }
        }

        public void RemoveValue(T data)
        {
            Remove(data, false, false, null);
        }

        public void RemoveFirstValue(T data)
        {
            Remove(data, true, false, null);
        }

        private void RemoveValueAt(int index, Node<T> current)
        {
            //check if first run
            if (current == null)
                current = head;

            if (index < length)
            {
                if (index > 0)
                    RemoveValueAt(--index, current.Next);
                else
                {
                    if (current == head)
                    {
                        head = head.Next;
                        length--;
                        return;
                    }
                    else
                    {
                        Node<T> last = current.Last;
                        Node<T> next = current.Next;
                        if (last != null)
                            last.Next = next;
                        if (next != null)
                            next.Last = last;
                        length--;
                        return;
                    }
                }
            }
        }

        public void RemoveValueAt(int index)
        {
            RemoveValueAt(index, null);
        }

        public void ModifyValueAt(int index, T data)
        {
            Node<T> lCurrent = head;
            Node<T> lPrevious = null;
            int lLoop = 0;

            if (index <= length - 1 && index >= 0)
                while (lCurrent != null)
                {
                    if (lLoop == index)
                    {
                        lCurrent.Data = data;
                        return;
                    }

                    lPrevious = lCurrent;
                    lCurrent = lCurrent.Next;
                    lLoop++;
                }
        }

        public T[] ToArray()
        {
            T[] lReturn = new T[length];
            int lLoop = 0;
            Node<T> lCurrent = head;

            while (lLoop < length)
            {
                lReturn[lLoop] = lCurrent.Data;
                lCurrent = lCurrent.Next;
                lLoop++;
            }

            return lReturn;
        }
    }
}