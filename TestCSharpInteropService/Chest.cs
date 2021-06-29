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
    }
}
