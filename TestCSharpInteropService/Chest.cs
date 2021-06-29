using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharpInteropService {
    class Chest {
        internal readonly string dllFile;
        internal readonly string className;
        internal readonly string methodName;

        public Chest() {
            dllFile = HelpTestLibrary.HelpTestClass.GetAddres();
            className = "HelpTestLibrary.HelpTestClass";
            methodName = "";
        }
    }
}
