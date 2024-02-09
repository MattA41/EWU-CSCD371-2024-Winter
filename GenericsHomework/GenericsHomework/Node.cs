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
            while(this.Next != null)
            {
                if (this.Value.Equals(value))
                {
                    return;
                }
            }
            Node<T> newNode = new Node<T>(value);
            Next = newNode;
        }
        public void Clear()
        {
            Next = this; 
            //All we need to do to clear the list is reconnect the next to the node itself. 
            //Since the other nodes are disconnected from the head node after this method executes, the remaining nodes are eligible for garbage collection
            //Since there is nothing to reference them, we do not need to worry about what happens to them. They are taken care of in garbage collection
        }
        public bool Exists(T value) 
        {
           if(Next == null) return false;

           if(value.Equals(Value))
            {
                return true;
            }
            else
            {
                return Exists(value);
            }
        }
    }

}
