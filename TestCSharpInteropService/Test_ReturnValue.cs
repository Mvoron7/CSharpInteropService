using CSharpInteropService;
using NUnit.Framework;

namespace TestCSharpInteropService {
    public class Test_ReturnValue {
        private static Chest _chest = new Chest();

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

            invoker.GenericInvoke(_chest.dllFile, _chest.className, Chest.InputVoidReturnArray);
        }

        [Test]
        public void CalledMethodWithoutParametersReturnAnswer() {
            LibraryInvoke invoker = new LibraryInvoke();

            object[] answer = invoker.GenericInvoke(_chest.dllFile, _chest.className, Chest.InputVoidReturnArray);

            Assert.AreEqual(Chest.StringFirst, answer[0]);
            Assert.AreEqual(Chest.StringSecond, answer[1]);
        }

        [Test]
        public void CalledMethodWithoutParametersReturnCorrectTypeAnswer() {
            LibraryInvoke invoker = new LibraryInvoke();

            object[] answer = invoker.GenericInvoke(_chest.dllFile, _chest.className, Chest.InputVoidReturnArray);

            Assert.AreEqual("".GetType(), answer[0].GetType());
            Assert.AreEqual("".GetType(), answer[1].GetType());
        }
        #endregion

        #region WithParameters
        [Test]
        [TestCase(Chest.InputIntReturnArray, Chest.IntFirst, Chest.IntSecond)]
        [TestCase(Chest.InputStringReturnArray, Chest.StringFirst, Chest.StringSecond)]
        [TestCase(Chest.InputDoubleReturnArray, Chest.DoubleFirst, Chest.DoubleSecond)]
        [TestCase(Chest.InputObjectReturnArray, Chest.StringFirst, Chest.DoubleSecond)]
        public void CallMethodWithParameters(string method, object first, object second) {
            LibraryInvoke invoker = new LibraryInvoke();
            object[] parameters = new object[] { first, second };

            invoker.GenericInvoke(_chest.dllFile, _chest.className, method, parameters);
        }

        [Test]
        [TestCase(Chest.InputIntReturnArray, Chest.IntFirst, Chest.IntSecond)]
        [TestCase(Chest.InputStringReturnArray, Chest.StringFirst, Chest.StringSecond)]
        [TestCase(Chest.InputDoubleReturnArray, Chest.DoubleFirst, Chest.DoubleSecond)]
        [TestCase(Chest.InputObjectReturnArray, Chest.StringFirst, Chest.DoubleSecond)]
        public void CalledMethodWithParametersReturnAnswer(string method, object first, object second) {
            LibraryInvoke invoker = new LibraryInvoke();
            object[] parameters = new object[] { first, second };

            object[] answer = invoker.GenericInvoke(_chest.dllFile, _chest.className, method, parameters);

            Assert.AreEqual(first, answer[0]);
            Assert.AreEqual(second, answer[1]);
        }

        [Test]
        [TestCase(Chest.InputIntReturnArray, Chest.IntFirst, Chest.IntSecond)]
        [TestCase(Chest.InputStringReturnArray, Chest.StringFirst, Chest.StringSecond)]
        [TestCase(Chest.InputDoubleReturnArray, Chest.DoubleFirst, Chest.DoubleSecond)]
        [TestCase(Chest.InputObjectReturnArray, Chest.StringFirst, Chest.DoubleSecond)]
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
