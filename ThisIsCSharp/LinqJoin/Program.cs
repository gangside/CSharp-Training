using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqJoin
{
    class Profile
    {
        public string Name { get; set; }
        public int    Height { get; set; }
    }

    class Product
    {
        public string Title { get; set; }
        public string Star { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                new Profile(){Name = "정우성" , Height = 186},
                new Profile(){Name = "김태희" , Height = 158},
                new Profile(){Name = "고현정" , Height = 172},
                new Profile(){Name = "이문세" , Height = 178},
                new Profile(){Name = "하하" , Height = 171},
            };

            Product[] arrProduct =
            {
                new Product(){Title = "비트", Star ="정우성"},
                new Product(){Title = "CF 다수", Star ="김태희"},
                new Product(){Title = "아이리스", Star ="김태희"},
                new Product(){Title = "모래시계", Star ="고현정"},
                new Product(){Title = "솔로예찬", Star ="이문세"},
            };

            //내부조인
            var listProfile = from profile in arrProfile
                              join product in arrProduct on profile.Name equals product.Star
                              select new
                              {
                                  Name = profile.Name,
                                  Product = product.Title,
                                  Height = profile.Height
                              };

            Console.WriteLine("--- 내부 조인 결과 ---");

            foreach (var profile in listProfile)
            {
                Console.WriteLine($"이름 : {profile.Name}, 작품 : {profile.Product}, 키 : {profile.Height}");
            }

            //외부조인
            var listProfile2 = from profile in arrProfile
                               join product in arrProduct on profile.Name equals product.Star into ps
                               from product in ps.DefaultIfEmpty(new Product() { Title = "대표작 없음"})
                               select new
                               {
                                   Name = profile.Name,
                                   Work = product.Title,
                                   Height = profile.Height
                               };

            Console.WriteLine("--- 외부 조인 결과 ---");

            foreach (var profile in listProfile2)
            {
                Console.WriteLine($"이름 : {profile.Name}, 작품 : {profile.Work}, 키 : {profile.Height}");
            }
        }
    }
}
