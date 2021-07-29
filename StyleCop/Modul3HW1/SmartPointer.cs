using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW1
{
    public class SmartPointer
    {
        private int?[] _emptyIndexes;
        private int _count;
        public SmartPointer()
        {
            Clear();
        }

        public void Add(int item)
        {
            if (_count == _emptyIndexes.Length)
            {
                var result = new int?[_emptyIndexes.Length * 2];
                _emptyIndexes.CopyTo(result, 0);
                _emptyIndexes = result;
            }

            _emptyIndexes[_count++] = item;
        }

        public int GetCorrect(int currentIndex)
        {
            foreach (var item in _emptyIndexes)
            {
                if (item != null && item <= currentIndex)
                {
                    currentIndex++;
                }
            }

            return currentIndex;
        }

        public void Clear()
        {
            _emptyIndexes = new int?[4];
            _count = 0;
        }
    }
}
