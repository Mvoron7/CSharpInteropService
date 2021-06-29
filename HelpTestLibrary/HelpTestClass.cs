using System.Reflection;

namespace HelpTestLibrary {
    public class HelpTestClass {
        public object[] InputIntReturnArray(int first, int second) =>  new object[] { first, second };
        public object[] InputStringReturnArray(string first, string second) =>  new object[] { first, second };
        public object[] InputDoubleReturnArray(double first, double second) =>  new object[] { first, second };
        public object[] InputObjectReturnArray(object first, object second) =>  new object[] { first, second };
        public object[] InputVoidReturnArray() => new object[] { "first", "second" };

        public void InputIntReturnVoid(int first, int second) { }
        public void InputStringReturnVoid(string first, string second) { }
        public void InputDoubleReturnVoid(double first, double second) { }
        public void InputObjectReturnVoid(object first, object second) { }
        public void InputVoidReturnVoid() { }

        public static string GetAddres() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.Location;
        }
    }
}
