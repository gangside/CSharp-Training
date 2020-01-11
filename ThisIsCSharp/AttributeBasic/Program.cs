using System;

namespace AttributeBasic {
    class MyClass {

        [Obsolete("OldMethod는 폐기됐습니다. NewMethod를 사용하세요")]
        public void OldMethod() {
            Console.WriteLine("i'm old method");
        }

        public void NewMethod() {
            Console.WriteLine("i'm new method");
        }
    }

    class Program {
        static void Main(string[] args) {
            MyClass obj = new MyClass();

            obj.OldMethod();
            obj.NewMethod();
        }
    }
}
