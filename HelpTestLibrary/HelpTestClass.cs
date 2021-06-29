namespace HelpTestLibrary {
    public class HelpTestClass {
        public object[] InputIntReturnArray(int first, int second) =>  new object[] { first, second };
        public object[] InputStringReturnArray(string first, string second) =>  new object[] { first, second };
        public object[] InputDoubleReturnArray(double first, double second) =>  new object[] { first, second };
        public object[] InputObjectReturnArray(object first, object second) =>  new object[] { first, second };
        public object[] InputVoidReturnArray() => new object[] { "first", "second" };

        /*public void InputInt(int first, int second) { }
        public void InputString(string first, string second) { }
        public void InputDouble(double first, double second) { }
        public void InputObject(object first, object second) { }
        public void InputVoid() { } /* */
    }
}
