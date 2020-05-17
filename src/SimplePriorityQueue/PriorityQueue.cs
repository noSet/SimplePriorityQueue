using System;
using System.Collections.Generic;

namespace SimplePriorityQueue
{
    public class PriorityQueue<T>
    {
        private readonly T[] _arr;
        private readonly int _maxCapacity;
        private readonly IComparer<T> _comparer;

        /// <summary>
        /// 当前指针（从1开始计数）
        /// </summary>
        private int _count;

        public int Count => _count;

        public PriorityQueue(int maxCapacity)
            : this(maxCapacity, default)
        {
        }

        public PriorityQueue(int maxCapacity, IComparer<T> comparable)
        {
            _arr = new T[maxCapacity + 1];
            _maxCapacity = maxCapacity;
            _comparer = comparable ?? Comparer<T>.Default;
        }

        public void Enqueue(T item)
        {
            if (_count >= _maxCapacity)
            {
                // 超过堆大小了，不能再插入元素
                throw new InvalidOperationException();
            }

            _count++;

            // 先将元素插入到队尾中
            _arr[_count] = item;

            int i = _count;

            // 下面的元素小于上面的元素
            while (i / 2 > 0 && _comparer.Compare(_arr[i], _arr[i / 2]) < 0)
            {
                Swap(_arr, i, i / 2);
                i /= 2;
            }
        }

        private void Swap(T[] arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public T Dequeue()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }

            T item = _arr[1];

            // 最后一个元素和第一个元素交换位置
            _arr[1] = _arr[_count];

            // 堆化
            Heapify(1, --_count);

            return item;
        }

        private void Heapify(int index, int count)
        {
            while (true)
            {
                int maxValueIndex = index;
                if (2 * index <= count && _comparer.Compare(_arr[index], _arr[2 * index]) > 0)
                {
                    // 左节点比其父节点大
                    maxValueIndex = 2 * index;
                }

                if (2 * index + 1 <= count && _comparer.Compare(_arr[maxValueIndex], _arr[2 * index + 1]) > 0)
                {
                    // 右节点比左节点或父节点大
                    maxValueIndex = 2 * index + 1;
                }

                if (maxValueIndex == index)
                {
                    // 说明当前节点值为最大值，无需再往下迭代了
                    break;
                }

                Swap(_arr, index, maxValueIndex);
                index = maxValueIndex;
            }
        }

        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }

            return _arr[1];
        }

        public void Clear()
        {
            _count = 0;
        }
    }
}
