using CSharpInteropService;
using NUnit.Framework;
using System;

namespace TestCSharpInteropService {
    partial class Test_Exceptions {
        private static Chest _chest = new Chest();

        [Test]
        [TestCase(false, Use.Null, Use.Null, Methods.Null, "dllFile")]
        [TestCase(false, Use.Correct, Use.Null, Methods.Null, "className")]
        [TestCase(false, Use.Correct, Use.Correct, Methods.Null, "methodName")]
        [TestCase(true, Use.Null, Use.Null, Methods.Null, "dllFile")]
        [TestCase(true, Use.Correct, Use.Null, Methods.Null, "className")]
        [TestCase(true, Use.Correct, Use.Correct, Methods.Null, "methodName")]
        public void MethodWithReturnsThrowArgumentNullException(bool useArguments, Use useDll, Use useClass, Methods useMethod, string ExceptionParameterName) {
            LibraryInvoke invoker = new LibraryInvoke();
            string dllFile = GetDllFile(useDll);
            string className = GetClassName(useClass);
            string MethodName = GetMethodName(useMethod);
            TestDelegate @delegate = GetDelegate(useArguments, invoker, dllFile, className, MethodName);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(@delegate);

            Assert.AreEqual(ExceptionParameterName, ex.ParamName);
        }

        [Test]
        [TestCase(false, Use.Incorrect, Use.Incorrect, Methods.Incorrect, "dllFile")]
        [TestCase(false, Use.Correct, Use.Incorrect, Methods.Incorrect, "className")]
        [TestCase(false, Use.Correct, Use.Correct, Methods.Incorrect, "methodName")]
        [TestCase(true, Use.Incorrect, Use.Incorrect, Methods.Incorrect, "dllFile")]
        [TestCase(true, Use.Correct, Use.Incorrect, Methods.Incorrect, "className")]
        [TestCase(true, Use.Correct, Use.Correct, Methods.Incorrect, "methodName")]
        public void MethodWithReturnsThrowArgumentException(bool useArguments, Use useDll, Use useClass, Methods useMethod, string ExceptionParameterName) {
            LibraryInvoke invoker = new LibraryInvoke();
            string dllFile = GetDllFile(useDll);
            string className = GetClassName(useClass);
            string MethodName = GetMethodName(useMethod);
            TestDelegate @delegate = GetDelegate(useArguments, invoker, dllFile, className, MethodName);

            ArgumentException ex = Assert.Throws<ArgumentException>(@delegate);

            Assert.AreEqual(ExceptionParameterName, ex.ParamName);
        }

        [Test]
        [TestCase(false, Use.Null, Use.Null, Methods.Null, "dllFile")]
        [TestCase(false, Use.Correct, Use.Null, Methods.Null, "className")]
        [TestCase(false, Use.Correct, Use.Correct, Methods.Null, "methodName")]
        [TestCase(true, Use.Null, Use.Null, Methods.Null, "dllFile")]
        [TestCase(true, Use.Correct, Use.Null, Methods.Null, "className")]
        [TestCase(true, Use.Correct, Use.Correct, Methods.Null, "methodName")]
        public void MethodWithoutReturnsThrowArgumentNullException(bool useArguments, Use useDll, Use useClass, Methods useMethod, string ExceptionParameterName) {
            LibraryInvoke invoker = new LibraryInvoke();
            string dllFile = GetDllFile(useDll);
            string className = GetClassName(useClass);
            string MethodName = GetMethodName(useMethod);
            TestDelegate @delegate = GetDelegateOut(useArguments, invoker, dllFile, className, MethodName);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(@delegate);

            Assert.AreEqual(ExceptionParameterName, ex.ParamName);
        }

        [Test]
        [TestCase(false, Use.Incorrect, Use.Incorrect, Methods.Incorrect, "dllFile")]
        [TestCase(false, Use.Correct, Use.Incorrect, Methods.Incorrect, "className")]
        [TestCase(false, Use.Correct, Use.Correct, Methods.Incorrect, "methodName")]
        [TestCase(true, Use.Incorrect, Use.Incorrect, Methods.Incorrect, "dllFile")]
        [TestCase(true, Use.Correct, Use.Incorrect, Methods.Incorrect, "className")]
        [TestCase(true, Use.Correct, Use.Correct, Methods.Incorrect, "methodName")]
        public void MethodWithoutReturnsThrowArgumentException(bool useArguments, Use useDll, Use useClass, Methods useMethod, string ExceptionParameterName) {
            LibraryInvoke invoker = new LibraryInvoke();
            string dllFile = GetDllFile(useDll);
            string className = GetClassName(useClass);
            string MethodName = GetMethodName(useMethod);
            TestDelegate @delegate = GetDelegateOut(useArguments, invoker, dllFile, className, MethodName);

            ArgumentException ex = Assert.Throws<ArgumentException>(@delegate);

            Assert.AreEqual(ExceptionParameterName, ex.ParamName);
        }

        private static string GetDllFile(Use useDll) {
            switch (useDll) {
                case Use.Null:
                    return null;
                case Use.Empty:
                    return "";
                case Use.Incorrect:
                    return "IncorrectFileName";
                case Use.Correct:
                    return _chest.dllFile;
                default:
                    throw new ArgumentException("Недопустимое значение перечисления.");
            }
        }

        private static string GetClassName(Use useClass) {
            switch (useClass) {
                case Use.Null:
                    return null;
                case Use.Empty:
                    return "";
                case Use.Incorrect:
                    return "IncorrectClassName";
                case Use.Correct:
                    return _chest.className;
                default:
                    throw new ArgumentException("Недопустимое значение перечисления.");
            }
        }

        private static string GetMethodName(Methods useMethod) {
            switch (useMethod) {
                case Methods.Null:
                    return null;
                case Methods.Empty:
                    return "";
                case Methods.Incorrect:
                    return "IncorrectMethodName";
                case Methods.InputVoidReturnVoid:
                    return Chest.InputVoidReturnVoid;
                default:
                    throw new ArgumentException("Недопустимое значение перечисления.");
            }
        }

        private static TestDelegate GetDelegate(bool useArguments, LibraryInvoke invoker, string dllFile, string className, string MethodName) {
            if (useArguments)
                return new TestDelegate(() => invoker.GenericInvoke(dllFile, className, MethodName, null));
            return new TestDelegate(() => invoker.GenericInvoke(dllFile, className, MethodName));
        }

        private static TestDelegate GetDelegateOut(bool useArguments, LibraryInvoke invoker, string dllFile, string className, string MethodName) {
            if (useArguments)
                return new TestDelegate(() => invoker.GenericInvokeSub(dllFile, className, MethodName, null));
            return new TestDelegate(() => invoker.GenericInvokeSub(dllFile, className, MethodName));
        }
    }
}
