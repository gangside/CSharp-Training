using System;
using System.Reflection;

namespace CustomAttribute_HistoryExample {
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    class History : System.Attribute {
        private string programmer;
        public double version;
        public string changes;

        public History(string programmer) {
            this.programmer = programmer;
            version = 1.0f;
            changes = "First release";
        }

        public string GetProgrammer() {
            return programmer;
        }
    }
    
    [History("hojun", changes = "2020-01-12 Created MyClass", version = 0.1)]
    [History("min", changes = "2020-05-01 Added Func() Method", version = 0.2)]
    class MyClass {
        public void Func() {
            Console.WriteLine("Func()");
        }
    }

    class Program {
        static void Main(string[] args) {
            Type type = typeof(MyClass);
            Attribute[] attributes = Attribute.GetCustomAttributes(type);

            Console.WriteLine("MyClass change history...");

            foreach (Attribute a in attributes) {
                History history = a as History;
                if(history != null) {
                    Console.WriteLine($"Ver:{history.version}, Programmer:{history.GetProgrammer()}, changes:{history.changes}");
                }
            }
        }
    }
}
