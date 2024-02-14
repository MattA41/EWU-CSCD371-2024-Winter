using GenericsHomework;
using Xunit;

namespace GenericsHomeworkTests;
public class NodeTests
{
    [Fact]
    public void SetNext_Null()
    {
        Node<String> node1 = new("string");

        Assert.Throws<ArgumentNullException>(() => node1.SetNext(null!));
    }

    [Fact]
    public void SetNext_GoodVal()
    {
        Node<string> node1 = new("String1");
        Node<string> node2 = new("String2");
        node1.SetNext(node2);
        Assert.Equal(node1.Next, node2);
    }
    [Fact]
    public void Clear_DeletesList()
    {
        Node<string> node1 = new("String");
        Node<string> node2 = new("String 2");
        Node<string> node3 = new("String 3");
        node1.SetNext(node2);
        node2.SetNext(node3);
        node1.Clear();
        Assert.Equal(node1, node1.Next);
    }

    [Fact]
    public void Exists_TellsIfInList_Middle()
    {
        Node<string> node1 = new("String");
        Node<string> node2 = new("String 2");
        Node<string> node3 = new("String 3");
        Node<string> node4 = new("String 4");
        node1.SetNext(node2);
        node2.SetNext(node3);
        node3.SetNext(node4);
        node4.SetNext(node1);

        //used Assert.True because exists returns true or false if the item exits
        Assert.True(node1.Exists("String 3"));
    }

    [Fact]
    public void Exists_TellsIfInList_End()
    {
        Node<string> node1 = new("String");
        Node<string> node2 = new("String 2");
        Node<string> node3 = new("String 3");
        Node<string> node4 = new("String 4");
        node1.SetNext(node2);
        node2.SetNext(node3);
        node3.SetNext(node4);
        node4.SetNext(node1);

        //used Assert.True because exists returns true or false if the item exits
        Assert.True(node1.Exists("String 4"));
    }

    [Fact]
    public void Exists_NullVal()
    {
        Node<string> node1 = new("String");
        Node<string> node2 = new("String 2");
        Node<string> node3 = new("String 3");
        node1.SetNext(node2);
        node2.SetNext(node3);
        Assert.Throws<ArgumentNullException>(() => node1.Exists(null!));
    }

    [Fact]
    public void Append_TestIfAddsLast()
    {
        Node<string> node1 = new("String 1");
        Node<string> node2 = new("String 2");
        Node<string> node3 = new("String 3");
        node1.SetNext(node2);
        node2.SetNext(node3);
        node3.SetNext(node1);
        string data = "String4";
        node1.Append(data);

        Assert.Equal(node3.Next.Value, data);
    }
    [Fact]
    public void Append_TestNullValue()
    {
        Node<string> node1 = new("String");
        node1.Append("String 2");
        node1.Append("String 3");
        
        Assert.Throws<ArgumentNullException>(() => node1.Append(null!));

    }

    [Fact]
    public void ToString_TestPrint()
    {
        Node<string> node1 = new("String 1");
        Node<string> node2 = new("String 2");
        Node<string> node3 = new("String 3");
        node1.SetNext(node2);
        node2.SetNext(node3);
        node3.SetNext(node1);
        string test = "String 1 String 2 String 3";
        Assert.Equal(node1.ToString(),test );
    }
}

