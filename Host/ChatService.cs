using System.Collections.Generic;
using System.ServiceModel;

namespace Host
{
    //when we implement service contract interface
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Single, InstanceContextMode =InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        Dictionary<IChatClient, string> users = new Dictionary<IChatClient, string>();
        public void Join(string username)
        {
            IChatClient connection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            users[connection] = username;
        }

        public void SendMessage(string message)
        {
            IChatClient connection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            string user;

            if (!users.TryGetValue(connection, out user)) 
                return;

            foreach (IChatClient key in users.Keys)
            {
                if (key == connection)
                {
                    continue;
                }
                key.ReceiveMessage(user, message);
            }
        }
    }
}
