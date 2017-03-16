using Mmarab.CqsExample.Application;
using System;


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
