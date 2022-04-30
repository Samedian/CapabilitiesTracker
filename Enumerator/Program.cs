using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Enumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var infiniteEnumerable = new MyInfiniteEnumerable();

            foreach (var item in infiniteEnumerable)
            {
                Console.WriteLine($"I is {item}");
            }
            Console.ReadKey();
        }

        public class MyInfiniteEnumerable : IEnumerable<int>
        {

            private int[] data = new int[] { 4, 5, 6 };

            public IEnumerator GetEnumerator()
            {
                return new MyInfiniteEnumerator(data);
            }

            IEnumerator<int> IEnumerable<int>.GetEnumerator()
            {
                return new MyInfiniteEnumerator(data);
            }
        }


        public class MyInfiniteEnumerator : IEnumerator<int>
        {
            private int[] myValue;
            private int index=-1;
            public MyInfiniteEnumerator(int[] values)
            {
                myValue = values;
            }
            public int Current { get; private set; } = 0;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                index++;

                return index < myValue.Length;
            }


            public void Reset()
            {
                index = 0;
            }
        }
    }
}
