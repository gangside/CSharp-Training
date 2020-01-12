using System;
using System.Runtime.CompilerServices;

namespace AttributeCallerInfo {

    public static class Trace {
        public static void WriteLine(string message, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0, [CallerMemberName] string member = "") {
            Console.WriteLine($"{file}(Line:{line}) {member}: {message}");
        }
    }

    class Program {
        static void Main(string[] args) {
            Trace.WriteLine("호출자 정보 애트리뷰 테스트!");
        }
    }
}
