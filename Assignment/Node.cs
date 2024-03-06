using System;
using System.Collections;
using System.Collections.Generic;

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
         Node<T> current = this;

         while (current.Next != this)
         {
             yield return current.Data;
             current = current.Next;
         }
     }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
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
        while (i < max)
        {
            curr = curr.Next;
            myList.Append(curr.Data);
            i++;
        }

        IEnumerable<T> list = myList;

        return list;
    }
}