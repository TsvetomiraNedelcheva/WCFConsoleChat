using System;

namespace Client
{
    public class MyCallback : Proxy.IChatServiceCallback
    {
        public void ReceiveMessage(string user, string message)
        {
            Console.WriteLine("{0}:{1}", user, message);
        }
    }
}
