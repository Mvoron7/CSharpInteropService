using CSharpInteropService;
using NUnit.Framework;
using System;

namespace TestCSharpInteropService {
    class Test_Exceptions {
        private static Chest _chest = new Chest();

        [Test]
        [TestCase(MethodTypes.InputVoidReturnVoid, ParameterKinds.Null, ParameterKinds.Null, MethodsKinds.Null, "dllFile")]
        [TestCase(MethodTypes.InputVoidReturnVoid, ParameterKinds.Correct, ParameterKinds.Null, MethodsKinds.Null, "className")]
        [TestCase(MethodTypes.InputVoidReturnVoid, ParameterKinds.Correct, ParameterKinds.Correct, MethodsKinds.Null, "methodName")]
        [TestCase(MethodTypes.InputVoidReturnArray, ParameterKinds.Null, ParameterKinds.Null, MethodsKinds.Null, "dllFile")]
        [TestCase(MethodTypes.InputVoidReturnArray, ParameterKinds.Correct, ParameterKinds.Null, MethodsKinds.Null, "className")]
        [TestCase(MethodTypes.InputVoidReturnArray, ParameterKinds.Correct, ParameterKinds.Correct, MethodsKinds.Null, "methodName")]
        [TestCase(MethodTypes.InputObjectReturnVoid, ParameterKinds.Null, ParameterKinds.Null, MethodsKinds.Null, "dllFile")]
        [TestCase(MethodTypes.InputObjectReturnVoid, ParameterKinds.Correct, ParameterKinds.Null, MethodsKinds.Null, "className")]
        [TestCase(MethodTypes.InputObjectReturnVoid, ParameterKinds.Correct, ParameterKinds.Correct, MethodsKinds.Null, "methodName")]
        [TestCase(MethodTypes.InputObjectReturnArray, ParameterKinds.Null, ParameterKinds.Null, MethodsKinds.Null, "dllFile")]
        [TestCase(MethodTypes.InputObjectReturnArray, ParameterKinds.Correct, ParameterKinds.Null, MethodsKinds.Null, "className")]
        [TestCase(MethodTypes.InputObjectReturnArray, ParameterKinds.Correct, ParameterKinds.Correct, MethodsKinds.Null, "methodName")]
        public void MethodThrowArgumentNullException(MethodTypes methodType, ParameterKinds useDll, ParameterKinds useClass, MethodsKinds useMethod, string ExceptionParameterName) {
            LibraryInvoke invoker = new LibraryInvoke();
            string dllFile = _chest.GetDllFile(useDll);
            string className = _chest.GetClassName(useClass);
            string MethodName = _chest.GetMethodName(useMethod);
            TestDelegate @delegate = _chest.GetDelegate(methodType, invoker, dllFile, className, MethodName);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(@delegate);

            Assert.AreEqual(ExceptionParameterName, ex.ParamName);
        }

        [Test]
        [TestCase(MethodTypes.InputVoidReturnVoid, ParameterKinds.Incorrect, ParameterKinds.Incorrect, MethodsKinds.Incorrect, "dllFile")]
        [TestCase(MethodTypes.InputVoidReturnVoid, ParameterKinds.Correct, ParameterKinds.Incorrect, MethodsKinds.Incorrect, "className")]
        [TestCase(MethodTypes.InputVoidReturnVoid, ParameterKinds.Correct, ParameterKinds.Correct, MethodsKinds.Incorrect, "methodName")]
        [TestCase(MethodTypes.InputVoidReturnArray, ParameterKinds.Incorrect, ParameterKinds.Incorrect, MethodsKinds.Incorrect, "dllFile")]
        [TestCase(MethodTypes.InputVoidReturnArray, ParameterKinds.Correct, ParameterKinds.Incorrect, MethodsKinds.Incorrect, "className")]
        [TestCase(MethodTypes.InputVoidReturnArray, ParameterKinds.Correct, ParameterKinds.Correct, MethodsKinds.Incorrect, "methodName")]
        [TestCase(MethodTypes.InputObjectReturnVoid, ParameterKinds.Incorrect, ParameterKinds.Incorrect, MethodsKinds.Incorrect, "dllFile")]
        [TestCase(MethodTypes.InputObjectReturnVoid, ParameterKinds.Correct, ParameterKinds.Incorrect, MethodsKinds.Incorrect, "className")]
        [TestCase(MethodTypes.InputObjectReturnVoid, ParameterKinds.Correct, ParameterKinds.Correct, MethodsKinds.Incorrect, "methodName")]
        [TestCase(MethodTypes.InputObjectReturnArray, ParameterKinds.Incorrect, ParameterKinds.Incorrect, MethodsKinds.Incorrect, "dllFile")]
        [TestCase(MethodTypes.InputObjectReturnArray, ParameterKinds.Correct, ParameterKinds.Incorrect, MethodsKinds.Incorrect, "className")]
        [TestCase(MethodTypes.InputObjectReturnArray, ParameterKinds.Correct, ParameterKinds.Correct, MethodsKinds.Incorrect, "methodName")]
        public void MethodThrowArgumentException(MethodTypes methodType, ParameterKinds useDll, ParameterKinds useClass, MethodsKinds useMethod, string ExceptionParameterName) {
            LibraryInvoke invoker = new LibraryInvoke();
            string dllFile = _chest.GetDllFile(useDll);
            string className = _chest.GetClassName(useClass);
            string MethodName = _chest.GetMethodName(useMethod);
            TestDelegate @delegate = _chest.GetDelegate(methodType, invoker, dllFile, className, MethodName);

            ArgumentException ex = Assert.Throws<ArgumentException>(@delegate);

            Assert.AreEqual(ExceptionParameterName, ex.ParamName);
        }
    }
}
