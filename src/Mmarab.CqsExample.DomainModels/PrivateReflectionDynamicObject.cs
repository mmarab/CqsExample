using System;
using System.Reflection;
using System.Dynamic;
using System.Linq;

namespace Mmarab.CqsExample.DomainModels
{
    class PrivateReflectionDynamicObject : DynamicObject
    {
        private object RealObject { get; set; }
        private const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        internal static object WrapObjectIfNeeded(object o)
        {
            return new PrivateReflectionDynamicObject() { RealObject = o };
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = InvokeMemberOnType(RealObject.GetType(), RealObject, binder.Name, args);
            result = WrapObjectIfNeeded(result);
            return true;
        }

        private static object InvokeMemberOnType(Type type, object target, string name, object[] args)
        {
            try
            {
                var result = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.Name == name)
                .Where(m => m.GetParameters().Length == 1)
                .Where(m => m.GetParameters().First().ParameterType == args[0].GetType());

                return result.First().Invoke(target, args);
            }
            catch (MissingMethodException)
            {
                if (type.GetTypeInfo().BaseType != null)
                {
                    return InvokeMemberOnType(type.GetTypeInfo().BaseType, target, name, args);
                }

                return null;
            }
        }
    }
}
