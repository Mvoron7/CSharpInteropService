using CSharpInteropService;
using NUnit.Framework;
using System;

namespace TestCSharpInteropService {
    class Test_Exceptions {
        private static Chest _chest = new Chest();

        [Test]
        [TestCase(MethodTypes.InputVoidReturnVoid, Use.Null, Use.Null, Methods.Null, "dllFile")]
        [TestCase(MethodTypes.InputVoidReturnVoid, Use.Correct, Use.Null, Methods.Null, "className")]
        [TestCase(MethodTypes.InputVoidReturnVoid, Use.Correct, Use.Correct, Methods.Null, "methodName")]
        [TestCase(MethodTypes.InputVoidReturnArray, Use.Null, Use.Null, Methods.Null, "dllFile")]
        [TestCase(MethodTypes.InputVoidReturnArray, Use.Correct, Use.Null, Methods.Null, "className")]
        [TestCase(MethodTypes.InputVoidReturnArray, Use.Correct, Use.Correct, Methods.Null, "methodName")]
        [TestCase(MethodTypes.InputObjectReturnVoid, Use.Null, Use.Null, Methods.Null, "dllFile")]
        [TestCase(MethodTypes.InputObjectReturnVoid, Use.Correct, Use.Null, Methods.Null, "className")]
        [TestCase(MethodTypes.InputObjectReturnVoid, Use.Correct, Use.Correct, Methods.Null, "methodName")]
        [TestCase(MethodTypes.InputObjectReturnArray, Use.Null, Use.Null, Methods.Null, "dllFile")]
        [TestCase(MethodTypes.InputObjectReturnArray, Use.Correct, Use.Null, Methods.Null, "className")]
        [TestCase(MethodTypes.InputObjectReturnArray, Use.Correct, Use.Correct, Methods.Null, "methodName")]
        public void MethodWithReturnsThrowArgumentNullException(MethodTypes methodType, Use useDll, Use useClass, Methods useMethod, string ExceptionParameterName) {
            LibraryInvoke invoker = new LibraryInvoke();
            string dllFile = _chest.GetDllFile(useDll);
            string className = _chest.GetClassName(useClass);
            string MethodName = _chest.GetMethodName(useMethod);
            TestDelegate @delegate = GetDelegate(methodType, invoker, dllFile, className, MethodName);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(@delegate);

            Assert.AreEqual(ExceptionParameterName, ex.ParamName);
        }

        [Test]
        [TestCase(MethodTypes.InputVoidReturnVoid, Use.Incorrect, Use.Incorrect, Methods.Incorrect, "dllFile")]
        [TestCase(MethodTypes.InputVoidReturnVoid, Use.Correct, Use.Incorrect, Methods.Incorrect, "className")]
        [TestCase(MethodTypes.InputVoidReturnVoid, Use.Correct, Use.Correct, Methods.Incorrect, "methodName")]
        [TestCase(MethodTypes.InputVoidReturnArray, Use.Incorrect, Use.Incorrect, Methods.Incorrect, "dllFile")]
        [TestCase(MethodTypes.InputVoidReturnArray, Use.Correct, Use.Incorrect, Methods.Incorrect, "className")]
        [TestCase(MethodTypes.InputVoidReturnArray, Use.Correct, Use.Correct, Methods.Incorrect, "methodName")]
        [TestCase(MethodTypes.InputObjectReturnVoid, Use.Incorrect, Use.Incorrect, Methods.Incorrect, "dllFile")]
        [TestCase(MethodTypes.InputObjectReturnVoid, Use.Correct, Use.Incorrect, Methods.Incorrect, "className")]
        [TestCase(MethodTypes.InputObjectReturnVoid, Use.Correct, Use.Correct, Methods.Incorrect, "methodName")]
        [TestCase(MethodTypes.InputObjectReturnArray, Use.Incorrect, Use.Incorrect, Methods.Incorrect, "dllFile")]
        [TestCase(MethodTypes.InputObjectReturnArray, Use.Correct, Use.Incorrect, Methods.Incorrect, "className")]
        [TestCase(MethodTypes.InputObjectReturnArray, Use.Correct, Use.Correct, Methods.Incorrect, "methodName")]
        public void MethodWithoutReturnsThrowArgumentException(MethodTypes methodType, Use useDll, Use useClass, Methods useMethod, string ExceptionParameterName) {
            LibraryInvoke invoker = new LibraryInvoke();
            string dllFile = _chest.GetDllFile(useDll);
            string className = _chest.GetClassName(useClass);
            string MethodName = _chest.GetMethodName(useMethod);
            TestDelegate @delegate = GetDelegate(methodType, invoker, dllFile, className, MethodName);

            ArgumentException ex = Assert.Throws<ArgumentException>(@delegate);

            Assert.AreEqual(ExceptionParameterName, ex.ParamName);
        }

        private static TestDelegate GetDelegate(MethodTypes useArguments, LibraryInvoke invoker, string dllFile, string className, string MethodName) {
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
