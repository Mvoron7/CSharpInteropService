using CSharpInteropService;
using NUnit.Framework;

namespace TestCSharpInteropService {
    public class Test_WithoutReturnValue {
        private static Chest _chest = new Chest();

        [SetUp]
        public void Setup() {
        }

        [Test]
        public void CallMethodWithoutParameters() {
            LibraryInvoke invoker = new LibraryInvoke();

            invoker.GenericInvoke(_chest.dllFile, _chest.className, Chest.InputVoidReturnVoid);
        }

        [Test]
        [TestCase(Chest.InputIntReturnVoid, Chest.IntFirst, Chest.IntSecond)]
        [TestCase(Chest.InputStringReturnVoid, Chest.StringFirst, Chest.StringSecond)]
        [TestCase(Chest.InputDoubleReturnVoid, Chest.DoubleFirst, Chest.DoubleSecond)]
        [TestCase(Chest.InputObjectReturnVoid, Chest.StringFirst, Chest.DoubleSecond)]
        public void CallMethodWithParameters(string method, object first, object second) {
            LibraryInvoke invoker = new LibraryInvoke();
            object[] parameters = new object[] { first, second };

            invoker.GenericInvoke(_chest.dllFile, _chest.className, method, parameters);
        }

        [Test]
        [TestCase(Chest.InputIntReturnVoid, Chest.IntFirst, Chest.IntSecond)]
        [TestCase(Chest.InputStringReturnVoid, Chest.StringFirst, Chest.StringSecond)]
        [TestCase(Chest.InputDoubleReturnVoid, Chest.DoubleFirst, Chest.DoubleSecond)]
        [TestCase(Chest.InputObjectReturnVoid, Chest.StringFirst, Chest.DoubleSecond)]
        public void CalledMethodWithParametersReturnAnswer(string method, object first, object second) {
            LibraryInvoke invoker = new LibraryInvoke();
            object[] parameters = new object[] { first, second };

            object[] answer = invoker.GenericInvoke(_chest.dllFile, _chest.className, method, parameters);

            Assert.IsNull(answer);
        }
    }
}
