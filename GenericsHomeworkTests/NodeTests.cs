using GenericsHomework;
using Xunit;

namespace GenericsHomeworkTests
{
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
            Node<String> node1 = new("String1");
            Node<String> node2 = new("String2");
            node1.SetNext(node2);
            Assert.Equal(node1.Next, node2);
        }
        [Fact]
        public void Clear_DeletesList()
        {
            Node<String> node1 = new("String");
            Node<String> node2 = new("String 2");
            Node<String> node3 = new("String 3");
            node1.SetNext(node2);
            node2.SetNext(node3);
            node1.Clear();
            Assert.Equal(node1, node1.Next);
        }

        [Fact]
        public void Exists_TellsIfInList_Middle()
        {
            Node<String> node1 = new("String");
            Node<String> node2 = new("String 2");
            Node<String> node3 = new("String 3");
            Node<String> node4 = new("String 4");
            node1.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node4);
            
            //used Assert.True because exists returns true or false if the item exits
            Assert.True(node1.Exists("String 3"));
        }

        [Fact]
        public void Exists_TellsIfInList_End()
        {
            Node<String> node1 = new("String");
            Node<String> node2 = new("String 2");
            Node<String> node3 = new("String 3");
            Node<String> node4 = new("String 4");
            node1.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node4);

            //used Assert.True because exists returns true or false if the item exits
            Assert.True(node1.Exists("String 4"));
        }

        [Fact]
        public void Exists_NullVal()
        {
            Node<String> node1 = new("String");
            Node<String> node2 = new("String 2");
            Node<String> node3 = new("String 3");
            node1.SetNext(node2);
            node2.SetNext(node3);
            Assert.Throws<ArgumentNullException>(() => node1.Exists(null!));
        }

        [Fact]
        public void Append_TestIfAddsLast()
        {
            Node<String> node1 = new("String 1");
            Node<String> node2 = new("String 2");
            Node<String> node3 = new("String 3");
            node1.SetNext(node2);
            node2.SetNext(node3);
            string data = "String4";
            node1.Append(data);

            Assert.Equal(node3.Next.Value, data);
        }
        [Fact]
        public void Append_TestNullValue()
        {
            Node<String> node1 = new("String");
            Node<String> node2 = new("String 2");
            Node<String> node3 = new("String 3");
            node1.SetNext(node2);
            node2.SetNext(node3);
            Assert.Throws<ArgumentNullException>(() => node1.Append(null!));

        }
    }
}
