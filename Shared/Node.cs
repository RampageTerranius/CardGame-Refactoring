using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    internal class Node<T>
    {
        private T data;
        public T Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public Node<T> Next;
        public Node<T> Last;

        public Node(T Data)
        {
            this.Data = Data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
