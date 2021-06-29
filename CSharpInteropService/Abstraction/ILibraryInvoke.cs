using System;
using System.Runtime.InteropServices;

namespace CSharpInteropService {
    [ComVisible(true), Guid(LibraryInvoke.InterfaceId)]
    public interface ILibraryInvoke
    {
        [DispId(1)]
        object[] GenericInvoke(string dllFile, string className, string methodName, object[] parameters);

        [DispId(2)]
        object[] GenericInvoke(string dllFile, string className, string methodName);

        [DispId(3)]
        void GenericInvokeSub(string dllFile, string className, string methodName, object[] parameters);
        
        [DispId(3)]
        void GenericInvokeSub(string dllFile, string className, string methodName);
    }
}
