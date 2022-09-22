using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;

namespace NetworkStatusNotifier
{
    internal class ConnectionTester
    {
        private bool threadLives = true;
        private int fails = 0;
        private bool disconnected = false;
        private ToastManager toastManager;

        public ConnectionTester()
        {
            toastManager = new ToastManager();
        }

        public void StartPinging()
        {
            new Thread(() =>
            {
                while (threadLives)
                {
                    Thread.Sleep(2000);
                    using (Ping ping = new Ping())
                    {
                        var options = new PingOptions();
                        options.DontFragment = true;
                        try
                        {
                            ping.Send("www.google.com", 2000, createBuffer(), options);
                            ping.Send("www.roblox.com", 2000, createBuffer(), options);
                        }
                        catch (PingException)
                        {
                            fails++;
                            if (fails >= 3)
                            {
                                if (disconnected)
                                {
                                    continue;
                                }
                                disconnected = true;
                                toastManager.ShowDisconnectToast();
                            }
                            continue;
                        }
                    }
                    if (disconnected)
                    {
                        disconnected = false;
                        fails = 0;
                        toastManager.ShowReconnectToast();
                    }
                }
            }).Start();
        }

        public void StopPinging()
        {
            threadLives = false;
        }

        private byte[] createBuffer()
        {
            string data = string.Empty;
            for (int i = 0; i < 17; i++)
            {
                data += "a";
            }
            return Encoding.ASCII.GetBytes(data);
        }
    }
}
