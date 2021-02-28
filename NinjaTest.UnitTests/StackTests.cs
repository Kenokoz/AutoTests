using NinjaTest.Fundamentals;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaTest.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> stack;

        [SetUp]
        public void SetUp()
        {
            stack = new Stack<string>();
        }

        [Test]
        public void Push_ArgIsNull_ThrowException()
        {
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArg_AddTheObjToTheStack()
        {
            stack.Push("a");

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowException()
        {
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithAFewObjects_ReturnObjOnTheTop()
        {
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Pop();

            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Pop_StackWithAFewObjects_RemoveObjOnTheTop()
        {
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowException()
        {
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithObjects_ReturnObjOnTheTop()
        {
            stack.Push("a");
            stack.Push("b");

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]
        public void Peek_StackWithObjects_DoesNotRemoveTheObjectOnTheTop()
        {
            stack.Push("a");
            stack.Push("b");

            stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(2));
        }
    }
}
