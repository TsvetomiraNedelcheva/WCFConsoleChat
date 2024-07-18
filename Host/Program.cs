using System;
using System.ServiceModel;

namespace Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ChatService));
            host.Open();
            Console.WriteLine("Service is ready");
            Console.ReadLine();
            host.Close();
        }
    }
}
