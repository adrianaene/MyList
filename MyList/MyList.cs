using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    public class MyList<T> 
    {
        private int size, count;
        private T[] items;

        public MyList()
        {
            this.size = 20;
            this.items = new T[20];
            this.count = 0;
        }

        public MyList(int size)
        {
            this.size = size;
            this.items = new T[size];
            this.count = 0;
        }

        public void Add(T item)
        {
            this.items[count] = item;
            this.count++;
        }

        public int Count
        {
            get
            {
                return this.count;
            }

        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                    throw new ArgumentOutOfRangeException();
                else
                    return this.items[index];
            }
            set
            {
                if (index < 0 || index > this.count + 1)
                    throw new ArgumentOutOfRangeException();
                else
                {
                    this.items[index] = value;
                    this.count++;
                }
            }
        }

        public void Clear()
        {
            this.count = 0;
            this.items = new T[size];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.count; i++)
                if (this.items[i].Equals(item))
                    return true;
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
                throw new ArgumentOutOfRangeException();
            else
            {
                for (int i = index + 1; i < this.count; i++)
                    this.items[i - 1] = this.items[i];

                this.items[this.count] = default(T);
                this.count--;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator<T>(this);
        }

        public MyList<T> FindAll(Func<T, bool> match)
        {
            MyList<T> newList = new MyList<T>();
            for (int i = 0; i < this.count; i++)
                if (match(this.items[i]))
                    newList.Add(this.items[i]);
            return newList;
        }
    }
}
