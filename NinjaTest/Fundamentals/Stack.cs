using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaTest.Fundamentals
{
    public class Stack<T>
    {
        private readonly List<T> list = new List<T>();

        public int Count => list.Count();

        public void Push(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            
            list.Add(obj);
        }

        public T Pop()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var result = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);

            return result;
        }

        public T Peek()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return list[list.Count - 1];
        }

    }
}
