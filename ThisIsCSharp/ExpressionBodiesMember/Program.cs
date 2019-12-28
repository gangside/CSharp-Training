using System;
using System.Collections.Generic;

namespace ExpressionBodiesMember
{
    class FriendList
    {
        List<string> list = new List<string>();

        public void Add(string name) => list.Add(name);
        public void Remove(string name) => list.Remove(name);
        public void PrintAll()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public FriendList() => Console.WriteLine("FriendList()");
        ~FriendList() => Console.WriteLine("~FriendList()");

        //public int Capacity => list.Capacity; //읽기 전용
        public int Capacity // 속성
        {
            get => list.Capacity;
            set => list.Capacity = value;
        }

        //public string this[int index] => list[index]; //읽기 전용
        public string this[int index] {
            get => list[index];
            set => list[index] = value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FriendList obj = new FriendList();
            obj.Add("철수");
            obj.Add("영희");
            obj.Add("길동");
            obj.Remove("철수");
            obj.PrintAll();

            Console.WriteLine($"{obj.Capacity}");
            obj.Capacity = 10;
            Console.WriteLine($"{obj.Capacity}");

            Console.WriteLine($"{obj[0]}");
            obj[0] = "둘리";
            obj.PrintAll();
        }
    }
}
