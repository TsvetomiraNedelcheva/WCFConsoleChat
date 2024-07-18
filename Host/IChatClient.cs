using System.ServiceModel;

namespace Host
{
    [ServiceContract] //defines a service contarct in WCF
    public interface IChatClient
    {
        [OperationContract(IsOneWay =true)] //part of a service contract in WCF
        void ReceiveMessage(string user, string message);
    }
}
