using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSimpleExample
{
    class Profile
    {
        public string Name { get; set; }
        public int    Height { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                new Profile(){Name = "정우성", Height = 186},
                new Profile(){Name = "김태희", Height = 158},
                new Profile(){Name = "고현정", Height = 172},
                new Profile(){Name = "이문세", Height = 178},
                new Profile(){Name = "하하", Height = 171},
            };

            var profiles = from n in arrProfile
                           where n.Height < 175
                           orderby n.Height
                           select new
                           {
                               Name = n.Name,
                               InchHeight = n.Height * 0.393
                           };

            foreach (var profile in profiles)
                Console.WriteLine($"{profile.Name}, {profile.InchHeight}");
        }
    }
}
