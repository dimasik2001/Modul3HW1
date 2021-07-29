using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW1
{
    public class MyList<T> : IReadOnlyList<T>
    {
        private SmartPointer _smartPointer;
        private T[] _array;
        private int _count;
        private int _capacity;

        public MyList()
            : this(4)
        {
        }

        public MyList(int capacity)
        {
            _capacity = capacity;
            _array = new T[_capacity];
            _count = 0;
            _smartPointer = new SmartPointer();
        }

        public MyList(ICollection<T> collection)
        : this(collection.Count)
        {
            AddRange(collection);
        }

        public int Count => _count;
        public T[] Items => GetArray();
        public T this[int index] => _array[_smartPointer.GetCorrect(index)];
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddRange(ICollection<T> collection)
        {
            if (_capacity < _count + collection.Count)
            {
                Resize(_capacity + collection.Count);
            }

            collection.CopyTo(_array, Count);
            _count += collection.Count;
        }

        public void Add(T item)
        {
            if (_capacity <= Count)
            {
                Resize(_capacity * 2);
            }

            _array[_count++] = item;
        }

        public void Remove(T item)
        {
            for (var i = 0; i < _count; i++)
            {
                var t = this[i];
                if (this[i].Equals(item))
                {
                    RemoveAt(i);
                    i--;
                }
            }
        }

        public void RemoveAt(int index)
        {
            var correct = _smartPointer.GetCorrect(index);
            _array[correct] = default(T);
            _smartPointer.Add(correct);
            _count--;
        }

        public T[] GetArray()
        {
            var result = new T[_count];
            for (var i = 0; i < _count; i++)
            {
                result[i] = this[i];
            }

            return result;
        }

        public void Sort(IComparer<T> comparer)
        {
            var result = GetArray();
            Array.Sort(result, comparer);
            ChangeThisTo(new MyList<T>(result));
        }

        public void Sort()
        {
            var result = GetArray();
            Array.Sort(result);
            ChangeThisTo(new MyList<T>(result));
        }

        private void Resize(int capacity)
        {
            var result = new T[capacity];
            _array.CopyTo(result, 0);
            _array = result;
            _capacity = capacity;
        }

        private void ChangeThisTo(MyList<T> newMyList)
        {
            _array = newMyList._array;
            _capacity = newMyList._capacity;
            _count = newMyList._count;
            _smartPointer = newMyList._smartPointer;
        }
    }
}
