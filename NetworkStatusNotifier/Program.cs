using System.Net.NetworkInformation;

namespace NetworkStatusNotifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionTester tester = new ConnectionTester();
            tester.StartPinging();
        }
    }
}