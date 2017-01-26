using System;
using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application
{
    public interface ILogger
    {
        Task Performance(string method, long milliseconds, string message);
        Task Audit(string method, string json, string message);
        void Warn(string message, Exception expection, string[] additionalInformation);
        Task Error(string message, Exception expection, string[] additionalInformation = null);
        void Info(string message, string[] additionalInformation);
    }
}