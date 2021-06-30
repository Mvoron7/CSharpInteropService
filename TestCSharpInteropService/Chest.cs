using System;

namespace TestCSharpInteropService {
    class Chest {
        internal readonly string dllFile;
        internal readonly string className;

        internal const int IntFirst = 1;
        internal const int IntSecond = 2;

        internal const double DoubleFirst = 1.0;
        internal const double DoubleSecond = 2;

        internal const string StringFirst = "first";
        internal const string StringSecond = "second";

        internal const string InputIntReturnArray = "InputIntReturnArray";
        internal const string InputStringReturnArray = "InputStringReturnArray";
        internal const string InputDoubleReturnArray = "InputDoubleReturnArray";
        internal const string InputObjectReturnArray = "InputObjectReturnArray";
        internal const string InputVoidReturnArray = "InputVoidReturnArray";

        internal const string InputIntReturnVoid = "InputIntReturnVoid";
        internal const string InputStringReturnVoid = "InputStringReturnVoid";
        internal const string InputDoubleReturnVoid = "InputDoubleReturnVoid";
        internal const string InputObjectReturnVoid = "InputObjectReturnVoid";
        internal const string InputVoidReturnVoid = "InputVoidReturnVoid";

        public Chest() {
            dllFile = HelpTestLibrary.HelpTestClass.GetAddres();
            className = "HelpTestLibrary.HelpTestClass";
        }

        public string GetDllFile(Use useDll) {
            switch (useDll) {
                case Use.Null:
                    return null;
                case Use.Empty:
                    return "";
                case Use.Incorrect:
                    return "IncorrectFileName";
                case Use.Correct:
                    return dllFile;
                default:
                    throw new ArgumentException("Недопустимое значение перечисления.");
            }
        }

        public string GetClassName(Use useClass) {
            switch (useClass) {
                case Use.Null:
                    return null;
                case Use.Empty:
                    return "";
                case Use.Incorrect:
                    return "IncorrectClassName";
                case Use.Correct:
                    return className;
                default:
                    throw new ArgumentException("Недопустимое значение перечисления.");
            }
        }

        public string GetMethodName(Methods useMethod) {
            switch (useMethod) {
                case Methods.Null:
                    return null;
                case Methods.Empty:
                    return "";
                case Methods.Incorrect:
                    return "IncorrectMethodName";
                case Methods.InputVoidReturnVoid:
                    return InputVoidReturnVoid;
                default:
                    throw new ArgumentException("Недопустимое значение перечисления.");
            }
        }
    }
}
