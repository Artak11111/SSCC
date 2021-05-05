using System;
using System.Windows.Threading;

namespace ControlCenter.Client.Helpers
{
    public static class UIThreadHelper
    {
        public static bool CheckAccess()
        {
            return System.Windows.Application.Current.Dispatcher.CheckAccess();
        }

        public static void AccessUIThread(Action operation)
        {
            if (CheckAccess())
                operation();
            else
                System.Windows.Application.Current.Dispatcher.Invoke(operation, DispatcherPriority.Normal);
        }

        public static T AccessUIThread<T>(Func<T> operation)
        {
            if (CheckAccess())
                return operation();

            return System.Windows.Application.Current.Dispatcher.Invoke(operation, DispatcherPriority.Normal);
        }
    }
}
