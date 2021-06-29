using CSharpInteropService;
using NUnit.Framework;

namespace TestCSharpInteropService {
    public class TestLibraryInvoke {
        private Chest _chest;

        [SetUp]
        public void Setup() {
            _chest = new Chest();
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

            invoker.GenericInvoke(_chest.dllFile, _chest.className, "InputVoidReturnArray");
        }

        [Test]
        public void CalledMethodWithoutParametersReturnAnswer() {
            LibraryInvoke invoker = new LibraryInvoke();

            object[] answer = invoker.GenericInvoke(_chest.dllFile, _chest.className, "InputVoidReturnArray");

            Assert.AreEqual("first", answer[0]);
            Assert.AreEqual("second", answer[1]);
        }

        [Test]
        public void CalledMethodWithoutParametersReturnCorrectTypeAnswer() {
            LibraryInvoke invoker = new LibraryInvoke();

            object[] answer = invoker.GenericInvoke(_chest.dllFile, _chest.className, "InputVoidReturnArray");

            Assert.AreEqual("".GetType(), answer[0].GetType());
            Assert.AreEqual("".GetType(), answer[1].GetType());
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

            invoker.GenericInvoke(_chest.dllFile, _chest.className, method, parameters);
        }

        [Test]
        [TestCase("InputIntReturnArray", 1, 2)]
        [TestCase("InputStringReturnArray", "first", "second")]
        [TestCase("InputDoubleReturnArray", 1.0, 2.0)]
        [TestCase("InputObjectReturnArray", "first", 2.0)]
        public void CalledMethodWithParametersReturnAnswer(string method, object first, object second) {
            LibraryInvoke invoker = new LibraryInvoke();
            object[] parameters = new object[] { first, second };

            object[] answer = invoker.GenericInvoke(_chest.dllFile, _chest.className, method, parameters);

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

            object[] answer = invoker.GenericInvoke(_chest.dllFile, _chest.className, method, parameters);

            Assert.AreEqual(first.GetType(), answer[0].GetType());
            Assert.AreEqual(second.GetType(), answer[1].GetType());
        }
        #endregion
    }
}
