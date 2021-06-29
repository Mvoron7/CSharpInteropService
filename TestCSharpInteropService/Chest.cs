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

        public Chest() {
            dllFile = HelpTestLibrary.HelpTestClass.GetAddres();
            className = "HelpTestLibrary.HelpTestClass";
        }
    }
}
