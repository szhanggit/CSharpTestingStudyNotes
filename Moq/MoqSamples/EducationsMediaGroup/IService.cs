using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationsMediaGroup
{
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
    public interface IService
    {
        void DoSomething();
        void DoSomething(int i);
        void DoSomething(string param);
        void DoSomethingMore(int i);
        void DoSomethingWithValue(int value);
        Task DoSomethingAsync();
        int GetSomeValue();
        Task<int> GetSomeValueAsync();

        event EventHandler<MessageEventArgs> Sent;
        event EventHandler<MessageEventArgs> Received;
        Task SendAsync(string message);
        void Send(string message);
        string Receive();
        Task<string> ReceiveAsync();
        string ContentType { get; set; }
    }
}
