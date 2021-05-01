using circularLinkedList;
using System;
using Xunit;

namespace CircularLinkedList.Test
{
    public class CircularLinkedListTest
    {
        [Fact]
        public void AddFirstWorks()
        {
            List<int> list = new List<int>();

            list.AddFirst(42);

            Assert.Equal(1, list.count);
            Assert.NotNull(list.Head);
            Assert.NotNull(list.Tail);
            Assert.Equal(42, list.Head.Value);
        }
        [Fact]
        public void AddLastWorks()
        {
            List<int> list = new List<int>();

            list.AddLast(42);

            Assert.Equal(1, list.count);
            Assert.NotNull(list.Head);
            Assert.NotNull(list.Tail);
            Assert.Equal(42, list.Head.Value);
        }
        [Fact]
        public void AddBeforeWorks()
        {
            List<int> list = new List<int>();

            list.AddFirst(42);
            list.AddBefore(1, 4);

            Assert.Equal(2, list.count);
            Assert.NotNull(list.Head);
            Assert.NotNull(list.Tail);
            Assert.Equal(4, list.Head.Next.Value);
        }
        [Fact]
        public void AddAfterWorks()
        {
            List<int> list = new List<int>();

            list.AddFirst(42);
            list.AddAfter(1, 4);

            Assert.Equal(2, list.count);
            Assert.NotNull(list.Head);
            Assert.NotNull(list.Tail);

            Assert.Equal(42, list.Head.Value);
            Assert.Equal(4, list.Tail.Value);
        }

        [Fact]
        public void RemoveFirstWorks()
        {
            List<int> list = new List<int>();

            list.AddFirst(42);

            list.RemoveFirst();

            Assert.Equal(0, list.count);
            Assert.Null(list.Head);
        }

        [Fact]
        public void RemoveLastWorks()
        {
            List<int> list = new List<int>();

            list.AddFirst(42);

            list.RemoveLast();

            Assert.Equal(0, list.count);
            Assert.Null(list.Head);
        }

        [Fact]
        public void RemoveWorks()
        {
            List<int> list = new List<int>();

            list.AddFirst(42);

            list.Remove(42);

            Assert.Equal(0, list.count);
            Assert.Null(list.Head);
            Assert.Null(list.Tail);
        }

        [Fact]
        public void IsEmptyWorks()
        {
            List<int> list = new List<int>();
            Assert.Equal(0, list.count);
            bool thing = list.IsEmpty();
            Assert.True(thing == true);
        }
    }
}
