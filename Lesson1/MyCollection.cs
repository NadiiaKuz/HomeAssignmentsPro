using System.Collections;

namespace Lesson1
{
    internal class MyCollection : IList<uint>
    {
        private uint[] _myArray;
        private int count;

        public int Length { get => _myArray.Length; }

        public MyCollection()
        {
            _myArray = new uint[10];
            count = 0;
        }

        public uint this[int index]
        {
            get => _myArray[index];
            set => _myArray[index] = value;
        }

        public int Count =>
            count;

        public bool IsReadOnly => false;

        public void Add(uint item)
        {
            if (count < _myArray.Length)
            {
                _myArray[count] = item;
                count++;
            }

            int middle = _myArray.Length / 2 + _myArray.Length % 2;

            if (count == middle)
            {
                var newArr = new uint[_myArray.Length * 2];
                Array.Copy(_myArray, newArr, _myArray.Length);
                _myArray = newArr;
            }
        }

        public void Clear() =>
            count = 0;

        public bool Contains(uint item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_myArray[i] == item)
                    return true;
            }
            return false;
        }

        public void CopyTo(uint[] array, int arrayIndex)
        {
            int j = arrayIndex;
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_myArray[i], j);
                j++;
            }
        }

        public IEnumerator<uint> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _myArray[i];
            }
        }

        public int IndexOf(uint item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_myArray[i] == item)
                    return i;
            }
            return -1;
        }

        public void Insert(int index, uint item)
        {
            if ((count + 1 <= _myArray.Length) && (index < Count) && (index >= 0))
            {
                count++;

                for (int i = Count - 1; i > index; i--)
                {
                    _myArray[i] = _myArray[i - 1];
                }
                _myArray[index] = item;
            }
        }

        public bool Remove(uint item)
        {
            RemoveAt(IndexOf(item));
            return !Contains(item);
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                    _myArray[i] = _myArray[i + 1];

                count--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}
