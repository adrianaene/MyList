using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MyList
{
    public class MyListEnumerator<T> : IEnumerator<T>
    {
        private MyList<T> items;
        private int currentIndex;
        private T item;


        public MyListEnumerator(MyList<T> items)
        {
            this.items = items;
            this.currentIndex = -1;
            item = default(T);
        }

        public bool MoveNext()
        {
            currentIndex++;

            if (currentIndex >= items.Count)
            {
                return false;
            }

            else
            {
                item = items[currentIndex];
            }

            return true;
        }

        public void Reset() { currentIndex = -1; }

        void IDisposable.Dispose() { }

        public T Current
        {
            get { return item; }
        }


        object System.Collections.IEnumerator.Current
        {
            get { return this.Current; }
        }

    }
}
