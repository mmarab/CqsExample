using System;
using System.Collections.Generic;
using System.Text;

namespace Mmarab.CqsExample.DomainModels
{
    public class Event : IMessage
    {
        public int Version;
    }
}
