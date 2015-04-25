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
        private int curIndex;
        private T item;


        public MyListEnumerator(MyList<T> items)
        {
            this.items = items;
            this.curIndex = -1;
            item = default(T);

        }

        public bool MoveNext()
        {
            if (++curIndex >= items.Count)
            {
                return false;
            }
            else
            {
                item = items[curIndex];
            }
            return true;
        }

        public void Reset() { curIndex = -1; }

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
