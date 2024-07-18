using System.ServiceModel;
using System;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new MyCallback());
            Proxy.ChatServiceClient server = new Proxy.ChatServiceClient(context);

            Console.WriteLine("Enter Username");
            string username = Console.ReadLine();   
            server.Join(username);

            Console.WriteLine();
            Console.WriteLine("Enter Message");
            Console.WriteLine("Press Q to exit");

            string message = Console.ReadLine();
            while(message != "Q")
            {
                if (!string.IsNullOrEmpty(message))
                {
                    server.SendMessage(message);
                }

                 message = Console.ReadLine();
            }
        }
    }
}
