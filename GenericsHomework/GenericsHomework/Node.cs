using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework
{
    public class Node<T>
    {
        public T Value { get; }
        public Node<T> Next { get; private set; }

        public Node(T value)
        {
            Value = value;
            Next = this; 
        }

        public void SetNext(Node<T> next)
        {
            Next = next;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
        public void Append(T value)
        {
            Node<T> newNode = new Node<T>(value);
            Next = newNode;
        }
    }

}
