using System;
using System.Collections.Generic;
using System.Text;

namespace Mmarab.CqsExample.DomainModels.Exceptions
{
    public class ConcurrencyException : Exception
    {
    }

    public class AggregateNotFoundException : Exception
    {
    }
}
