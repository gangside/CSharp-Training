using System;

namespace GenericDelegate {
    delegate int Compare<T>(T a, T b);

    class Program {
        static int AscendCompare<T>(T a, T b) where T : IComparable<T> {
            return a.CompareTo(b);
        }

        static int DescendCompare<T>(T a, T b) where T : IComparable<T> {
            return a.CompareTo(b) * -1; //내림차순으로 바꿔줍니다
        }

        static void BubbleSort<T>(T[] DataSet, Compare<T> Comparer) {
            int i = 0;
            int j = 0;
            T temp;

            for (i = 0; i < DataSet.Length - 1; i++) {
                for (j = 0; j < DataSet.Length - (i + 1); j++) {
                    if(Comparer(DataSet[j], DataSet[j+1]) > 0) {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args) {
            int[] arr = { 3, 7, 4, 2, 10 };

            Console.WriteLine("Sorting ascending...");
            BubbleSort(arr, new Compare<int>(AscendCompare));

            foreach (var item in arr) {
                Console.WriteLine(item);
            }

            string[] strArr = { "abc", "def", "ghi", "jkl", "mno" };

            Console.WriteLine("Sorting descending...");
            BubbleSort(strArr, new Compare<string>(DescendCompare));

            foreach (var item in strArr) {
                Console.WriteLine(item);
            }
        }
    }
}
