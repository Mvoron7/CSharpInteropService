using CSharpInteropService;
using NUnit.Framework;
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

        public string GetDllFile(ParameterKinds useDll) {
            switch (useDll) {
                case ParameterKinds.Null:
                    return null;
                case ParameterKinds.Empty:
                    return "";
                case ParameterKinds.Incorrect:
                    return "IncorrectFileName";
                case ParameterKinds.Correct:
                    return dllFile;
                default:
                    throw new ArgumentException("Недопустимое значение перечисления.");
            }
        }

        public string GetClassName(ParameterKinds useClass) {
            switch (useClass) {
                case ParameterKinds.Null:
                    return null;
                case ParameterKinds.Empty:
                    return "";
                case ParameterKinds.Incorrect:
                    return "IncorrectClassName";
                case ParameterKinds.Correct:
                    return className;
                default:
                    throw new ArgumentException("Недопустимое значение перечисления.");
            }
        }

        public string GetMethodName(MethodsKinds useMethod) {
            switch (useMethod) {
                case MethodsKinds.Null:
                    return null;
                case MethodsKinds.Empty:
                    return "";
                case MethodsKinds.Incorrect:
                    return "IncorrectMethodName";
                case MethodsKinds.DefaultCorrect:
                    return InputVoidReturnVoid;
                default:
                    throw new ArgumentException("Недопустимое значение перечисления.");
            }
        }

        public TestDelegate GetDelegate(MethodTypes useArguments, LibraryInvoke invoker, string dllFile, string className, string MethodName) {
            switch (useArguments) {
                case MethodTypes.InputObjectReturnArray:
                    return new TestDelegate(() => invoker.GenericInvoke(dllFile, className, MethodName, null));
                case MethodTypes.InputObjectReturnVoid:
                    return new TestDelegate(() => invoker.GenericInvokeSub(dllFile, className, MethodName, null));
                case MethodTypes.InputVoidReturnArray:
                    return new TestDelegate(() => invoker.GenericInvoke(dllFile, className, MethodName));
                case MethodTypes.InputVoidReturnVoid:
                    return new TestDelegate(() => invoker.GenericInvokeSub(dllFile, className, MethodName));
                default:
                    throw new ArgumentException("Недопустимое значение перечисления.");
            }
        }
    }
}
