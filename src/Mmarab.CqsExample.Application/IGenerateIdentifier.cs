using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application
{
    public interface IGenerateIdentifier
    {
        Guid Generate();
    }
}
