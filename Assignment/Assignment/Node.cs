using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Assignment;

public class Node<T> : IEnumerable<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; private set;}
    public Node(T data)
    {
        Data = data;
        Next = this;
    }

     public IEnumerator<T> GetEnumerator()
    {
       return new NodeEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class NodeEnumerator(Node<T> node) : IEnumerator<T>
    {
        private Node<T> Head => node;

        public object Current => Head;

        private Node<T> CurrentNode
        {
            get => node;
            set => node = value;
        }

        T IEnumerator<T>.Current => (T)Current;
        void IDisposable.Dispose() {}

        public bool MoveNext()
        {
            if ((Node<T>)CurrentNode.Next != Head)
            {
                CurrentNode = CurrentNode.Next;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            CurrentNode = Head;
        }
    }

    public void Append(T data)
    {

        if(Exists(data))
        {
            throw new ArgumentException("The value already exists");
        }

        Node<T> cur = this;

        Node<T> nextNode = new(data)
        {
            Next = cur.Next
        };
        cur.Next = nextNode;
    }

    public override string ToString()
    {
        Node<T> cur = this;
        string outPut = "Linked List: ";
        int count = 0;

        do{
            count++;
            outPut += $"Node {count}: {cur.Data}, ";
            cur = cur.Next;
        }while(cur != this);

        outPut += "}";
        return outPut;
    }

    public bool Exists(T data)
    {

        Node<T> cur = this;

        do
        {
            if (cur.Data!.Equals(data))
            {
                return true;
            }

            cur = cur.Next;

        } while (cur != this);

        return false;
    }

    public void Clear()
    {
        Next = this;
    }

    public IEnumerable<T> ChildItems(int max)
    {
        int i  = 0;
        Node<T> curr = this;
        Node<T> myList = new(curr.Data);
        while (i<max)
        {
            curr = curr.Next;
            myList.Append(curr.Data);
            i++;
        }

        IEnumerable<T> list = myList;

        return list;
    }

}