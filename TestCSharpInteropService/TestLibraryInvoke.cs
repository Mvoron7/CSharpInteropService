using CSharpInteropService;
using NUnit.Framework;

namespace TestCSharpInteropService {
    public class TestLibraryInvoke {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void CreateInstanse() {
            LibraryInvoke invoker = new LibraryInvoke();
            
            Assert.NotNull(invoker);
        }

        #region WithoutParameters
        [Test]
        public void CallMethodWithoutParameters() {
            LibraryInvoke invoker = new LibraryInvoke();

            invoker.GenericInvoke(Chest.dllFile, Chest.className, "InputVoidReturnArray");
        }

        [Test]
        public void CalledMethodWithoutParametersReturnAnswer() {
            LibraryInvoke invoker = new LibraryInvoke();

            var answer = invoker.GenericInvoke(Chest.dllFile, Chest.className, "InputVoidReturnArray");

            Assert.AreEqual("first", answer[0]);
            Assert.AreEqual("second", answer[1]);
        }
        #endregion

        #region WithParameters
        [Test]
        [TestCase("InputIntReturnArray", 1, 2)]
        [TestCase("InputStringReturnArray", "first", "second")]
        [TestCase("InputDoubleReturnArray", 1.0, 2.0)]
        [TestCase("InputObjectReturnArray", "first", 2.0)]
        public void CallMethodWithParameters(string method, object first, object second) {
            LibraryInvoke invoker = new LibraryInvoke();
            object[] parameters = new object[] { first, second };

            invoker.GenericInvoke(Chest.dllFile, Chest.className, method, parameters);
        }

        [Test]
        [TestCase("InputIntReturnArray", 1, 2)]
        [TestCase("InputStringReturnArray", "first", "second")]
        [TestCase("InputDoubleReturnArray", 1.0, 2.0)]
        [TestCase("InputObjectReturnArray", "first", 2.0)]
        public void CalledMethodWithParametersReturnAnswer(string method, object first, object second) {
            LibraryInvoke invoker = new LibraryInvoke();
            object[] parameters = new object[] { first, second };

            var answer = invoker.GenericInvoke(Chest.dllFile, Chest.className, method, parameters);

            Assert.AreEqual(first, answer[0]);
            Assert.AreEqual(second, answer[1]);
        }

        [Test]
        [TestCase("InputIntReturnArray", 1, 2)]
        [TestCase("InputStringReturnArray", "first", "second")]
        [TestCase("InputDoubleReturnArray", 1.0, 2.0)]
        [TestCase("InputObjectReturnArray", "first", 2.0)]
        public void CalledMethodWithParametersReturnCorrectTypeAnswer(string method, object first, object second) {
            LibraryInvoke invoker = new LibraryInvoke();
            object[] parameters = new object[] { first, second };

            var answer = invoker.GenericInvoke(Chest.dllFile, Chest.className, method, parameters);

            Assert.AreEqual(first.GetType(), answer[0].GetType());
            Assert.AreEqual(second.GetType(), answer[1].GetType());
        }
        #endregion
    }
}
