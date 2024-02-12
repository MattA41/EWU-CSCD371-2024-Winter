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
            Assert.True(node1.Next.Equals(node2));
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
            Assert.True(node1.Next.Equals(node1));
        }

        
    }
}
