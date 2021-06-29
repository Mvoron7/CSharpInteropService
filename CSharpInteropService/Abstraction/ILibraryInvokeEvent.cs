using System;
using System.Runtime.InteropServices;

namespace CSharpInteropService {
    [ComVisible(true), Guid(LibraryInvoke.EventsId), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ILibraryInvokeEvent
    {
        [DispId(1)]
        void MessageEvent(string message);
    }
}
