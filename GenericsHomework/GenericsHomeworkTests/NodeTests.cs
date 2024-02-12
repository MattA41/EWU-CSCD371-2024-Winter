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
    }
}
