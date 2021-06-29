using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace CSharpInteropService {
    [ComVisible(true), Guid(LibraryInvoke.ClassId)]
    [ComSourceInterfaces("CSharpInteropService.ILibraryInvokeEvent")]
    [ComClass(LibraryInvoke.ClassId, LibraryInvoke.InterfaceId, LibraryInvoke.EventsId)]
    public class LibraryInvoke : ILibraryInvoke
    {
        public const string ClassId = "3D853E7B-01DA-4944-8E65-5E36B501E889";
        public const string InterfaceId = "CB344AD3-88B2-47D8-86F1-20EEFAF6BAE8";
        public const string EventsId = "5E16F11C-2E1D-4B35-B190-E752B283260A";

        public delegate void MessageHandler(string message);
        public event MessageHandler MessageEvent;

        public object[] GenericInvoke(string dllFile, string className, string methodName, object[] parameters)
        {
            Assembly dll = Assembly.LoadFrom(dllFile);

            Type classType = dll.GetType(className);
            object classInstance = Activator.CreateInstance(classType);
            MethodInfo classMethod = classType.GetMethod(methodName);

            EventInfo eventMessageEvent = classType.GetEvent("MessageEvent", BindingFlags.NonPublic | BindingFlags.Static);

            if (eventMessageEvent != null) {
                Delegate del = GetDelegate(eventMessageEvent);

                MethodInfo addHandler = eventMessageEvent.GetAddMethod(true);
                Object[] addHandlerArgs = { del };
                addHandler.Invoke(classInstance, addHandlerArgs);
            }

            return (object[])classMethod.Invoke(classInstance, parameters);
        }

        private Delegate GetDelegate(EventInfo eventMessageEvent) {
            Type typeMessageEvent = eventMessageEvent.EventHandlerType;
            MethodInfo handler = typeof(LibraryInvoke).GetMethod("OnMessageEvent", BindingFlags.NonPublic | BindingFlags.Instance);
            return Delegate.CreateDelegate(typeMessageEvent, this, handler);
        }

        public object[] GenericInvoke(string dllFile, string className, string methodName)
        {
            return GenericInvoke(dllFile, className, methodName, null);
        }

        public void GenericInvokeSub(string dllFile, string className, string methodName, object[] parameters) {
            GenericInvoke(dllFile, className, methodName, parameters);
        }

        public void GenericInvokeSub(string dllFile, string className, string methodName) {
            GenericInvoke(dllFile, className, methodName, null);
        }

        private void OnMessageEvent(string message)
        {
            MessageEvent?.Invoke(message);
        }
    }
}
