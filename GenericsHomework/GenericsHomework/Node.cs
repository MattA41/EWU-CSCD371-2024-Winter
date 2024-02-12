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
            // I think having the check has made it so that next cannot 
            ArgumentNullException.ThrowIfNull(next);
            Next = next;
        }

        public override string ToString()
        {
            Node<T> dummy = new(this.Value)
            {
                Next = this
            };
            string ret = "";
            // goes through linked list starting at node called
            while (dummy.Next != (dummy.Next).Next)
            {
                if (dummy.Next.Value != null)
                {

                    ret += dummy.Next.Value.ToString();
                }
                dummy.Next = dummy.Next.Next;

            }
            
            return ret;
        }
        public void Append(T value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (Exists(value))
            {
                return;
            }
            Node<T> dummy = new(value)
            {
                Next = this
            };
            while (dummy.Next != (dummy.Next).Next)
            {
                dummy.Next = dummy.Next.Next;
            }
            dummy.Next.Next = dummy;
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
            ArgumentNullException.ThrowIfNull(value);
            Node<T> dummy = new(value)
            {
                Next = this
            };
            while (dummy.Next != (dummy.Next).Next)
            {   if (dummy.Next.Value != null)
                {
                    if (dummy.Next.Value.Equals(value))
                    {
                        return true;
                    }
                }
                dummy.Next = dummy.Next.Next;
            
            }
            return false;
        }
    }

}
