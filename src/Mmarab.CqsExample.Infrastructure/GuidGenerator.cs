using System;
using Mmarab.CqsExample.Application;

namespace Mmarab.CqsExample.Infrastructure
{
    public class GuidGenerator : IGenerateIdentifier
    {
        public Guid Generate()
        {
           return Guid.NewGuid();
        }
    }
}
