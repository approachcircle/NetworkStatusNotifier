using Microsoft.Toolkit.Uwp.Notifications;
using System.Drawing;
using System.Reflection;

namespace NetworkStatusNotifier
{
    internal class ToastManager
    {
        private readonly ToastContentBuilder disconnectBuilder;
        private readonly ToastContentBuilder reconnectBuilder;
        public ToastManager()
        {
            disconnectBuilder = new ToastContentBuilder().AddText("Network disconnected.");
            reconnectBuilder = new ToastContentBuilder().AddText("Network reconnected.");
        }

        public void ShowReconnectToast()
        {
            reconnectBuilder.Show();
        }

        public void ShowDisconnectToast()
        {
            disconnectBuilder.Show();
        }
    }
}
