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

        public MyList(int size)
        {
            this.size = size;
            this.items = new T[size];
            this.count = 0;
        }

        public MyList():this(20)
        { }

        public void Add(T item)
        {
            if (this.count == size)
            {
                this.size = this.size * 2;
                MyList<T> newList = new MyList<T>(this.size);

                for (int i = 0; i < this.count; i++)
                {
                    newList[i] = this.items[i];
                }

                newList[this.count] = item;
                this.count++;
                this.items = newList.items;
            }
            else
            {
                this.items[count] = item;
                this.count++;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }

        }

        public int Size
        {
            get
            {
                return this.size;
            }

        }

        public bool CheckIndexIsInRange(int min, int max, int index)
        {
            if (index > min || index <= max)
                return true;
            else
                return false;
        }

        public T this[int index]
        {
            get
            {
                if (!CheckIndexIsInRange(0, this.count, index))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return this.items[index];
                }
            }

            set
            {
                if (!CheckIndexIsInRange(0, this.count, index))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.items[index] = value;
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
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (!CheckIndexIsInRange(0, this.count, index))
            {
                throw new ArgumentOutOfRangeException();
            }

            else
            {
                for (int i = index + 1; i < this.count; i++)
                {
                    this.items[i - 1] = this.items[i];
                }

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
            {
                if (match(this.items[i]))
                {
                    newList.Add(this.items[i]);
                }
            }

            return newList;
        }
    }
}
