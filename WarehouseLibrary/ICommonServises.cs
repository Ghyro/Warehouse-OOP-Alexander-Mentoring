using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public interface ICommonServises
    {
        public static void Sort<T>(T[] list) where T : IComparable<T>
        {
            QuickSortInternal(list, 0, list.Length - 1);
        }
        private static void QuickSortInternal<T>(T[] list, int left, int pivot) where T : IComparable<T>
        {
            if (left >= pivot)
            {
                return;
            }

            int wall = WallInternal(list, left, pivot);

            QuickSortInternal(list, left, wall - 1);
            QuickSortInternal(list, wall + 1, pivot);
        }
        private static int WallInternal<T>(T[] list, int left, int pivot) where T : IComparable<T>
        {
            T wall = list[pivot];
            // stack items smaller than wall from left to pivot
            int swapIndex = left;
            for (int i = left; i < pivot; i++)
            {
                T item = list[i];
                if (item.CompareTo(wall) <= 0)//TO DO how to refactoring, that working with where T:struct
                {
                    list[i] = list[swapIndex];
                    list[swapIndex] = item;

                    swapIndex++;
                }
            }
            // put the wall after all the smaller items
            list[pivot] = list[swapIndex];
            list[swapIndex] = wall;

            return pivot;
        }
    }
}
